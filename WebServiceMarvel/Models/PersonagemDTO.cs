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
        public List<FaciculoDTO> faciculos { get; set; }


}
    public class FaciculoDTO
    {
        public string id { get; set; }
        public string name { get; set; }
        public string ImageURL { get; set; }

    }
}