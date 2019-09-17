using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using EcomLocatorV2.Model;
using EcomLocatorV2.Interfaces;

namespace EcomLocatorV2.ViewModels
{
    public class UsersPageViewModel : BindableBase
    {
        public ObservableCollection<User> Users { get; set; }
        private IUser _users;

        public UsersPageViewModel(IUser users)
        {
            Users = new ObservableCollection<User>();
            _users = users;
            LoadUsers();
        }

        private async void LoadUsers()
        {
            var users = await _users.GetUsers();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }
    }
}
