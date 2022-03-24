using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HTTP
{
    public class HttpHelper
    {
        public string baseUri { get; set; }

        public HttpHelper(string baseUri)
        {
            this.baseUri = baseUri;
        }

        public async Task<string> HttpClientPostAsync(object postData)
        {
            HttpClient client = new HttpClient();

            var json = JsonConvert.SerializeObject(postData);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            string result = null;

            try
            {
                HttpResponseMessage response = await client.PostAsync(this.baseUri, data);
                response.EnsureSuccessStatusCode();
                result = response.Content.ReadAsStringAsync().Result;
            }
            catch { }


            return result;
        }
    }
}
