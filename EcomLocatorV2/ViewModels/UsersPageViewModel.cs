using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using EcomLocatorV2.Model;
using EcomLocatorV2.Interfaces;
using System.Windows.Input;
using Xamarin.Forms;

namespace EcomLocatorV2.ViewModels
{
    public class UsersPageViewModel : BindableBase
    {
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<User> FilteredUsers { get; set; }
        private IUserService _userService;
        private string _searchText;
        private ICommand _searchCommand;

        [Obsolete]
        public ICommand SearchCommand
        {
            get
            {
                return _searchCommand ?? (_searchCommand = new Command<string>((text) =>
                {
                    if(text == null)
                    {
                        FilteredUsers = Users;
                    }
                    else
                    {
                        FilteredUsers = new ObservableCollection<User>(Users
                                                .Where(w => w.FirstName.ToLower().Contains(text.ToLower()) || w.LastName.ToLower().Contains(text.ToLower()))
                                                .ToList());
                    }
                    RaisePropertyChanged("FilteredUsers");
                }));
            }
        }

        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; }
        }



        public UsersPageViewModel(IUserService users)
        {
            Users = new ObservableCollection<User>();
            _userService = users;
            LoadUsers();
            FilteredUsers = Users;
        }

        private async void LoadUsers()
        {
            var users = await _userService.GetUsers();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }
    }
}
