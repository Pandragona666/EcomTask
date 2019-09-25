using System.Collections.Generic;

namespace EcomLocatorV2.Model
{
    public class Wrapper
    {
        public bool IsSuccess { get; set; }
        public List<User> Data { get; set; }
    }
}
