using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NLayerCore.DTOs;

namespace NlayerAPI.Filters
{
    public class ValidateFilterAttribute : ActionFilterAttribute
    {
        //OnActionExecuting metotunu ActionFilterAttribute sınıfından  miras alıyoruz
        //bu metot aaction metotları yani controller içindeki ProductController içindeki action metotları çalişırken
        // kontrol etmek için kullanırız.Eğer bir hata alırsak bu hatayı kontrol etmek için kullanırız.
        //böylece metotlar çalışırken mi hata veriyor yoksa çalişmadan önce mi tüm bu olasılıkları ögrenebiliriz.
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(CustomResponseDto<NoContentDto>.Fail(400, errors));
            }
        }
    }
}
