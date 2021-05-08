using System.Collections.Generic;
using System.Threading.Tasks;
using TestingDemo.Demo_4.Api;
using TestingDemo.Demo_4.Models;
using TestingDemo.Services.Interfaces;
using TestingDemo.ViewModels;
using Xamarin.CommunityToolkit.ObjectModel;

namespace TestingDemo.Demo_4.ViewModels
{
    public class GithubUsersViewModel : BaseViewModel
    {
        private readonly IGithubApiService _githubApiService;

        public GithubUsersViewModel(
            IBaseServices baseServices,
            IGithubApiService githubApiService)
            : base(baseServices)
        {
            Title = "Github Users";
            _githubApiService = githubApiService;
        }

        public IAsyncCommand SearchUserCommand => new AsyncCommand(SearchUser);

        public List<GithubUser> Users { get; set; }

        public string SearchText { get; set; }

        public GithubUser SelectedUser
        {
            get
            {
                return null;
            }

            set
            {
                if (value == null) return;
                SelectedUser = null;
                NavigateToUser(value);
            }
        }

        private async Task SearchUser()
        {
            var response = await _githubApiService.SearchForUser(SearchText);
            Users = response.Items;
        }

        private Task NavigateToUser(GithubUser user)
        {
            return CoreMethods.PushPageModel<GithubUserViewModel>(user);
        }
    }
}
