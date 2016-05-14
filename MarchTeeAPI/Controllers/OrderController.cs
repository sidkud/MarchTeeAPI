using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Headers;

namespace MarchTeeAPI.Controllers
{
    public class OrderController : ApiController
    {
        // GET api/order
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/order/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/order
        public void Post([FromBody]string value)
        {
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                   { "thing1", "hello" },
                   { "thing2", "world" }
                };

                var content = new FormUrlEncodedContent(values);
                //b09f2081f20b3657ce4c74e2e7b4d45f
                //5ac5e7ebebe9916713f3e9a5227774e6

                /*
                 * 
                 * POST https: //marchtee-dev.myshopify.com/admin/orders.json HTTP/1.1
                    User-Agent: Fiddler
                    Host: marchtee-dev.myshopify.com
                    Authorization: Basic YjA5ZjIwODFmMjBiMzY1N2NlNGM3NGUyZTdiNGQ0NWY6NWFjNWU3ZWJlYmU5OTE2NzEzZjNlOWE1MjI3Nzc0ZTY=
                    Content-Type: application/json
                    Content-Length: 2650
                 * 
                 * */

                //HttpRequestMessage<RequestType> request =
                //new HttpRequestMessage<RequestType>(
                //    new RequestType("third-party-vendor-action"),
                //    MediaTypeHeaderValue.Parse("application/xml"));

                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://b09f2081f20b3657ce4c74e2e7b4d45f:5ac5e7ebebe9916713f3e9a5227774e6@marchtee-dev.myshopify.com/admin/orders.json"),
                    Method = HttpMethod.Get
                };

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //request.Headers.Add("Authorization", "YjA5ZjIwODFmMjBiMzY1N2NlNGM3NGUyZTdiNGQ0NWY6NWFjNWU3ZWJlYmU5OTE2NzEzZjNlOWE1MjI3Nzc0ZTY=");

                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", "YjA5ZjIwODFmMjBiMzY1N2NlNGM3NGUyZTdiNGQ0NWY6NWFjNWU3ZWJlYmU5OTE2NzEzZjNlOWE1MjI3Nzc0ZTY=");

                var result = client.SendAsync(request).Result;
                //var result = client.PostAsync("https://b09f2081f20b3657ce4c74e2e7b4d45f:5ac5e7ebebe9916713f3e9a5227774e6@marchtee-dev.myshopify.com/admin/orders.json", content).Result;

                string resultContent = result.Content.ReadAsStringAsync().Result;

            }
        }

        // PUT api/order/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/order/5
        public void Delete(int id)
        {
        }
    }
}
