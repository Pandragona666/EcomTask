using EcomLocatorV2.Interfaces;
using EcomLocatorV2.Model;
using Prism.Mvvm;
using Prism.Navigation;
using System;

namespace EcomLocatorV2.ViewModels
{
    public class UserDetailViewModel : BindableBase, INavigatedAware
    {
        private User _user;
        private UserDetails _userDetails;
        private bool _isBusy;
        private int _userId;
        private IUserDetailsService _userDetailsService;

        public User User
        {
            get { return _user; }
            set { _user = value; }
        }
                
        public UserDetails UserDetails
        {
            get { return _userDetails; }
            set {_userDetails = value;
                RaisePropertyChanged("UserDetails");
            }
        }
        
        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value;
                RaisePropertyChanged();
            }
        }   

        public UserDetailViewModel(IUserDetailsService userDetailsService)
        {            
            _userDetailsService = userDetailsService;          
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            IsBusy = true;
            User = (User)parameters["userdetail"];
            _userId= _user.Id;
            UserDetails = await _userDetailsService.GetUserDetails(_userId);
            IsBusy = false;
        }
    }
}
