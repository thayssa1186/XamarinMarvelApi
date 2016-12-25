using Marvel.Api;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServiceMarvel.Models;

namespace WebServiceMarvel.Controllers
{
    public class ValuesController : ApiController
    {
        const string publicKey = "fc3fd7f1f04ecb2cc9922e5af2613a70";
        const string privateKey = "8870d7a864d3963cb915de22fd7dca1e9cdd83da";

        // GET api/getPersonagens
        public void getPersonagens()
        {
            // Initialize the API client
            // 
            var client = new MarvelRestClient(publicKey, privateKey);

            // First 20 characters 
            // 
            var response = client.FindCharacters();

            // Iterate through the results
            // 
            foreach (var character in response.Data.Results)
            {
                // Do something with the character info 
                string name = character.Name;
            }
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
