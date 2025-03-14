using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace SdetBootcampDay3.Exercises
{
    [TestFixture]
    public class Exercises01
    {
        private const string BASE_URL = "http://jsonplaceholder.typicode.com";

        private RestClient client;

        [OneTimeSetUp]
        public void SetupRestSharpClient()
        {
            client = new RestClient(BASE_URL);
        }

        [Test]
        public async Task GetDataForUser1_CheckStatusCode_ShouldBeHttpOK()
        {
            RestRequest request = new RestRequest("/users/1", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            /**
             * TODO: Assert that the response status code is equal to HttpStatusCode.OK
             */
             Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }

        [Test]
        public async Task GetDataForUser1_CheckStatusCode_ShouldBeHttp200()
        {
            RestRequest request = new RestRequest("/users/1", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            /**
             * TODO: Assert that the response status code is equal to 200 (integer)
             */
             Assert.That((int)response.StatusCode, Is.EqualTo(200));

        }

        [Test]
        public async Task GetDataForUser2_CheckContentType_ShouldContainApplicationJson()
        {
            RestRequest request = new RestRequest("/users/2", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            Assert.That(response.ContentType, Is.EqualTo("application/json"));
            /**
             * TODO: Create and execute a new GET request to 'users/2'
             * Verify that the response Content-Type contains 'application/json'
             */

        }

        [Test]
        public async Task GetDataForUser3_CheckServerHeader_ShouldBeCloudflare()
        {
            RestRequest request = new RestRequest("/users/3", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            string? HeaderServerValue = response.GetHeaderValue("Server");

            //response.Server is also an option here;

            Assert.That(HeaderServerValue, Is.EqualTo("cloudflare"));
            /**
             * TODO: Create and execute a new GET request to '/users/3'
             * Verify that the value of the 'Server' response header is
             * equal to 'cloudflare'
             */

        }

        [Test]
        public async Task GetDataForUser4_CheckName_ShouldBePatriciaLebsack()
        {
            RestRequest request = new RestRequest("/users/4", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseBody = JObject.Parse(response.Content);

            Assert.That(responseBody.SelectToken("name").ToString(), Is.EqualTo("Patricia Lebsack"));
            /**
             * TODO: Create and execute a new GET request to '/users/4'
             * Verify that the value of the 'name' response body element
             * is equal to 'Patricia Lebsack'
             */

        }

        [Test]
        public async Task GetDataForUser5_CheckCompanyName_ShouldBeKeeblerLLC()
        {
            RestRequest request = new RestRequest("/users/5", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseBody = JObject.Parse(response.Content);

            Assert.That(responseBody.SelectToken("company.name").ToString(), Is.EqualTo("Keebler LLC"));
            /**
             * TODO: Create and execute a new GET request to '/users/5'
             * Verify that the value of the company name in the response body
             * is equal to 'Keebler LLC'
             */

        }
    }
}
