using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MessagerWPFClient.Models
{
    public class MessageBlock : GroupBox
    {
        private TextBlock _messageTextBlock;

        public MessageBlock()
        {
            Configure();
        }

        public MessageBlock(string message, MessageTypes messageType)
        {
            Configure();
            _messageTextBlock.Text = message;
            switch(messageType)
            {
                case MessageTypes.Input:
                    HorizontalAlignment = HorizontalAlignment.Left;
                    _messageTextBlock.Background = Brushes.White;
                    break;

                case MessageTypes.Output:
                    HorizontalAlignment = HorizontalAlignment.Right;
                    _messageTextBlock.Background = new SolidColorBrush(Color.FromArgb(100, 194, 212, 212));
                    break;
            }
        }

        private void Configure()
        {
            Header = DateTime.Now;

            MinHeight = 50;
            MinWidth = 50;
            Margin = new Thickness(1);

            BorderThickness = new Thickness(2);
            BorderBrush = Brushes.Black;
            Background = new SolidColorBrush(Color.FromArgb(100, 194, 212, 212));

            _messageTextBlock = new TextBlock();
            _messageTextBlock.Background = new SolidColorBrush(Color.FromArgb(100, 194, 212, 212));
            _messageTextBlock.Text = "Text";
            _messageTextBlock.TextWrapping = TextWrapping.Wrap;

            AddChild(_messageTextBlock);
        }
    }
}
