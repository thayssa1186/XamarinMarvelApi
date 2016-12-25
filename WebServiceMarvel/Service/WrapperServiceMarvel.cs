using Marvel.Api;
using Marvel.Api.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceMarvel.Models;

namespace WebServiceMarvel.Service
{
    public class WrapperServiceMarvel
    {
        const string publicKey = "fc3fd7f1f04ecb2cc9922e5af2613a70";
        const string privateKey = "8870d7a864d3963cb915de22fd7dca1e9cdd83da";

        public static PersonagemDTO characters()
        {
            var p = new PersonagemDTO();

            var client = new MarvelRestClient(publicKey, privateKey);

            var response = client.FindCharacters();

            foreach (var character in response.Data.Results)
            {
                p.id = character.Id.ToString();
                p.name = character.Description;
                p.ImageURL = character.Thumbnail.Path + "." + character.Thumbnail.Extension;

                foreach (var commics in character.Comics.Items)
                {
                    p.faciculos.Add(comics(commics.ResourceURI));

                }                
            }

            return p;
        }

        public static PersonagemDTO characters(string Namecharacters)
        {
            var p = new PersonagemDTO();

            var client = new MarvelRestClient(publicKey, privateKey);
            CharacterRequestFilter filter = new CharacterRequestFilter();
            filter.Name = Namecharacters;
            var response = client.FindCharacters(filter);

            foreach (var character in response.Data.Results)
            {
                p.id = character.Id.ToString();
                p.name = character.Description;
                p.ImageURL = character.Thumbnail.Path + "." + character.Thumbnail.Extension;

                foreach (var commics in character.Comics.Items)
                {
                    p.faciculos.Add(comics(commics.ResourceURI));

                }
               
            }
            return p;
        }

        public static FaciculoDTO comics(string urlComics)
        {
            var c = new FaciculoDTO();
            var id = urlComics.Substring(urlComics.Length - 5);
            var client = new MarvelRestClient(publicKey, privateKey);

            var response = client.FindComic(id);

            foreach (var com in response.Data.Results)
            {
                c.id = com.Id.ToString();
                c.name = com.Title;
                c.ImageURL = com.Thumbnail.Path + "." + com.Thumbnail.Extension;
            }

            return c;
        }

    }
}