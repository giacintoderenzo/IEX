using System;
using System.Net.Http;
using System.Text;

namespace IEX
{
    public class IEXConnector
    {
        public const string IEX_API_PATH = "https://api.iextrading.com/1.0/stock";
        public const string IEX_PATH_SEPPARATOR = @"/";

        public IEXResponse DoRequest(IEXRequest request)
        {
            Uri uri = getUri(request.GetEndpoint());
            using (HttpClient client = getClient(uri))
            {
                Console.WriteLine(uri.ToString());
                HttpResponseMessage response = client.GetAsync(uri).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                    IEXResponse iexresponse = request.ParseReqponse();
                    return iexresponse;
                }
                else
                {
                    Console.WriteLine(response.ToString());
                    return null;
                }
            }
        }

        private HttpClient getClient(Uri endpoint)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = endpoint;
            return client;
        }

        private Uri getUri(string endpoint)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(IEX_API_PATH);
            sb.Append(IEX_PATH_SEPPARATOR);
            sb.Append(endpoint);
            return new Uri(sb.ToString());
        }
    }
}
