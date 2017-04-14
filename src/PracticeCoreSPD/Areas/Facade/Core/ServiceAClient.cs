using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace PracticeCoreSPD.Areas.Facade.Core
{
    public class ServiceAClient
    {
        public Book SearchBook(string isbn)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60796");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/api/ServiceA/" + isbn).Result;

            string jsonData = response.Content.ReadAsStringAsync().Result;
            Book book = JsonConvert.DeserializeObject<Book>(jsonData);
            return book;
        }
    }
}
