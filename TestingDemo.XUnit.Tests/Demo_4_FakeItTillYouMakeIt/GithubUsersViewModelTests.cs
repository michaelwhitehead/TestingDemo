using System.Threading.Tasks;
using Bogus.Extensions;
using Moq;
using Moq.AutoMock;
using TestingDemo.Demo_4.Api;
using TestingDemo.Demo_4.Models;
using TestingDemo.Demo_4.ViewModels;
using Xunit;

namespace TestingDemo.XUnit.Tests.Demo_4_FakeItTillYouMakeIt
{
    public class GithubUsersViewModelTests
    {
        private AutoMocker Mocker { get; }

        private GithubUsersViewModel Sut { get; }

        public GithubUsersViewModelTests()
        {
            Mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            Sut = Mocker.CreateInstance<GithubUsersViewModel>();
        }

        [Fact]
        public async Task SearchUser_ShouldPopulateList_WhenResponseHasValues()
        {
            // Arrange
            var text = "test";
            Sut.SearchText = text;
            Mocker.GetMock<IGithubApiService>()
                .Setup(c => c.SearchForUser(It.IsAny<string>()))
                .ReturnsAsync(GetFakeUsers());

            // Act
            await Sut.SearchUserCommand.ExecuteAsync();

            // Assert
            Assert.NotEmpty(Sut.Users);
            Mocker.GetMock<IGithubApiService>().Verify(c => c.SearchForUser(text), Times.Once);
        }

        public SearchResponse GetFakeUsers()
        {
            var fakeUser = new Bogus.Faker<GithubUser>()
                .RuleFor(c => c.Name, f => f.Person.UserName)
                .RuleFor(c => c.AvatarUrl, f => f.Image.PicsumUrl(200, 200));

            return new SearchResponse()
            {
                Items = fakeUser.GenerateBetween(5, 10),
            };
        }
    }
}
