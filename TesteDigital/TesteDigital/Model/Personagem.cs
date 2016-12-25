using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDigital
{
    public class Personagem
    {

        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string ImageURL { get; set; }
        public List<Faciculo> faciculos { get; set; }
    }

    public class Faciculo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string ImageURL { get; set; }
    }
}
