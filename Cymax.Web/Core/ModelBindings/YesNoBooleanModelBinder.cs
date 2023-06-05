using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Cymax.Web.Core.ModelBindings;

public class YesNoBooleanModelBinder : IModelBinder
{
    public  async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        string body = string.Empty;
        var sr = new StreamReader(bindingContext.HttpContext.Request.Body);
        body = await  sr.ReadToEndAsync();


        var modelName = bindingContext.ModelName;

        var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

        if (valueProviderResult == ValueProviderResult.None)
        {
            return;
        }

        var value = valueProviderResult.FirstValue;
        if (string.Equals(value, "Yes", StringComparison.InvariantCultureIgnoreCase))
        {
            bindingContext.Result = ModelBindingResult.Success(true);
        }
        if (string.Equals(value, "No", StringComparison.InvariantCultureIgnoreCase))
        {
            bindingContext.Result = ModelBindingResult.Success(false);
        }

        return ;
    }
}
