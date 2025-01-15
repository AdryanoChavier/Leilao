using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using PesquisaService.Models;
using PesquisaService.RequestHelpers;

namespace PesquisaService.Controllers
{
    [ApiController]
    [Route("api/pesquisa")]
    public class PesquisaController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Item>>> PesquisaItens([FromQuery]PesquisaParams filtro)
        {
            var query = DB.PagedSearch<Item, Item>();

            if (!string.IsNullOrEmpty(filtro.Pesquisa))
            {
                query.Match(Search.Full, filtro.Pesquisa).SortByTextScore();

            }

            query = filtro.Orderby switch
            {
                "marca" => query.Sort(x => x.Ascending(a => a.Marca)),
                "novo" => query.Sort(x => x.Descending(a => a.CreateAt)),
                _ => query.Sort(x => x.Ascending(a => a.LeilaoEnd))
            };

            query = filtro.FilterBy switch
            {
                "finalizado" => query.Match(x => x.LeilaoEnd < DateTime.UtcNow),
                "finalizadobreve" => query.Match(x => x.LeilaoEnd < DateTime.UtcNow.AddHours(6) 
                && x.LeilaoEnd > DateTime.UtcNow),
                _ => query.Match(x => x.LeilaoEnd > DateTime.UtcNow)
            };

            if (!string.IsNullOrEmpty(filtro.Vendedor))
            {
                query.Match(x => x.Vendedor == filtro.Vendedor);
            }

            if (!string.IsNullOrEmpty(filtro.Ganhador))
            {
                query.Match(x => x.Ganhador == filtro.Ganhador);
            }




            query.PageNumber(filtro.PageNumber);
            query.PageSize(filtro.PageSize);

            var result = await query.ExecuteAsync();

            return Ok
            (new
            {
                result = result.Results,
                pageCount = result.PageCount,
                totalCount = result.TotalCount
            }
            );
        }
    }
}
