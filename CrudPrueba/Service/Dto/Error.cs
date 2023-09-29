using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CrudPrueba.Service.Dto
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
