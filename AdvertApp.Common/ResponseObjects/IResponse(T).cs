using System.Collections.Generic;

namespace AdvertApp.Common.ResponseObjects
{
    public interface IResponse<T> : IResponse
    {
        T Data { get; set; }
        IEnumerable<CustomValidationError> ValidationErrors { get; set; }
    }
}
