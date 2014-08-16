using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows;
using HipchatApiV2;
using HipchatApiV2.Responses;
using System.Timers;
using HipChatWPF.Models;

namespace HipChatWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HipchatClient _client;
        private ObservableCollection<Room> _observableRooms;
        private const int OneSecond = 1000;
        private const int NotifyEveryNSeconds = 5;
        private const int NotifyEvery = NotifyEveryNSeconds * OneSecond;

        public MainWindow()
        {
            _client = new HipchatClient();
            InitializeComponent();
            PopulateRooms();
            PollNotifications();
        }

        private void PollNotifications()
        {
            var notificationTimer = new System.Timers.Timer(NotifyEvery);
            notificationTimer.Elapsed += NotifyUser;
            notificationTimer.Start();
        }

        private void NotifyUser(object sender, ElapsedEventArgs e)
        {
            var shouldNotifyUser = _observableRooms.Any(room => room.ShouldSendNotification);

            if (shouldNotifyUser)
            {
                System.Media.SystemSounds.Exclamation.Play();
            }
        }

        private void PopulateRooms()
        {
            var roomsResponse = _client.GetAllRooms();
            var rooms = roomsResponse.Items.ToList();
            _observableRooms = new ObservableCollection<Room>();

            foreach (var roomResponse in rooms)
            {
                var room = new Room { Name = roomResponse.Name };
                _observableRooms.Add(room);
            }

            Rooms.ItemsSource = _observableRooms;
        }
    }
}
