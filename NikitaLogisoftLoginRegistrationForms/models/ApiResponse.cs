using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikitaLogisoftLoginRegistrationForms.models
{
    internal class ApiResponse <T>
    {
        public string message { get; set; }
        public List<T> data { get; set; }
    }
}
