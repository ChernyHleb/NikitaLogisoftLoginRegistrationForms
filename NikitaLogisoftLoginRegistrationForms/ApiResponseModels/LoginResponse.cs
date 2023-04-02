using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikitaLogisoftLoginRegistrationForms.ApiResponseModels
{
    internal class LoginResponse
    {
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
    }
}
