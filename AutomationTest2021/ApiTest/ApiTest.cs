using NUnit.Framework;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System;
using AutomationTest2021.Methods;
using AutomationTest.LoginInfo;
using System.IO;
using System.Net;

namespace AutomationTest2021.ApiTest
{
    [TestFixture]
    public class ApiTest : Login
    {
        [Test]
        public void Test()
        {
            /* Assigning the API link that the data will be inserted in the variable "url" */
            string url = "https://reqres.in/api/users";
            int expectedBehaviour = 201;
            string content = "{\"Name\":\"Mickey Mouse\",\"Job\":\"CEO\"}";
            try
            {
                /* POST Method */
                /* Creation of a variable called "response" that will call the ReturnPost () method that will send certain data to the URL that was previously defined */
                HttpResponseMessage response = RestMethods.ReturnPost(url, content);
                /* Stores in the variable "body" as a string the unformatted data/content that was present in the variable "response" */
                string body = response.Content.ReadAsStringAsync().Result;
                /* Verifying that the value assigned in the "StatusCode" field that was returned through the "body" variable is the same as that in the "ExpectedBehaviour" field, if true the test will pass */
                Assert.AreEqual((int)response.StatusCode, expectedBehaviour);
                /* A variable was created so that it was possible to store the content present in the variable "body", however, formatted as a JSON using the method "JOBject.Parse (Body)"  
                  as the type of data present in the content will change at run time, we need the type of the variable to be dynamic */
                dynamic parsedBody = JObject.Parse(body);
                /* Variables were created to store the information that will be used in the future */
                string name = parsedBody.Name;
                string job = parsedBody.Job;
                string idCode = parsedBody.id;

                /* GET Method */
                /* Assigning the API link that the data will be inserted in the variable "url" */
                string urlGet = $"https://reqres.in/api/users/{idCode}";
                /* Calling the ReturnGet method */
                HttpResponseMessage responseGet = RestMethods.ReturnGet(urlGet);
                /* Stores in the variable "bodyGet" as a string the unformatted data/content that was present in the variable "responseGet" */
                string bodyGet = responseGet.Content.ReadAsStringAsync().Result;
                /* Check if it returns something using the single user method */
                Assert.AreEqual(bodyGet, "{}");
                /* Verifying that the name and job are correct with what was entered previously using the POST method */
                Assert.AreEqual(name, "Mickey Mouse");
                Assert.AreEqual(job, "CEO");
            }
            /* Treatment in case of any failure in any of the tests */
            catch (Exception e)
            {
                /* Message that will return if any test fails */
                Assert.Fail(e.Message);
            }
        }
    }
}



