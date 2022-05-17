using System;

namespace Amparo.API.Models
{
    public class JWT
    {
        public string Token { get; set; }
        public DateTime expire { get; set; }
    }
}
