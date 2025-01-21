using AuctionService.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using AuctionService.DTOs;
using Microsoft.EntityFrameworkCore;
using AuctionService.Entities;
using AutoMapper.QueryableExtensions;
using MassTransit;
using Contracts;

namespace AuctionService.Controllers
{
    [ApiController]
    [Route("api/leilao")]
    public class LeilaoController : ControllerBase
    {
        private readonly LeilaoDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public LeilaoController(LeilaoDbContext context, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeilaoDto>>> GetAllLeiloes(string? date)
        {
            var query = _context.Leiloes.OrderBy(x => x.Item.Marca).AsQueryable();

            if (!string.IsNullOrWhiteSpace(date)) 
            { 
             query = query.Where(x => x.UpdatedAt.CompareTo(DateTime.Parse(date).ToUniversalTime()) > 0);

            }

            return await query.ProjectTo<LeilaoDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeilaoDto>> GetLeilaoById(Guid Id)
        {
            var leilao = await _context.Leiloes
                .Include(x => x.Item)
                .FirstOrDefaultAsync(x => x.Id == Id);

            if (leilao == null) return NotFound();

            return _mapper.Map<LeilaoDto>(leilao);
        }

        [HttpPost]
        public async Task<ActionResult<LeilaoDto>> CreateLeilao(CreateLeilaoDto leilaoDto)
        {
            var leilao = _mapper.Map<Leilao>(leilaoDto);

            leilao.Vendedor = "test";

            _context.Leiloes.Add(leilao);

            var newLeilao = _mapper.Map<LeilaoDto>(leilao);

            await _publishEndpoint.Publish(_mapper.Map<LeilaoCreated>(newLeilao));

            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return BadRequest("Não foi salvo no banco");

            return CreatedAtAction(nameof(GetLeilaoById),
                new { leilao.Id }, newLeilao);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLeilao(Guid id, AtualizarLeilaoDto atualizarLeilaoDto)
        {
            var leilao = await _context.Leiloes.Include(x => x.Item)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (leilao == null) return NotFound();

            leilao.Item.Marca = atualizarLeilaoDto.Marca ?? leilao.Item.Marca;
            leilao.Item.Modelo = atualizarLeilaoDto.Modelo ?? leilao.Item.Modelo;
            leilao.Item.Cor = atualizarLeilaoDto.Cor ?? leilao.Item.Cor;
            leilao.Item.Quilometragem = atualizarLeilaoDto.Quilometragem ?? leilao.Item.Quilometragem;
            leilao.Item.Marca = atualizarLeilaoDto.Marca ?? leilao.Item.Marca;

            await _publishEndpoint.Publish(_mapper.Map<LeilaoUpdated>(leilao));

            var result = await _context.SaveChangesAsync() > 0;

            if (result) return Ok();
            return BadRequest("Erro em Atualizar");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLeilao(Guid id)
        {
            var leilao = await _context.Leiloes.FindAsync(id);

            if (leilao == null) return NotFound();

            _context.Leiloes.Remove(leilao);

            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return BadRequest("Erro ao deletar");

            return Ok();

        }
    }
}
