using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Windows;
using HipchatApiV2;
using HipchatApiV2.Responses;
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
            var rooms = roomsResponse.Items.ToList();
            var observableRooms = new ObservableCollection<HipchatGetAllRoomsResponseItems>();

            foreach (var room in rooms)
            {
                observableRooms.Add(room);
            }

            Rooms.ItemsSource = observableRooms;
        }
    }
}
