using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerCore.DTOs;

namespace NlayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomeBaseController : ControllerBase
    {
        /*NonAction metodu, Controller içerisinde public olarak tanımlanmış normal metodları temsil etmektedir. 
         * Daha doğru bir şekilde ifade etmemiz gerekirse eğer, ilgili metod bir Action metod özelliğinde
         * kullanılmayacaksa o metodu NonAction attribute’u ile işaretleyerek bir Action metod olmadığını bildiririz. 
         Yani bu metot bir istek yapmak istersek ,istek yapmaz.
         Eğer ki ekranda da gördüğünüz gibi ilgili metod NonAction attribute’u ile işaretlenirse
         “/Home/Islem” adresi bir Action metodu işaret etmeyeceğinden dolayı çalışmayacaktır.
         Aslında NonAction attributeu ilgili metodu birnevi private durumundaki gibi dışarıdan
         erişimsiz bir hale getirmektedir.*/


        //
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T>response)
        {
            if (response.StatusCode==204)
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };
            }
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
