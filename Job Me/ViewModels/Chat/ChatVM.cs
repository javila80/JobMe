using JobMe.Models.Chat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace JobMe.ViewModels.Chat
{
    public class ChatVM : INotifyPropertyChanged
    {
        #region Event handler

        /// <summary>
        /// Occurs when the property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">The PropertyName</param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
        #region Fields

        /// <summary>
        /// Stores the message text in an array. 
        /// </summary>
        private readonly string[] descriptions = { "Hi, can you tell me the specifications of the Dell Inspiron 5370 laptop?",
            " * Processor: Intel Core i5-8250U processor " +
            "\n" + " * OS: Pre-loaded Windows 10 with lifetime validity" +
            "\n" + " * Display: 13.3-inch FHD (1920 x 1080) LED display" +
            "\n" + " * Memory: 8GB DDR RAM with Intel UHD 620 Graphics" +
            "\n" + " * Battery: Lithium battery",
            "How much battery life does it have with wifi and without?",
            "Approximately 5 hours with wifi. About 7 hours without.",
        };

        private string profileName = "Alex Russell";

        private string newMessage;

        private string profileImage =  "ProfileImage3.png";

        private ObservableCollection<ChatMessage> chatMessageInfo = new ObservableCollection<ChatMessage>();

        #endregion
        public ChatVM()
        {
         
            this.SendCommand = new Command(this.SendClicked);
           
            this.GenerateMessageInfo();

        }

        private void SendClicked(object obj)
        {
            if (!string.IsNullOrWhiteSpace(this.NewMessage))
            {
                this.ChatMessageInfo.Add(new ChatMessage
                {
                    Message = this.NewMessage,
                    Time = DateTime.Now
                });
            }

            this.NewMessage = null;
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets the profile name.
        /// </summary>
        public string ProfileName
        {
            get
            {
                return this.profileName;
            }

            set
            {
                this.profileName = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the profile image.
        /// </summary>
        public string ProfileImage
        {
            get
            {
                return this.profileImage;
            }

            set
            {
                this.profileImage = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a collection of chat messages.
        /// </summary>
        public ObservableCollection<ChatMessage> ChatMessageInfo
        {
            get
            {
                return this.chatMessageInfo;
            }

            set
            {
                this.chatMessageInfo = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a new message.
        /// </summary>
        public string NewMessage
        {
            get
            {
                return this.newMessage;
            }

            set
            {
                this.newMessage = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the command that is executed when the profile name is clicked.
        /// </summary>
        public Command ProfileCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the voice call button is clicked.
        /// </summary>
        public Command MakeVoiceCall { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the video call button is clicked.
        /// </summary>
        public Command MakeVideoCall { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the menu button is clicked.
        /// </summary>
        public Command MenuCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the camera button is clicked.
        /// </summary>
        public Command ShowCamera { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the attachment button is clicked.
        /// </summary>
        public Command SendAttachment { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the send button is clicked.
        /// </summary>
        public Command SendCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the back button is clicked.
        /// </summary>
        public Command BackCommand { get; set; }

        #endregion

        private void GenerateMessageInfo()
        {
            var currentTime = DateTime.Now;
            this.ChatMessageInfo = new ObservableCollection<ChatMessage>
            {
                new ChatMessage
                {
                    Message = this.descriptions[0],
                    Time = currentTime.AddMinutes(-2517),
                    IsReceived = true,
                },
                new ChatMessage
                {
                    Message = this.descriptions[1],
                    Time = currentTime.AddMinutes(-2408),
                },
                new ChatMessage
                {
                    ImagePath = "Electronics.png",
                    Time = currentTime.AddMinutes(-2405),
                },
                new ChatMessage
                {
                    Message = this.descriptions[2],
                    Time = currentTime.AddMinutes(-1103),
                    IsReceived = true,
                },
                new ChatMessage
                {
                    Message = this.descriptions[3],
                    Time = currentTime.AddMinutes(-1006),
                },
                  new ChatMessage
                {
                    Message = this.descriptions[1],
                    Time = currentTime.AddMinutes(-2408),
                },
                new ChatMessage
                {
                    ImagePath =  "Electronics.png",
                    Time = currentTime.AddMinutes(-2405),
                },
                new ChatMessage
                {
                    Message = this.descriptions[2],
                    Time = currentTime.AddMinutes(-1103),
                    IsReceived = true,
                },
                new ChatMessage
                {
                    Message = this.descriptions[3],
                    Time = currentTime.AddMinutes(-1006),
                },
                  new ChatMessage
                {
                    Message = this.descriptions[1],
                    Time = currentTime.AddMinutes(-2408),
                },
                new ChatMessage
                {
                    ImagePath =  "Electronics.png",
                    Time = currentTime.AddMinutes(-2405),
                },
                new ChatMessage
                {
                    Message = this.descriptions[2],
                    Time = currentTime.AddMinutes(-1103),
                    IsReceived = true,
                },
                new ChatMessage
                {
                    Message = this.descriptions[3],
                    Time = currentTime.AddMinutes(-1006),
                },
                  new ChatMessage
                {
                    Message = this.descriptions[1],
                    Time = currentTime.AddMinutes(-2408),
                },
                new ChatMessage
                {
                    ImagePath =  "Electronics.png",
                    Time = currentTime.AddMinutes(-2405),
                },
                new ChatMessage
                {
                    Message = this.descriptions[2],
                    Time = currentTime.AddMinutes(-1103),
                    IsReceived = true,
                },
                new ChatMessage
                {
                    Message = this.descriptions[3],
                    Time = currentTime.AddMinutes(-1006),
                },
                  new ChatMessage
                {
                    Message = this.descriptions[1],
                    Time = currentTime.AddMinutes(-2408),
                },
                new ChatMessage
                {
                    ImagePath =  "Electronics.png",
                    Time = currentTime.AddMinutes(-2405),
                },
                new ChatMessage
                {
                    Message = this.descriptions[2],
                    Time = currentTime.AddMinutes(-1103),
                    IsReceived = true,
                },
                new ChatMessage
                {
                    Message = this.descriptions[3],
                    Time = currentTime.AddMinutes(-1006),
                },
                  new ChatMessage
                {
                    Message = this.descriptions[1],
                    Time = currentTime.AddMinutes(-2408),
                },
                new ChatMessage
                {
                    ImagePath =  "Electronics.png",
                    Time = currentTime.AddMinutes(-2405),
                    IsReceived = true,
                },
                new ChatMessage
                {
                    Message = this.descriptions[2],
                    Time = currentTime.AddMinutes(-1103),
                    IsReceived = true,
                },
                new ChatMessage
                {
                    Message = this.descriptions[3],
                    Time = currentTime.AddMinutes(-1006),
                },
            };
        }
    }
}
