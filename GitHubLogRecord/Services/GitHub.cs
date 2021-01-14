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
        public async Task<int> signIn(Credentials credentials) {
            string requestURL = "https://github.com/";
            byte[] byteCredentials = setCredentials(credentials);
            HttpClient client = setHTTPClient(byteCredentials);
            HttpResponseMessage response = await client.GetAsync(requestURL);
            return (int)response.StatusCode;
        }

        private byte[] setCredentials(Credentials credentials) {
            var byteArray = Encoding.ASCII.GetBytes(credentials.email + ":" + credentials.password);
            return byteArray;
        }

        private HttpClient setHTTPClient(byte[] credentials) {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("AppName", "1.0"));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));
            return client;
        }
        public List<string> scrape() {
            return null;
        }
    }
}
