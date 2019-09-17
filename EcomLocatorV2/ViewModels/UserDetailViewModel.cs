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
        private User user;
        private string _userFirstName;

        public string UserFirstName
        {
            get { return _userFirstName; }
            set { SetProperty(ref _userFirstName , value); }
        }

        private string _userLastName;

        public string UserLastName
        {
            get { return _userLastName; }
            set { SetProperty(ref _userLastName , value); }
        }

        public UserDetailViewModel()
        {

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            user = (User)parameters["userdetail"];
            UserFirstName = user.FirstName;
            UserLastName = user.LastName;
        }
    }
}
