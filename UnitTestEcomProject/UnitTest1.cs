using System;
using EcomLocatorV2.Interfaces;
using EcomLocatorV2.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Prism.Navigation;
using Assert = NUnit.Framework.Assert;

namespace UnitTestEcomProject
{
    [TestFixture]
    public class UsersPageViewModelTests
    {
        private UsersPageViewModel _usersPageViewModel;
        private Mock<INavigationService> _navigationService;
        private Mock<IUserService> _userService;

        [SetUp]
        public void Setup()
        {
            _navigationService = new Mock<INavigationService>();
            _usersPageViewModel = new UsersPageViewModel(_userService.Object, _navigationService.Object);
        }

        [Test()]
        public void nameInProgress()
        {
            _usersPageViewModel.SearchCommand.Execute("en");
            Assert.AreEqual(6, _usersPageViewModel.FilteredUsers.Count);
        }
    }
}
