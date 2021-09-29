using MessagerWPFClient.Autorization;
using MessagerWPFClient.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MessagerWPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MessagerClient _messagerClient;
        public MainWindow()
        {
            InitializeComponent();

            AutorizationWindow autorizationWindow = new AutorizationWindow();
            autorizationWindow.ShowDialog();

            Connect();
        }

        private async void SendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            string message = WriteMessageTextBox.Text;
            if(!string.IsNullOrEmpty(message))
            {
                await _messagerClient.Send(message);
                PrintMessage(message, MessageTypes.Output);
                WriteMessageTextBox.Text = string.Empty;
            }
        }

        private void Connect()
        {
            _messagerClient = new MessagerClient("http://localhost:5000/MessengerHub");
            _messagerClient.HubConnection.StartAsync();

            _messagerClient.HubConnection.On<string>(ActionName.Send.ToString(), m => PrintMessage(m, MessageTypes.Input));
        }

        private void PrintMessage(string message, MessageTypes messageTypes)
        {
            MessageBlock messageBox = new MessageBlock(message, messageTypes);
            PrintMessageWrapPanel.Children.Add(messageBox);
        }
    }
}