using AutoMapper;
using Cymax.Web.Profiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cymax.Web.Core.ActionFilters;

public class ResultAttibutes : ResultFilterAttribute
{

    public override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var ctrlActionDesc = context.ActionDescriptor as ControllerActionDescriptor;

        var retAttribute = (MappingAttribute)ctrlActionDesc.MethodInfo?
                                                           .GetCustomAttributes(inherit:true)
                                                           .FirstOrDefault(x => x.GetType() == typeof(MappingAttribute)) ;

        if (retAttribute == null)   
            return base.OnResultExecutionAsync(context, next);

        var type = retAttribute.MappingType;
        var typeObj = Activator.CreateInstance(type);
        var actionResultValue = context.Result as ObjectResult;

        var mapper = new MapperConfiguration(cfg => cfg.AddProfile(typeof(ResultProfile)))
                                            .CreateMapper();

        var result = mapper.Map(actionResultValue?.Value , typeObj);

        actionResultValue.Value = result;
        return base.OnResultExecutionAsync(context, next);

    }


}
