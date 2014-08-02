using System.Linq;
using System.Windows;
using HipchatApiV2;
using HipChatWPF.Model;

namespace HipChatWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HipchatClient _client;

        public MainWindow()
        {
            _client = new HipchatClient();
            InitializeComponent();
            PopulateUsers();
        }

        private void PopulateUsers()
        {
            var usersResponse = _client.GetAllUsers();
            var users = usersResponse.Items.Select(user => new User(user)).ToList();
            Users.ItemsSource = users;
        }
    }
}
