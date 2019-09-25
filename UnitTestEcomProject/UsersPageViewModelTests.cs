using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using EcomLocatorV2.Interfaces;
using EcomLocatorV2.Model;
using EcomLocatorV2.Services;
using EcomLocatorV2.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Prism.Navigation;
using Assert = NUnit.Framework.Assert;

namespace UnitTestEcomProject
{
    public class UsersPageViewModelTests
    {
        private UsersPageViewModel _usersPageViewModel;
        private Mock<INavigationService> _navigationService;
        private Mock<IUserService> mockUsersListApi;
        
        [SetUp]
        public void Setup()
        {
            var listOfUsers = new List<User>();
            listOfUsers.Add(new User { Id = 1, FirstName = "Sueann", LastName = "Delgadillo" });
            listOfUsers.Add(new User { Id = 2, FirstName = "Julianna", LastName = "Soloman" });
            listOfUsers.Add(new User { Id = 3, FirstName = "Justine", LastName = "Masten" });
            listOfUsers.Add(new User { Id = 4, FirstName = "Lamont", LastName = "Kalina" });
            listOfUsers.Add(new User { Id = 5, FirstName = "Jolene", LastName = "Barbara" });
            listOfUsers.Add(new User { Id = 6, FirstName = "Noemi", LastName = "Tune" });
            listOfUsers.Add(new User { Id = 7, FirstName = "Tien", LastName = "Gilcrease" });
            listOfUsers.Add(new User { Id = 8, FirstName = "Julianna", LastName = "Kinyon" });
            _navigationService = new Mock<INavigationService>();
            mockUsersListApi = new Mock<IUserService>();
            mockUsersListApi.Setup(x => x.GetUsers()).Returns(Task.FromResult(listOfUsers));
            _usersPageViewModel = new UsersPageViewModel(mockUsersListApi.Object, _navigationService.Object);
        }

        [Test]
        public void testSearchingMethod()
        {
            //_usersPageViewModel.LoadUsers();
            _usersPageViewModel.SearchCommand.Execute("Juli");
            Assert.IsNotNull(_usersPageViewModel.FilteredUsers);
            Assert.AreEqual(2, _usersPageViewModel.FilteredUsers.Count);
            Assert.IsTrue(_usersPageViewModel.FilteredUsers.Any(user => user.FirstName == "Julianna"));
        }
    }
}
