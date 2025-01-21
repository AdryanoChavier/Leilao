namespace PesquisaService.Middlewares.AutoMapper
{
    public class PesquisaParams
    {
        public string Pesquisa { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 4;
        public string Vendedor { get; set; }
        public string Ganhador { get; set; }
        public string FilterBy { get; set; }
        public string Orderby { get; set; }
    }
}
