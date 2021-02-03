using System;
using System.Collections.Generic;
using System.Text;

namespace ChatTest.Common.DTOs
{
    public class SignalVM
    {
        public string Description { get; set; }
        public string CustomerName { get; set; }
        public string AccessCode { get; set; }
        public string Area { get; set; }
        public string Zone { get; set; }
        public DateTime SignalDate { get; set; }
    }
}
