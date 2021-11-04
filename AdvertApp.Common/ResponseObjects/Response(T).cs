using AdvertApp.Common.Enums;
using System.Collections.Generic;

namespace AdvertApp.Common.ResponseObjects
{
    public class Response<T> : Response,IResponse<T>
    {
        // Bir data gelmezse hata mesajı göndermek için 
        public Response(ResponseType responseType, string message):base(responseType, message)
        {
        }

        // Sadece responseType'ı gönderebiliriz.
        public Response(ResponseType responseType, T data) : base(responseType)
        {
            Data = data;
        }

        // Business de ilgili işlem validation hatasına yakalanmışsa validation hatalarını döndürmek için
        public Response(T data, IEnumerable<CustomValidationError> errors):base(ResponseType.ValidationError)
        {
            ValidationErrors = errors;
            Data = data;
        }

        public T Data { get; set; }
        public IEnumerable<CustomValidationError> ValidationErrors { get; set; }
    }
}
