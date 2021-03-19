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
            string url = "https://reqres.in/api/users";
            int expectedBehaviour = 201;
            string content = "{\"Name\":\"Mickey Mouse\",\"Job\":\"CEO\"}";


        }
    }
}


