
namespace KursyWalut
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
        }
        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window();
            window.MinimumHeight = 800;
            window.MaximumHeight = 800;
            window.MinimumWidth = 500;
            window.MaximumWidth = 500;
            window.Title = "Kursy walut";
            window.Page = new AppShell();
            return window;
        }
    }
}
