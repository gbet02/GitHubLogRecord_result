using System.Collections.Generic;
using GitHubLogRecord.Interfaces;
using GitHubLogRecord.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Text;
using System.Net.Http.Headers;

namespace GitHubLogRecord.Services
{
    public class GitHub : IGitHub {
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
            client.DefaultRequestHeaders.UserAgent.Add(setProductInfoHeaderValue());
            client.DefaultRequestHeaders.Accept.Add(setMediaTypeWithQualityHeaderValue());
            client.DefaultRequestHeaders.Authorization = setAuthenticationHeaderValue(credentials);
            return client;
        }

        private AuthenticationHeaderValue setAuthenticationHeaderValue(byte[] credentials) {
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));
        }

        private MediaTypeWithQualityHeaderValue setMediaTypeWithQualityHeaderValue() {
            return new MediaTypeWithQualityHeaderValue("application/json");
        }

        private ProductInfoHeaderValue setProductInfoHeaderValue() {
            return new ProductInfoHeaderValue("AppName", "1.0");
        }

        public List<string> scrape() {
            return null;
        }
    }
}
