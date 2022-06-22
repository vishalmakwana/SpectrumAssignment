using System;
using System.Collections.Generic;
using System.Text;

namespace SpectrumAssignment.Models.Request
{
    public class MainResponseStatus
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public bool IsError { get; set; }
        public string Error { get; set; }
        public string Message { get; set; }
        public string ErrorTitle { get; set; }

    }
}
