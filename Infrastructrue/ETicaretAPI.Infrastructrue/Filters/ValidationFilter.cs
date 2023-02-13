using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructrue.Filters
{
    public class ValidationFilter: IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(k => k.Key, k => k.Value.Errors.Select(k => k.ErrorMessage)).ToArray();

                context.Result=new BadRequestObjectResult(errors);
                return;
            }
            await next();
        }  
    }
}
