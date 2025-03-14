using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using SdetBootcampDay3.Models;
using System.Net;

namespace SdetBootcampDay3.Exercises
{
    [TestFixture]
    public class TakeHomeExercises
    {
        /**
         * TODO: First, have a look at the API docs here: https://reqres.in
         */

        private const string API_ENDPOINT_BASE = "https://reqres.in";

        private RestClient client;

        //Step 0
        [OneTimeSetUp]
        public void EstablishRESTHandler()
        {
            client = new RestClient(API_ENDPOINT_BASE);
        }
        //Step 1
        [Test]
        public async Task CheckRequestResponse_StatusIsOK()
        {
            RestRequest request = new RestRequest("/api/users/2", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }
        //step 2
        [Test, TestCaseSource("VerifyUserNameValue")]
        public async Task GetDataForUser_VerifyName(int UserId, string UserName)
        {
            RestRequest request = new RestRequest($"/api/users/{UserId}", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);
            
            JObject responseData = JObject.Parse(response.Content);
            
            Assert.That(responseData.SelectToken("data.first_name").ToString(), Is.EqualTo(UserName));

        }

        public static Dictionary<int, string> UsersToValidate = new Dictionary<int, string>
        {
            {1,"George"},
            {2, "Janet"},
            {3, "Emma"}
        };

        private static IEnumerable<TestCaseData> VerifyUserNameValue()
        {
            foreach (KeyValuePair<int, string> user in UsersToValidate)
            {
                yield return new TestCaseData(user.Key, user.Value).SetName($"VerifyUser_{user.Value}");
            }
        }

        //step 3
        [Test]
        public async Task CreateNewUser()
        {
            RestRequest request = new RestRequest("/api/users", Method.Post);

            TakeHomeUserDto NewUserData = new TakeHomeUserDto
            {
                Name = "Saint Celestine",
                Job = "Living Saint; Servant of the Emperor; Faith Incarnate"
            };

            request.AddJsonBody(NewUserData);

            RestResponse response = await client.ExecuteAsync(request);

            Console.WriteLine((string)response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        /**
         * TODO: Write a [OneTimeSetUp] method that initializes the RestClient before a test run
         */


        /**
        * TODO: Write a test that creates a new request for an HTTP GET to "/api/users/2"
        * Send the request and check that the response status code is equal to HttpStatusCode.OK
        */


        /**
         * TODO: Write a parameterized test that retrieves data for users 1, 2 and 3 (see above for the
         * endpoint to use) and verify that their names are George, Janet and Emma, respectively.
         * You're looking for the "first_name" element that is a child element of the "data" element.
         * For an example, open https://reqres.in/api/users/1 in a browser.
         * You can decide for yourself whether to use [TestCase] or [TestCaseSource] (or both).
         */


        /**
         * TODO: Write a new test that creates a new user using an HTTP POST.
         * Create the request body by instantiating and serializing an instance of the TakeHomeUserDto object.
         * Send the request and check that the response status code is equal to HttpStatusCode.Created.
         */

    }
}
