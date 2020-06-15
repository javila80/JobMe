using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Syncfusion.ListView.XForms;
using Syncfusion.DataSource;

namespace JobMe
{
    [Preserve(AllMembers = true)]

    #region DataTemplateSelectorBehavior

    public class DataTemplateSelectorBehavior : Behavior<Syncfusion.ListView.XForms.SfListView>
    {
        #region Fields

        private ViewModel DataTemplateSelectorViewModel;
        private Syncfusion.ListView.XForms.SfListView ListView;
        private ScrollView scrollView;

        #endregion

        #region Overrides
        protected override void OnAttachedTo(Syncfusion.ListView.XForms.SfListView bindable)
        {
            ListView = bindable;
            base.OnAttachedTo(bindable);
            DataTemplateSelectorViewModel = new ViewModel();
            DataTemplateSelectorViewModel.ListView = ListView;
            ListView.BindingContext = DataTemplateSelectorViewModel;
            ListView.ItemsSource = DataTemplateSelectorViewModel.MessageInfo;
            ListView.Loaded += ListView_Loaded;
        }

        private void ListView_Loaded(object sender, ListViewLoadedEventArgs e)
        {
            scrollView = ListView.Parent as ScrollView;
            ListView.HeightRequest = scrollView.Height;

            if (Device.RuntimePlatform == Device.macOS)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ListView.ScrollTo(2500);
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    (ListView.LayoutManager as LinearLayout).ScrollToRowIndex(DataTemplateSelectorViewModel.MessageInfo.Count - 1, Syncfusion.ListView.XForms.ScrollToPosition.Start);
                });
            }
        }

        protected override void OnDetachingFrom(Syncfusion.ListView.XForms.SfListView bindable)
        {
            ListView = null;
            base.OnDetachingFrom(bindable);
        }

        #endregion

    }

    #endregion

    [Preserve(AllMembers = true)]
    #region SortingFilteringBehavior

    public class SfListViewSortingFilteringBehavior : Behavior<ContentPage>
    {
        #region Fields

        private Syncfusion.ListView.XForms.SfListView ListView;
        private SortingFilteringViewModel sortingFilteringViewModel;
        //private Grid sortImageParent;
        private Label titleLabel;
        private SearchBar searchBar = null;
        private Grid headerGrid;
        private Grid seachbar_Grid;

        #endregion

        #region Overrides
        protected override void OnAttachedTo(ContentPage bindable)
        {
            ListView = bindable.FindByName<Syncfusion.ListView.XForms.SfListView>("listView");
            sortingFilteringViewModel = new SortingFilteringViewModel();
            ListView.BindingContext = sortingFilteringViewModel;
            ListView.ItemsSource = sortingFilteringViewModel.Items;

            headerGrid = bindable.FindByName<Grid>("headerGrid");
            headerGrid.BindingContext = sortingFilteringViewModel;

            seachbar_Grid = bindable.FindByName<Grid>("seachbar_Grid");
            if (Device.RuntimePlatform == Device.UWP)
                seachbar_Grid.Padding = new Thickness(5, 5, 0, 5);

            //sortImageParent = bindable.FindByName<Grid>("sortImageParent");
            //var SortImageTapped = new TapGestureRecognizer() { Command = new Command(SortImageTapped_Tapped) };
            //sortImageParent.GestureRecognizers.Add(SortImageTapped);

            //if (Device.RuntimePlatform == Device.iOS)
            //    sortImageParent.BackgroundColor = Color.FromHex("#C9C8CE");
            //else if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.UWP)
            //    sortImageParent.BackgroundColor = Color.FromHex("#E4E4E4");

            searchBar = bindable.FindByName<SearchBar>("filterText");
            if (Device.RuntimePlatform == Device.macOS)
                searchBar.PlaceholderColor = Color.Transparent;

            searchBar.TextChanged += SearchBar_TextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            ListView = null;
            //sortImageParent = null;
            searchBar = null;
            searchBar.TextChanged -= SearchBar_TextChanged;
            base.OnDetachingFrom(bindable);
        }

        #endregion

        #region Events

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchBar = (sender as SearchBar);
            if (ListView.DataSource != null)
            {
                ListView.DataSource.Filter = FilterContacts;
                ListView.DataSource.RefreshFilter();
            }
            ListView.RefreshView();
        }
        private void SortImageTapped_Tapped()
        {
            if (sortingFilteringViewModel.SortingOptions == ListViewSortOptions.Descending)
                sortingFilteringViewModel.SortingOptions = ListViewSortOptions.None;
            else if (sortingFilteringViewModel.SortingOptions == ListViewSortOptions.None)
                sortingFilteringViewModel.SortingOptions = ListViewSortOptions.Ascending;
            else if (sortingFilteringViewModel.SortingOptions == ListViewSortOptions.Ascending)
                sortingFilteringViewModel.SortingOptions = ListViewSortOptions.Descending;

            ListView.DataSource.SortDescriptors.Clear();
            if (sortingFilteringViewModel.SortingOptions != ListViewSortOptions.None)
            {
                ListView.DataSource.SortDescriptors.Add(new SortDescriptor()
                {
                    PropertyName = "Title",
                    Direction = sortingFilteringViewModel.SortingOptions == ListViewSortOptions.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending
                });
            }
            ListView.RefreshView();
        }

        #endregion

        #region Methods
        private bool FilterContacts(object obj)
        {
            if (searchBar == null || searchBar.Text == null)
                return true;

            var taskInfo = obj as TaskInfo;
            return (taskInfo.Title.ToLower().Contains(searchBar.Text.ToLower())
                || taskInfo.Description.ToLower().Contains(searchBar.Text.ToLower()));
        }

        #endregion
    }

    #endregion
}
