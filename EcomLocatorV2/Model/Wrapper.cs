using System;
using System.Collections.Generic;
using System.Text;

namespace EcomLocatorV2.Model
{
    public class Wrapper
    {
        public bool IsSuccess { get; set; }
        public List<User> Data { get; set; }
    }
}
