using EcomLocatorV2.Interfaces;
using EcomLocatorV2.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EcomLocatorV2.Services
{
    public class UsersListApi : IUserService
    {
        private const string SERVER_NAME = "https://internshiptaskuserslist.azurewebsites.net/api/users";
        private const string KEY = "code=gbgu4CbgdAlsS0xIVaNkckK4vTd0qIFNxaQYzIHLaqyomquJwuy/ig==";
        public async Task<List<User>> GetUsers()
        {
            var httpClient = new HttpClient();
            string fullQueryAddress = $"{SERVER_NAME}?{KEY}";
            var response = await httpClient.GetStringAsync(fullQueryAddress);
            return JsonConvert.DeserializeObject<Wrapper>(response).Data;
        }
    }
}
