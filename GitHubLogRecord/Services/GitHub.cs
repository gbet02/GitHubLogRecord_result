using System.Collections.Generic;
using GitHubLogRecord.Interfaces;
using GitHubLogRecord.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Text;
using System.Net;

namespace GitHubLogRecord.Services
{
    public class GitHub : IGitHub
    {
        public async Task<int> signIn(Credentials credentials)  {
            var TARGETURL = "https://github.com/settings/security-log";
            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(TARGETURL);
            var byteArray = Encoding.ASCII.GetBytes(credentials.email + ":" + credentials.password);
            //client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("GitHubLogRecord", "1.0"));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            //HttpResponseMessage response = await client.GetAsync(TARGETURL);
            HttpResponseMessage response = await client.GetAsync(TARGETURL);
            HttpContent content = response.Content;
            string textRes = "Response StatusCode: " + (int)response.StatusCode;
            string result = await content.ReadAsStringAsync();
            int stat = (int)response.StatusCode;
            return stat;
        }
        public List<string> scrape() {
            return null;
        }
    }
}
