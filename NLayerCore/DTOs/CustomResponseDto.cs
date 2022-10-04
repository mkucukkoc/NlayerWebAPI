using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayerCore.DTOs
{
    //Static Factory Metot Nedir?
    /*Genelde sınıf kendisinden nesne oluşturmasını istiyorsa public constructor kullanır. 
      Farklı ve etkili yöntemlerden biri de public static factory method kullanmaktır.
      Bu sınıfın instance’ını(örneğini) döndüren basit bir static metottur.Bu metot Factory Method tasarım deseninden farklıdır.
      Static factory metot public constructor yerine kullanılabilir ama bunun hem avantajı hem dezavantajı vardır.
      Static factory metotların isimleri vardır constructor’ın aksine.
      Constructorların aldıkları parametrelere göre yaptıkları işler anlaşılmaya çalışılır ama static factory metotlar 
      isimlendirilebildikleri için kod okunması sırasında ne yaptıkları isminden anlaşılabilir.
      Constructorların aksine her çağrıldıklarında yeni bir nesne oluşturmaları gerekmez.
      Constructorların aksine, dönüş tiplerinin herhangi bir alt tipindeki bir nesneyi döndürebilirler. 
      Bu, döndürülen nesnenin sınıfını seçmede bize büyük esneklik ve kapsülleme (encapsulation) imkanı sağlar.
      API yazımında tercih edilir.CustomResponseDto adı altında aşagıda oluşturulan metotlar örnektir. 
     */
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int  StatusCode { get; set; }
        public List<String> Errors { get; set; }

        public static CustomResponseDto<T>Success(int statusCode,T data)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Data = data };   
        }
        public static CustomResponseDto<T>Success(int statusCode)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode };
        }
        public static CustomResponseDto<T> Fail(int statusCode,List<string>errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors };
        }
        public static CustomResponseDto<T> Fail(int statusCode,string errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { errors} };
        }
    }
}
