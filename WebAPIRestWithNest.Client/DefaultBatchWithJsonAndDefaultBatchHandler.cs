using System;
using System.Net.Http;
using System.Text;
using Damienbod.BusinessLayer.DomainModel;
using Newtonsoft.Json;

namespace WebAPIRestWithNest.Client
{
    public class DefaultBatchWithJsonAndDefaultBatchHandler
    {
        const string BaseAddress = "https://webapirestwithnest/";

        private static HttpRequestMessage CreateNewAnimal(int id, string description)
        {
            var x1 = new HttpRequestMessage(HttpMethod.Post, BaseAddress + "/api/animals");
            var animal = new Animal
            {
                AnimalType = "monkey",
                CreatedTimestamp = DateTime.UtcNow,
                DateOfBirth = DateTime.UtcNow.AddMonths(-15),
                Description = description,
                Gender = "Male",
                Id = id,
                TypeSpecificForAnimalType = "imported monkey from asia",
                UpdatedTimestamp = DateTime.UtcNow,
                LastLocation = "Olten"
            };

            x1.Content = new StringContent(JsonConvert.SerializeObject(animal), Encoding.UTF8, "application/json");
            return x1;
        }

        public static void DoRequest()
        {
            var client = new HttpClient();
            var batchRequest = new HttpRequestMessage(HttpMethod.Post, BaseAddress + "/api/$batch")
            {
                Content = new MultipartContent("mixed")
                {
                    new HttpMessageContent(CreateNewAnimal(210,"crazy monkey")),
                    new HttpMessageContent(CreateNewAnimal(211,"happy monkey")),
                    new HttpMessageContent(CreateNewAnimal(212,"sad monkey")),
                    new HttpMessageContent(CreateNewAnimal(213,"silly monkey")),
                    new HttpMessageContent(CreateNewAnimal(214,"dead monkey"))
                }
            };

            HttpResponseMessage batchResponse = client.SendAsync(batchRequest).Result;

            MultipartStreamProvider streamProvider = batchResponse.Content.ReadAsMultipartAsync().Result;
            foreach (var content in streamProvider.Contents)
            {
                HttpResponseMessage response = content.ReadAsHttpResponseMessageAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    // var p = response.Content.ReadAsAsync<Animal>(new[] { new JsonMediaTypeFormatter() }).Result;
                    // Console.WriteLine("{0}\t{1};\t{2}", p.Name, p.StringValue, p.Id);
                }
            }
        }
    }
}