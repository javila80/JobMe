using System;
using System.ComponentModel;
using Xamarin.Forms.Internals;

namespace JobMe.Models.Chat
{
    /// <summary>
    /// Model for chat message 
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ChatMessage : INotifyPropertyChanged
    {
        #region Fields
        private string _Sender;

        public string Sender
        {
            get { return _Sender; }
            set { _Sender = value; OnPropertyChanged("Sender"); }
        }


        private bool _isfile;

        public bool IsFile
        {
            get { return _isfile; }
            set { _isfile = value; OnPropertyChanged("IsFile"); }
        }

        private int _IDPosition;

        public int IDPosition
        {
            get { return _IDPosition; }
            set { _IDPosition = value; OnPropertyChanged("IDPosition"); }
        }

        private string _ImageUrl;
        public string ImageUrl
        {
            get { return _ImageUrl; }
            set { _ImageUrl = value; OnPropertyChanged("ImageUrl"); }
        }

        private string _VideoUrl;

        public string VideoUrl
        {
            get { return _VideoUrl; }
            set { _VideoUrl = value; OnPropertyChanged("VideoUrl"); }
        }

        private bool _IsImage;

        public bool IsImage
        {
            get { return _IsImage; }
            set { _IsImage = value; OnPropertyChanged("IsImage"); }
        }
        

        private string message;

        private DateTime time;

        private string imagePath;

        private int _UserID;

        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; OnPropertyChanged("UserID"); }
        }

        private int _ContactID;

        public int ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; OnPropertyChanged("ContactID"); }
        }

        private bool _IsVideo;

        public bool IsVideo
        {
            get { return _IsVideo; }
            set { _IsVideo = value; OnPropertyChanged("IsVideo"); }
        }


        public string Base64Photo { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// The declaration of property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message
        {
            get
            {
                return this.message;
            }

            set
            {
                this.message = value;
                this.OnPropertyChanged("Message");
            }
        }

        /// <summary>
        /// Gets or sets the message sent/received time.
        /// </summary>
        public DateTime Time
        {
            get
            {
                return this.time;
            }

            set
            {
                this.time = value;
                this.OnPropertyChanged("Time");
            }
        }

        /// <summary>
        /// Gets or sets the profile image.
        /// </summary>
        public string ImagePath
        {
            get
            {
                return this.imagePath;
            }

            set
            {
                this.imagePath = value;
                this.OnPropertyChanged("ImagePath");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the message is received or sent.
        /// </summary>
        public bool IsReceived { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when property value is changed.
        /// </summary>
        /// <param name="property">property name</param>
        protected void OnPropertyChanged(string property)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        #endregion
    }
}
