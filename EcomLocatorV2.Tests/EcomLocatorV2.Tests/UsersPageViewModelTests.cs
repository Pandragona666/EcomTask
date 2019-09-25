using EcomLocatorV2.Interfaces;
using EcomLocatorV2.ViewModels;
using Moq;
using NUnit.Framework;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcomLocatorV2.Tests
{
    [TestFixture]
    public class UsersPageViewModelTests
    {
        private UsersPageViewModel _usersPageViewModel;
        private Mock<INavigationService> _navigationService;
        private IUserService _userService;

        [SetUp]
        public void Setup()
        {
            _navigationService = new Mock<INavigationService>();
            _usersPageViewModel = new UsersPageViewModel(_userService, _navigationService.Object);
        }

        [Test()]
        public void nameInProgress()
        {
            _usersPageViewModel.SearchCommand.Execute("en");
            Assert.AreEqual(6, _usersPageViewModel.FilteredUsers.Count);
        }
    }
}
