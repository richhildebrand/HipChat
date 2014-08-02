using System.Configuration;
using System.Linq;
using System.Net;
using System.Windows;
using HipchatApiV2;
using HipChatWPF.Model;
using System.Windows.Input;

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
            PopulateRooms();
        }

        private void PopulateRooms()
        {
            var roomsResponse = _client.GetAllRooms();
            var rooms = roomsResponse.Items.Select(room => room.Name).ToList();
            Rooms.ItemsSource = rooms;
        }

        private void PopulateUsers()
        {
            var usersResponse = _client.GetAllUsers();
            var users = usersResponse.Items.Select(user => new User(user)).ToList();
            Users.ItemsSource = users;
        }

        private void SendMessage_OnKeyUp(object sender, KeyEventArgs e)
        {
            var accessToken = ConfigurationManager.AppSettings["hipchat_auth_token"];
            var Id = "919511"; //me
            if (e.Key != Key.Enter)
            {
                return; 
            }

            var message = @"https://api.hipchat.com/v2/user/" + Id + "/" + "Hello";

            WebRequest request = WebRequest.Create(message);
            request.Headers.Add("Authorization", accessToken);
            request.Method="Post";
            request.GetResponse();
        }
    }
}
