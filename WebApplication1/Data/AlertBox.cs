using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class AlertBox
    {
        public AlertBox()
        {

        }

        public AlertBox(string message, AlertType alertType)
        {
            this.Message = message;
            this.AlertType = alertType;
        }
        public string Message { get; set; } = String.Empty;
        public AlertType AlertType { get; set; }
        public int DecayTime { get; set; } = 0;
    }
}
