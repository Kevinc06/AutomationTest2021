using NUnit.Framework;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System;
using AutomationTest2021.Methods;
using System.Net;

namespace AutomationTest2021.ApiTest
{
    [TestFixture]
    class ApiTest
    {
        [Test]
        public void FirstTest()
        {
            /* Assigning the API link API link that the data will be inserted in the variable "url" */
            string url = "https://reqres.in/api/users";
            int expectedBehaviour = 201;
            string content = "{\"Name\":\"Mickey Mouse\",\"Job\":\"CEO\"}";

            try
            {
                /* Creation of a variable called "response" that will call the ReturnPost () method that will send certain data to the URL that was previously defined */
                HttpResponseMessage response = RestMethods.ReturnPost(url, content);
                /* Stores in the variable "body" as a string the unformatted data/content that was present in the variable "response" */
                string body = response.Content.ReadAsStringAsync().Result;
                /* Verifying that the value assigned in the "StatusCode" field that was returned through the "body" variable is the same as that in the "ExpectedBehaviour" field, if true the test will pass */
                Assert.AreEqual((int)response.StatusCode, expectedBehaviour);
                /* A variable was created so that it was possible to store the content present in the variable "body", however, formatted as a JSON using the method "JOBject.Parse (Body)"  
                 as the type of data present in the content will change at run time, we need the type of the variable to be dynamic*/
                dynamic parsedBody = JObject.Parse(body);
                /* Created a variable called "idCode" to store the data found in the id field */
                int idCode = parsedBody.id;

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }


        }


    }
}



