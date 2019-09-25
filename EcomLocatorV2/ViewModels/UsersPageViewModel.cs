using Prism.Mvvm;
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
        private bool _isBusy;
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<User> OrderedUsers { get; set; }
        private ObservableCollection<User> _filteredUsers;
        public INavigationService NavigationService { get; set; }
        private IUserService _userService;
        private ICommand _searchCommand;
        private ICommand _tapCommand;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }

        public ObservableCollection<User> FilteredUsers
        {
            get { return _filteredUsers; }
            set
            {
                _filteredUsers = value;
                RaisePropertyChanged("FilteredUsers");
            }
        }
        
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

        public async void LoadUsers()
        {
            IsBusy = true;
            var users = await _userService.GetUsers();
            foreach (var user in users)
            {
                Users.Add(user);
            }
            OrderUsers();         
            FilteredUsers = OrderedUsers;
            IsBusy = false;
        }

        public void OrderUsers()
        {
            OrderedUsers = new ObservableCollection<User>(Users
                .OrderBy(person => person.FirstName)
                .ThenBy(person => person.LastName));
        }

        public void OnTapped(object tappedUser)
        {
            var navigationParamaters = new NavigationParameters();
            navigationParamaters.Add("userdetail", tappedUser);
            NavigationService.NavigateAsync("UserDetail", navigationParamaters);
        }
    }
}
