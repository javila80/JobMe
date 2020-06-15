using JobMe.Models;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace JobMe
{
    [Preserve(AllMembers = true)]
    class ViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<MessageInfo> messageInfo;
        private string newText;
        internal Syncfusion.ListView.XForms.SfListView ListView;
        private ImageSource sendIcon;

        #endregion

        #region Properties
        public ObservableCollection<MessageInfo> MessageInfo
        {
            get { return messageInfo; }
            set { this.messageInfo = value; }
        }

        public string NewText
        {
            get { return newText; }
            set
            {
                newText = value;
                OnPropertyChanged("NewText");
            }
        }

        public ImageSource SendIcon
        {
            get
            { return sendIcon; }
            set
            { sendIcon = value; }
        }

        public ICommand SendCommand { get; set; }

        #endregion

        #region Interface

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion Interface

        #region Constructor
        public ViewModel()
        {
            InitializeSendCommand();
            GenerateSource();
        }

        #endregion

        #region GenerateSource
        public void GenerateSource()
        {
            MessageInfoRepository Message = new MessageInfoRepository();
            MessageInfo = Message.GenerateInfo();
        }

        #endregion

        #region InitializeCommand
        private void InitializeSendCommand()
        {
            Assembly assembly = typeof(DataTemplateSelector).GetTypeInfo().Assembly;
#if COMMONSB
            SendIcon = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.SendIcon.png", assembly);
#else
            SendIcon = ImageSource.FromResource("SendIcon.png", assembly);
#endif
            NewText = "";
            SendCommand = new Command(() =>
            {
                if (!string.IsNullOrWhiteSpace(NewText))
                {
                    MessageInfo.Add(new MessageInfo
                    {
#if COMMONSB
                        OutgoingMessageIndicator = ImageSource.FromResource("SampleBrowser.Icons.DataTemplateSelector.OutgoingIndicatorImage.png", assembly),
#else
                        OutgoingMessageIndicator = ImageSource.FromResource("SampleBrowser.SfListView.Icons.DataTemplateSelector.OutgoingIndicatorImage.png", assembly),
#endif
                        Text = NewText,
                        TemplateType = TemplateType.OutGoingText,
                        DateTime = string.Format("{0:HH:mm}", DateTime.Now)
                    });
                    (ListView.LayoutManager as LinearLayout).ScrollToRowIndex(MessageInfo.Count - 1, Syncfusion.ListView.XForms.ScrollToPosition.Start);
                }
                NewText = null;
            });
        }

        #endregion
    }

    [Preserve(AllMembers = true)]
    public class SortingFilteringViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ListViewSortOptions sortingOptions;

        #endregion

        #region Constructor
        public SortingFilteringViewModel()
        {
            AddItemDetails();
        }

        #endregion

        #region Properties

        public ObservableCollection<TaskInfo> Items
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value whether indicates the sorting options, ascending or descending or none.
        /// </summary>
        public ListViewSortOptions SortingOptions
        {
            get
            {
                return sortingOptions;
            }
            set
            {
                sortingOptions = value;
                OnPropertyChanged("SortingOptions");
            }
        }

        #endregion

        #region Methods
        private void AddItemDetails()
        {
            Items = new ObservableCollection<TaskInfo>();
            var random = new Random();

            for (int i = 0; i < Features.Count(); i++)
            {
                var details = new TaskInfo()
                {
                    Title = Features[i],
                    Description = Description[i],
                    Tag = Tags[random.Next(0, 4)],
                };
                Items.Add(details);
            }
        }

        string[] Tags = new string[]
        {
             "Drag and drop",
            "Swiping",
            "Pull To Refresh",
            "Selection in row header",

        };

        string[] Features = new string[]
        {
           
                 "Financial",
            "Business Analyst",
            "Tax Manager",
            "Service Associate",

        };

        string[] Description = new string[] {
            "Rearrange the columns by dragging and dropping them",
            "Enables the users to swipe",
            "Pull To Refresh action refreshes the grid",
            "Apply selection using row header",
            "Apply different selection colors for different rows",
            "Add an animation upon selecting a row",
            "Users can listen to LongPresses in the listview",
            "Users can listen to double taps in the listview",
            "Load custom views as templates in header cells",
            "Orientation are vertical, horizontal",
            "Displays multi-line text for the record",
            
        };

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }

    public enum ListViewSortOptions
    {
        None,
        Ascending,
        Descending
    }
}
