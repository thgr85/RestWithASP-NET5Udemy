using RestWithASPNETUdemy.HyperMedia.Abstract;

namespace RestWithASPNETUdemy.HyperMedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
