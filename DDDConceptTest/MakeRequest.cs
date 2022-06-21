using DDDConcept.PersonModule.Interface.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DDDConceptTest
{
    [TestClass]
    public class MakeRequest
    {
        static readonly HttpClient client = new HttpClient();
        static readonly int port = 7233;
        static readonly string baseUrl = $"https://localhost:{port}";

        [TestMethod]
        public async Task GetAllPersons()
        {
            HttpResponseMessage response = await client.GetAsync($"{baseUrl}/all");
            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();

            List<PersonResponseDTO> contributors = JsonConvert.DeserializeObject<List<PersonResponseDTO>>(resp);
            Assert.IsTrue(contributors.Count > 0);
        }

        [TestMethod]
        public async Task PostPerson()
        {
            var person = new PersonDTO
            {
                FirstName = "Naveen Kumar",
                LastName = "Lokesh"
            };

            var json = JsonConvert.SerializeObject(person);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync($"{baseUrl}/post", data);
            response.EnsureSuccessStatusCode();
        }
    }
}