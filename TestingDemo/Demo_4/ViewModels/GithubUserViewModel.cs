using TestingDemo.Demo_4.Models;
using TestingDemo.Services.Interfaces;
using TestingDemo.ViewModels;

namespace TestingDemo.Demo_4.ViewModels
{
    public class GithubUserViewModel : BaseViewModel
    {
        public GithubUserViewModel(IBaseServices baseServices)
            : base(baseServices)
        {
        }

        public GithubUser User { get; set; }

        public override void Init(object initData)
        {
            base.Init(initData);

            if (initData is GithubUser user)
            {
                User = user;
            }
        }
    }
}
