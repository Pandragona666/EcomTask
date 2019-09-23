using EcomLocatorV2.Interfaces;
using EcomLocatorV2.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EcomLocatorV2.ViewModels
{
    public class UserDetailViewModel : BindableBase, INavigatedAware
    {
        private User _user;
        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        private UserDetails _userDetails;
        public UserDetails UserDetails
        {
            get { return _userDetails; }
            set {_userDetails = value;
                RaisePropertyChanged("UserDetails");
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

        private int _userId;
        private IUserDetailsService _userDetailsService;

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
