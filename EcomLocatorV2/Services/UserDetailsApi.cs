using EcomLocatorV2.Interfaces;
using EcomLocatorV2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EcomLocatorV2.Services
{
    class UserDetailsApi : IUserDetailsService
    {
        private const string SERVER_NAME = "https://internshiptaskuserslist.azurewebsites.net/api/users/";
        private const string KEY = "code=9XuCxWZqJavOAWHPcWD/97mMeJkK0mSVMA9A6MQ9n4R1B/6fpsxGqw==";
        public async Task<User> GetUserDetails(int userId)
        {
            var httpClient = new HttpClient();
            string fullQueryAddress = $"{SERVER_NAME}{userId}?{KEY}";
            var response = await httpClient.GetStringAsync(fullQueryAddress);
            return JsonConvert.DeserializeObject<WrapperSingle>(response).Data;
        }
    }
}
