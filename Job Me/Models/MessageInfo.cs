using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace JobMe.Models
{
    [Preserve(AllMembers = true)]
    public class MessageInfo : INotifyPropertyChanged
    {
        #region Fields

        private string text;
        private ImageSource profileImage, image;
        private String dateTime;
        private string username;
        private ImageSource incomingMessageIndicator, outgoingMessageIndicator;

        #endregion

        #region Properties
        public ImageSource IncomingMessageIndicator
        {
            get { return incomingMessageIndicator; }
            set
            {
                incomingMessageIndicator = value;
                OnPropertyChanged("IncomingMessageIndicator");
            }
        }

        public ImageSource OutgoingMessageIndicator
        {
            get { return outgoingMessageIndicator; }
            set
            {
                outgoingMessageIndicator = value;
                OnPropertyChanged("OutgoingMessageIndicator");
            }
        }

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }

        public ImageSource ProfileImage
        {
            get { return profileImage; }
            set
            {
                profileImage = value;
                OnPropertyChanged("ProfileImage");
            }
        }

        public String DateTime
        {
            get { return dateTime; }
            set
            {
                dateTime = value;
                OnPropertyChanged("DateTime");
            }
        }

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }

        public TemplateType TemplateType
        {
            get;
            set;
        }

        public ImageSource Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }

        #endregion

        #region Constructor
        public MessageInfo()
        {

        }

        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string Property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
            }
        }

        #endregion
    }
}
