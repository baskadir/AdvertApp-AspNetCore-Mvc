using AdvertApp.Common.Enums;

namespace AdvertApp.Common.ResponseObjects
{
    public interface IResponse
    {
        string Message { get; set; }
        ResponseType ResponseType { get; set; }
    }
}
