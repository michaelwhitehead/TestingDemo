using System.Threading.Tasks;
using TestingDemo.Demo_4.ViewModels;
using TestingDemo.Services.Interfaces;
using Xamarin.CommunityToolkit.ObjectModel;

namespace TestingDemo.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(
            IBaseServices baseServices)
            : base(baseServices)
        {
            Title = "Main";
        }

        public AsyncCommand NavigateToGithubUsersPageCommand => new AsyncCommand(NavigateToGithubUsersPage);

        private Task NavigateToGithubUsersPage()
        {
            return CoreMethods.PushPageModel<GithubUsersViewModel>();
        }
    }
}
