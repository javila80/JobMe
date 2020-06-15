using Syncfusion.ListView.XForms;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace JobMe.Behaviors.Chat
{
    /// <summary>
    /// This class extends the behavior of SfListView control to keep the most recent messages in the view when a new message is added.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ChatMessageListViewBehavior : Behavior<SfListView>
    {
        #region Fields

        /// <summary>
        /// Gets or sets the list view.
        /// </summary>
        private SfListView listView;

        #endregion

        #region Overrides

        /// <summary>
        /// Invoked when adding the SfListView to view.
        /// </summary>
        /// <param name="bindable">The SfListView</param>
        protected override void OnAttachedTo(SfListView bindable)
        {
            if (bindable != null)
            {

                this.listView = bindable;
                base.OnAttachedTo(bindable);
                this.listView.Loaded += this.ListView_Loaded;
                this.listView.DataSource.SourceCollectionChanged += this.DataSource_SourceCollectionChanged;
            }
        }



        /// <summary>
        /// Invoked when the list view is detached. 
        /// </summary>
        /// <param name="bindable">The SfListView</param>
        protected override void OnDetachingFrom(SfListView bindable)
        {
            this.listView = null;
            base.OnDetachingFrom(bindable);
        }

        /// <summary>
        /// Invoked when list view data source collection is changed.
        /// </summary>
        /// <param name="sender">The SfListView</param>
        /// <param name="e">Collection changed Event Args</param>
        private void DataSource_SourceCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            listView.IsVisible = false;
            ((LinearLayout)this.listView.LayoutManager).ScrollToRowIndex(
                this.listView.DataSource.DisplayItems.Count - 1, Syncfusion.ListView.XForms.ScrollToPosition.End, true);
            listView.IsVisible = true;
        }

        /// <summary>
        /// Invoked when the list view is loaded.
        /// </summary>
        /// <param name="sender">The SfListView</param>
        /// <param name="e">ListView Loaded Event Args</param>
        private void ListView_Loaded(object sender, ListViewLoadedEventArgs e)
        {
            //ScrollView scrollView = this.listView.Parent as ScrollView;
            //this.listView.HeightRequest = scrollView.Height;

            Device.BeginInvokeOnMainThread(() =>
            {
                listView.IsVisible = false;

                ((LinearLayout)this.listView.LayoutManager).ScrollToRowIndex(
                this.listView.DataSource.DisplayItems.Count - 1, Syncfusion.ListView.XForms.ScrollToPosition.End, true);

                listView.IsVisible = true;
            });

            //((LinearLayout)this.listView.LayoutManager).ScrollToRowIndex(
            //this.listView.DataSource.DisplayItems.Count - 1,  true);

            //(listView.LayoutManager as LinearLayout).ScrollToRowIndex(listView.DataSource.DisplayItems.Count() - 1, true);
        }

        #endregion
    }
}