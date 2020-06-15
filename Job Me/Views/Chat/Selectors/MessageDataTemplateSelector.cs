using JobMe.Models.Chat;
using JobMe.Views.Chat.Selectors;
using JobMe.Views.Chat.Templates;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace JobMe.Views.Chat
{
    /// <summary>
    /// Implements the message data template selector class.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class MessageDataTemplateSelector : DataTemplateSelector
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageDataTemplateSelector" /> class.
        /// </summary>
        public MessageDataTemplateSelector()
        {         
            
            this.IncomingTextTemplate = new DataTemplate(typeof(IncomingTextTemplate));
            this.OutgoingTextTemplate = new DataTemplate(typeof(OutgoingTextTemplate));
            this.IncomingImageTemplate = new DataTemplate(typeof(IncomingImageTemplate));
            this.OutgoingImageTemplate = new DataTemplate(typeof(OutgoingImageTemplate));
            this.IncomingFileTemplate = new DataTemplate(typeof(IncomingFileTemplate));
            this.OutgoingFileTemplate = new DataTemplate(typeof(OutgoingFileTemplate));
            this.OutgoingVideoTemplate = new DataTemplate(typeof(OutgoingVideoTemplate));
            this.IncomingVideoTemplate = new DataTemplate(typeof(IncomingVideoTemplate));
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the incoming text template.
        /// </summary>
        public DataTemplate IncomingTextTemplate { get; set; }

        public DataTemplate IncomingVideoTemplate { get; set; }
        public DataTemplate OutgoingVideoTemplate { get; set; }

        public DataTemplate IncomingFileTemplate { get; set; }

        public DataTemplate OutgoingFileTemplate { get; set; }
        /// <summary>
        /// Gets or sets the outgoing text template.
        /// </summary>
        public DataTemplate OutgoingTextTemplate { get; set; }

        /// <summary>
        /// Gets or sets the incoming image template.
        /// </summary>
        public DataTemplate IncomingImageTemplate { get; set; }

        /// <summary>
        /// Gets or sets the outgoing text template.
        /// </summary>
        public DataTemplate OutgoingImageTemplate { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the incoming or outgoing text template.
        /// </summary>
        /// <param name="item">The item</param>
        /// <param name="container">The bindable object</param>
        /// <returns>Returns the data template</returns>
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {

          

            if (((ChatMessage)item).IsReceived)
            {

                if (((ChatMessage)item).IsVideo)
                {
                    this.IncomingVideoTemplate.SetValue(BindableViewCell.ParentBindingContextProperty, container.BindingContext);
                    return this.IncomingVideoTemplate;
                }
                if (((ChatMessage)item).IsFile)
                {
                    this.IncomingFileTemplate.SetValue(BindableViewCell.ParentBindingContextProperty, container.BindingContext);
                    return this.IncomingFileTemplate;
                }
                if (string.IsNullOrEmpty(((ChatMessage)item).ImageUrl))
                {

                    return this.IncomingTextTemplate;

                    //if ((((ChatMessage)item).Message).Length > 2)
                    //{
                    //    if (((((ChatMessage)item).Message).Substring((((ChatMessage)item).Message).Length - 3, 3).ToLower() == "pdf")
                    //        || ((((ChatMessage)item).Message).Substring((((ChatMessage)item).Message).Length - 3, 3).ToLower() == "doc")
                    //        || ((((ChatMessage)item).Message).Substring((((ChatMessage)item).Message).Length - 3, 3).ToLower() == "xls")
                    //        )
                    //    {
                    //        return this.IncomingFileTemplate;
                    //    }
                    //    else
                    //    {
                    //        return this.IncomingTextTemplate;
                    //    }
                    //}
                    //else
                    //{
                    //    return this.IncomingTextTemplate;
                    //}

                    // return this.IncomingImageTemplate;

                }
                else
                {
                    this.IncomingImageTemplate.SetValue(BindableViewCell.ParentBindingContextProperty, container.BindingContext);
                    return this.IncomingImageTemplate;
                }


            }

            else
            {

                if (((ChatMessage)item).IsFile)
                {
                    this.OutgoingFileTemplate.SetValue(BindableViewCell.ParentBindingContextProperty, container.BindingContext);
                    return this.OutgoingFileTemplate;

                }
                else if (((ChatMessage)item).IsImage)
                {
                
                    this.OutgoingImageTemplate.SetValue(BindableViewCell.ParentBindingContextProperty, container.BindingContext);

                    if(string.IsNullOrEmpty(((ChatMessage)item).Base64Photo))
                    {
                        ((ChatMessage)item).Base64Photo = ((ChatMessage)item).ImageUrl;
                    }
                    
                    return this.OutgoingImageTemplate;
                }
                else if (((ChatMessage)item).IsVideo)
                {

                    this.OutgoingVideoTemplate.SetValue(BindableViewCell.ParentBindingContextProperty, container.BindingContext);
                    ((ChatMessage)item).Base64Photo = ((ChatMessage)item).ImageUrl;
                    return this.OutgoingVideoTemplate;

                }
                else if (string.IsNullOrEmpty(((ChatMessage)item).Base64Photo))
                {
                    return this.OutgoingTextTemplate;


                }

                else
                {
                    this.OutgoingImageTemplate.SetValue(BindableViewCell.ParentBindingContextProperty, container.BindingContext);
                    return this.OutgoingImageTemplate;
                }
            }
        }

        #endregion
    }
}
