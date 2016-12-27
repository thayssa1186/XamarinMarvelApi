using SQLite;
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
        public List<Fasciculo> Fasciculos { get; set; }
    }

    public class Fasciculo
    {
        public string id { get; set; }
        public string idPersonagem { get; set; }
        public string name { get; set; }
        public string ImageURL { get; set; }
    }

    public class PersonagemEN
    {
        [PrimaryKey]
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string ImageURL { get; set; }      
    }

    public class FasciculoEN
    {
        [PrimaryKey]
        public string id { get; set; }
        public string idPersonagem { get; set; }
        public string name { get; set; }
        public string ImageURL { get; set; }
    }

    public class SincronizacaoEN
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public DateTime data { get; set; }
    }
}
