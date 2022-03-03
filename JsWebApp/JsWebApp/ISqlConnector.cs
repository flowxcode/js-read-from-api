using JsWebApp.Model;

namespace JsWebApp
{
    public interface ISqlConnector
    {
        List<Car> ReadCarData();
    }
}