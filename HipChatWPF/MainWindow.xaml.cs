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
            PopulateRooms();
        }

        private void PopulateRooms()
        {
            var roomsResponse = _client.GetAllRooms();
            var rooms = roomsResponse.Items.Select(room => room.Name).ToList();
            Rooms.ItemsSource = rooms;
        }
    }
}
