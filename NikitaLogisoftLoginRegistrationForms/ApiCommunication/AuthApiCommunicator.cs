using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using System.Net.Security;
using NikitaLogisoftLoginRegistrationForms.ApiResponseModels;
using NikitaLogisoftLoginRegistrationForms.models;

namespace NikitaLogisoftLoginRegistrationForms
{
    internal class AuthApiCommunicator
    {
        private RestClient client;
        public AuthApiCommunicator() 
        {
            client = new RestClient("http://localhost:80/");
        }

        public LoginResponse Login(User user)
        {
            var request = new RestRequest("/login");
            request.AddBody(JsonConvert.SerializeObject(user));
            var rawResponse = client.Post(request);
            
            if(rawResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                LoginResponse content = JsonConvert.DeserializeObject<LoginResponse>(rawResponse.Content);
                return content;
            }

            return null;
        }
    }
}
