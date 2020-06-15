using Syncfusion.XForms.Chat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace JobMe.ViewModels
{
    class ChatViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Collection of messages in a conversation.
        /// </summary>
        private ObservableCollection<object> messages;

        /// <summary>
        /// Current user of chat.
        /// </summary>
        private Author currentUser;

        public ChatViewModel()
        {
            this.messages = new ObservableCollection<object>();
            this.CurrentUser = new Author() { Name = "Juan" };
            this.GenerateMessages();
        }

        /// <summary>
        /// Gets or sets the collection of messages of a conversation.
        /// </summary>
        public ObservableCollection<object> Messages
        {
            get
            {
                return this.messages;
            }

            set
            {
                this.messages = value;
            }
        }

        /// <summary>
        /// Gets or sets the current user of the message.
        /// </summary>
        public Author CurrentUser
        {
            get
            {
                return this.CurrentUser;
            }
            set
            {
                this.CurrentUser = value;
                RaisePropertyChanged("CurrentAuthor");
            }
        }

        /// <summary>
        /// Property changed handler.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Occurs when property is changed.
        /// </summary>
        /// <param name="propName">changed property name</param>
        public void RaisePropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private void GenerateMessages()
        {
            this.messages.Add(new TextMessage()
            {
                Author = CurrentUser,
                Text = "Hi guys, good morning! I'm very delighted to share with you the news that our team is going to launch a new mobile application.",
                ShowAvatar = true,
            });

            this.messages.Add(new TextMessage()
            {
                Author = new Author() { Name = "Andrea" },
                Text = "Oh! That's great.",
                ShowAvatar = true,
            });

            this.messages.Add(new TextMessage()
            {
                Author = new Author() { Name = "Harrison" },
                Text = "That is good news.",
                ShowAvatar = true,
            });

            this.messages.Add(new TextMessage()
            {
                Author = new Author() { Name = "Margaret" },
                Text = "What kind of application is it and when are we going to launch?",
                ShowAvatar = true,
            });

            this.messages.Add(new TextMessage()
            {
                Author = CurrentUser,
                Text = "A kind of Emergency Broadcast App.",
                ShowAvatar = true,
            });
        }
    }
}
