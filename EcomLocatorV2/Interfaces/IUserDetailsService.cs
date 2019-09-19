using EcomLocatorV2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcomLocatorV2.Interfaces
{
    public interface IUserDetailsService
    {
        Task<UserDetails> GetUserDetails(int UserId);

    }
}
