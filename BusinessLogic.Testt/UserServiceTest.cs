using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using System;
using System.Linq.Expressions;
using System.Numerics;

namespace BuisnessLogic.Tests
{
    public class UserServiceTest
    {

        public readonly UserService service;
        private readonly Mock<IUserRepository> repMoq;

        public UserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            repMoq = new Mock<IUserRepository>();

            repositoryWrapperMoq.Setup(x => x.User)
                .Returns(repMoq.Object);

            service = new UserService(repositoryWrapperMoq.Object);
        }


        public static IEnumerable<object[]> GetIncorrectUser()
        {
            return new List<object[]>
            {
                new object[] {new User { Email = "", UserPassword = "", Username = "" } },
                new object[] {new User { Email = "email@email.com", UserPassword = "", Username = "Nick" } },
                new object[] {new User { Email = "", UserPassword = "12345pass", Username = "Nick" } },
                new object[] {new User { Email = "email@email.com", UserPassword = "12345pass", Username = "" } },
            };
        }


        [Fact]
        public async void CreateAsync_NullUser_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
        }
