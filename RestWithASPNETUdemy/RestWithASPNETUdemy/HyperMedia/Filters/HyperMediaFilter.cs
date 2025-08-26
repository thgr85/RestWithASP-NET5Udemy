using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RestWithASPNETUdemy.HyperMedia.Filters
{
    public class HyperMediaFilter : ResultFilterAttribute
    {
        private readonly HyperMediaFilterOptions _options;

        public HyperMediaFilter(HyperMediaFilterOptions options)
        {
            _options = options;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            TryEnrichResult(context);
            base.OnResultExecuting(context);
        }

        private void TryEnrichResult(ResultExecutingContext context)
        {
            if (context.Result is OkObjectResult okObjectResult && okObjectResult.Value is not null) //Atenção: verificação de null adicionada
            {
                var enricher = _options.ContentResponseEnricherList.FirstOrDefault(e => e.CanEnrich(context));
                if (enricher is not null) Task.FromResult(enricher.Enrich(context));
            }
        }
    }
}
