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
using System.Threading.Tasks;

namespace EcomLocatorV2.ViewModels
{
    public class UsersPageViewModel : BindableBase
    {
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<User> OrderedUsers { get; set; }
        private ObservableCollection<User> _filteredUsers;
        public ObservableCollection<User> FilteredUsers
        { get { return _filteredUsers; }
            set { _filteredUsers = value;
                RaisePropertyChanged("FilteredUsers");
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value;
                RaisePropertyChanged();
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
                        FilteredUsers = OrderedUsers;
                    }
                    else
                    {
                        FilteredUsers = new ObservableCollection<User>(OrderedUsers
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

        private ICommand _tapCommand;

        public ICommand TapCommand
        {
            get { return _tapCommand; }
            set { _tapCommand = value; }
        }


        public UsersPageViewModel(IUserService users, INavigationService navigationService)
        {
            NavigationService = navigationService;
            Users = new ObservableCollection<User>();
            _userService = users;
            LoadUsers();
            TapCommand = new Command(OnTapped);
        }

        private async void LoadUsers()
        {
            IsBusy = true;
            var users = await _userService.GetUsers();
            foreach (var user in users)
            {
                Users.Add(user);
            }
            OrderedUsers = new ObservableCollection<User>(Users.OrderBy(person => person.FirstName));

            FilteredUsers = OrderedUsers;
            IsBusy = false;
        }

        private User _selectedUser;

        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                /*if (_selectedUser != null)
                {
                    var navigationParamaters = new NavigationParameters();
                    navigationParamaters.Add("userdetail", _selectedUser);
                    NavigationService.NavigateAsync("UserDetail", navigationParamaters);
                }*/
            }
        }

        public void OnTapped(object SelectedUser)
        {
            var navigationParamaters = new NavigationParameters();
            navigationParamaters.Add("userdetail", SelectedUser);
            NavigationService.NavigateAsync("UderDetail", navigationParamaters);
        }

    }
}
