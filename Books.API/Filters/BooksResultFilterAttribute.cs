using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Books.API.Filters
{
    public class BooksResultFilterAttribute : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context,
           ResultExecutionDelegate next)
        {
            if (context.Result is OkObjectResult result
             && result.Value is IEnumerable<Entities.Book> detail)
            {
                var mapper = context.HttpContext.RequestServices.GetService<IMapper>();
                result.Value = mapper.Map<IEnumerable<Models.Book>>(detail);
            }

            await next();
        }
    }
}
