using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using NikitaLogisoftLoginRegistrationForms.models;
using System.Security.Policy;

namespace NikitaLogisoftLoginRegistrationForms
{
    internal class ApiCommunicator
    {
        private RestClient client;
        public ApiCommunicator() 
        { 
            client = new RestClient("http://localhost:3000/");
        }

        public ApiResponse<User> GetUsers()
        {
            var request = new RestRequest("users/");
            var response = client.Get(request);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ApiResponse<User> content = JsonConvert.DeserializeObject<ApiResponse<User>>(response.Content);
                return content;
            }

            return null;
        }

        public ApiResponse<User> GetUserByEmail(string email)
        {
            var request = new RestRequest("users/" + email);
            var response = client.Get(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ApiResponse<User> content = JsonConvert.DeserializeObject<ApiResponse<User>>(response.Content);
                return content;
            }

            return null;
        }

        public ApiResponse<Email> GetEmails()
        {
            var request = new RestRequest("emails");
            var response = client.Get(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ApiResponse<Email> content = JsonConvert.DeserializeObject<ApiResponse<Email>>(response.Content);
                return content;
            }

            return null;
        }

        public void PostUser(UserNoId user)
        {
            var request = new RestRequest("users");
            request.AddBody(JsonConvert.SerializeObject(user));
            client.Post(request);
        }
    }
}
