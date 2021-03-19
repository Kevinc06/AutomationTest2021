using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;


namespace AutomationTest2021.Methods
{
    public static class RestMethods
    {
        /* I create and instantiate an object called "client" of type HttpClient responsible for sending / receiving an HTTP request. */
        public static HttpClient client = new HttpClient();

        /* An object of type HttpResponseMessage was created called "ReturnGet" with the following parameter (string Url) 
           that will be responsible for returning the content contained in the passed Url */
        public static HttpResponseMessage ReturnGet(string Url)
        {
            /* I created an object called "message" of type HttpRequestMessage responsible for 
               containing the GET method of type HttpMethod and the "RequestUri" object */
            HttpRequestMessage message = new HttpRequestMessage
            {
                /* Create an object called "Method" responsible for receiving a HttpMethod "GET" used when the client would like to obtain server resources */
                Method = new HttpMethod("GET"),
                RequestUri = new Uri(Url)
            };

            /* An object called "response" of the HttpResponseMessage type was created that when using the client object to send 
               an asynchronous request to the "message" object requesting its contents */
            HttpResponseMessage response = client.SendAsync(message).Result;
            return response;
        }

        /* An object of type HttpResponseMessage was created called "ReturnPost" with the following parameter (string Url, string content) 
           that will be responsible for to request the web server to accept the data attached in the body of the request message for storage in the passed Url */
        public static HttpResponseMessage ReturnPost(string Url, string content)
        {
            HttpRequestMessage message = new HttpRequestMessage
            {
                /* Create an object called "Method" responsible for receiving a HttpMethod "POST" used when the client would like to obtain server resources */
                Method = new HttpMethod("POST"),
                /* Created an object called "Content" of type StringContent that will store the data to be sent */
                Content = new StringContent(content),
                RequestUri = new Uri(Url)
            };
            return client.SendAsync(message).Result;
        }
    }
}








