using EcomLocatorV2.ViewModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcomLocatorV2.Tests
{
    [TestFixture]
    public class UsersPageViewModelTests
    {
        private UsersPageViewModel _usersPageViewModel;
        private Mock<IPageService> _pageService;

        [SetUp]
        public void Setup()
        {
            _usersPageViewModel = new UsersPageViewModel();
        }

        [Test()]
        public void nameInProgress()
        {
            _usersPageViewModel.
        }
    }
}
