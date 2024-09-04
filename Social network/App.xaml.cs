using Social_network.Models;

namespace Social_network
{
    public partial class App : Application
    {
        public static UserInfo userInfo;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
