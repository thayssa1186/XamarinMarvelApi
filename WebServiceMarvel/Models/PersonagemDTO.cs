using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceMarvel.Models
{
    public class PersonagemDTO
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string ImageURL { get; set; }
        public List<FasciculoDTO> Fasciculos { get; set; }


}
    public class FasciculoDTO
    {
        public string id { get; set; }
        public string idPersonagem { get; set; }
        public string name { get; set; }
        public string ImageURL { get; set; }

    }
}