using EcomLocatorV2.Interfaces;
using EcomLocatorV2.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EcomLocatorV2.Services
{
    public class UsersListApi : IUser
    {
        public async Task<List<User>> GetUsers()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://internshiptaskuserslist.azurewebsites.net/api/users?code=gbgu4CbgdAlsS0xIVaNkckK4vTd0qIFNxaQYzIHLaqyomquJwuy/ig==");
            return JsonConvert.DeserializeObject<Wrapper>(response).Data;
        }
    }
}
