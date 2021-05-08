using FreshMvvm;
using TestingDemo.ViewModels;
using Xamarin.Forms;

namespace TestingDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Registration.RegisterDependencies();

            MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<MainViewModel>());
        }
    }
}
