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
using Prism.Navigation;

namespace EcomLocatorV2.ViewModels
{
    public class UsersPageViewModel : BindableBase
    {
        public ObservableCollection<User> Users { get; set; }
        private ObservableCollection<User> _filteredUsers;
        public ObservableCollection<User> FilteredUsers
        { get { return _filteredUsers; }
            set { _filteredUsers = value;
                RaisePropertyChanged("FilteredUsers");
            }
        }

        public INavigationService NavigationService { get; set; }
        private IUserService _userService;
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
                                                .Where(w => w.FirstName.ToLower()
                                                .Contains(text.ToLower()) 
                                                || w.LastName.ToLower()
                                                .Contains(text.ToLower()))
                                                .ToList());
                    }
                    RaisePropertyChanged("FilteredUsers");
                }));
            }
        }

        public UsersPageViewModel(IUserService users, INavigationService navigationService)
        {
            Users = new ObservableCollection<User>();
            _userService = users;
            LoadUsers();
            NavigationService = navigationService;
        }

        private async void LoadUsers()
        {
            var users = await _userService.GetUsers();
            foreach (var user in users)
            {
                Users.Add(user);
            }

            FilteredUsers = new ObservableCollection<User>(Users.OrderBy(person => person.FirstName));
        }

        private User _selectedUser;

        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                if (_selectedUser != null)
                {
                    var navigationParamaters = new NavigationParameters();
                    navigationParamaters.Add("userdetail", _selectedUser);
                    NavigationService.NavigateAsync("UserDetail", navigationParamaters);
                }
            }
        }

    }
}
