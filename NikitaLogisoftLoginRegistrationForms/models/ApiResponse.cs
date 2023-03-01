using System.Collections.Generic;

namespace NikitaLogisoftLoginRegistrationForms.models
{
    internal class ApiResponse <T>
    {
        public string message { get; set; }
        public List<T> data { get; set; }
    }
}
