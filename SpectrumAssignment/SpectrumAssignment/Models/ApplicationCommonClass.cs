using System;
using System.Collections.Generic;
using System.Text;

namespace SpectrumAssignment.Models
{
    public class TitleValue
    {
        public string Title { get; set; }
        public string Value { get; set; }
        public bool IsSelected { get; set; }
        public int HiddenValueInt { get; set; }
    }
    
    public class SuccessOrStringResponse
    {
        public bool IsSuccess { get; set; }
        public string Content { get; set; }
    }

    public static class API
    {
        public const string GetUsers = "public/v2/users";
    }

    public class UserInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string status { get; set; }
    }
}
