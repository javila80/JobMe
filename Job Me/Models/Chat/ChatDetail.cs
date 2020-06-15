using System.Collections.Specialized;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace JobMe.Models.Chat
{
    /// <summary>
    /// Model for recent chat
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ChatDetail : BaseCls
    {
        #region Public Properties

        private int _CuentaMensajes;

        public int CuentaMensajes
        {
            get { return _CuentaMensajes; }
            set { _CuentaMensajes = value; OnPropertyChanged(); }
        }

        public int TipoMensaje { get; set; }
        public int IDPosition { get; set; }
        public byte[] Logo { get; set; }
        /// <summary>
        /// Gets or sets the profile image path.
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Gets or sets the profile name.
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// Gets or sets the message sent/received time.
        /// </summary>
      
        private string _Time;

        public string Time
        {
            get { return _Time; }
            set { _Time = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the MessageType.
        /// </summary>
        public string MessageType { get; set; }

        /// <summary>
        /// Gets or sets the message sent/received notification type.
        /// </summary>
        //public string NotificationType { get; set; }

        private string _NotificationType;


        private bool _ContadorVisible = false;

        public bool ContadorVisible
        {
            get { return _ContadorVisible ; }
            set { _ContadorVisible =  value; OnPropertyChanged(); }
        }


        public string NotificationType
        {
            get { return _NotificationType; }
            set { _NotificationType = value;  OnPropertyChanged();   }
        }


        /// <summary>
        /// Gets or sets the recipient's available status.
        /// </summary>
        public string AvailableStatus { get; set; }

        public string PositionName { get; set; }

        public int UserID { get; set; }

        public int ContactID { get; set; }

        #endregion
    }
}
