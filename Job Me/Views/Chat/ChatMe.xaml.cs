using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AspNetCore.SignalR;
using JobMe.ViewModels.Chat;
using JobMe.ViewModels;
using JobMe.Models.Chat;
using Xamarin.Essentials;
using JobMe.Views.Chat;
using System.Collections.ObjectModel;

namespace JobMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatMe : ContentView
    {
        //private RecentChatViewModel vm = new RecentChatViewModel();
       

        public ChatMe()
        {
            //vm.Navigation = Navigation;

            //BindingContext = vm;
            InitializeComponent();
            //vm.ListView = ListView;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width > height)
            {
                if (SearchBox.IsVisible)
                {
                    SearchBox.WidthRequest = width;
                }
            }
        }

        private void listView_SwipeStarted(object sender, Syncfusion.ListView.XForms.SwipeStartedEventArgs e)
        {
            // vm.ItemIndex = -1;
        }

        private void listView_SwipeEnded(object sender, Syncfusion.ListView.XForms.SwipeEndedEventArgs e)
        {
            // vm.ItemIndex = e.ItemIndex;
        }

        /// <summary>
        /// Invoked when back button is clicked.
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">Event Args</param>
        private void BackButton_Clicked(object sender, EventArgs e)
        {
            if (this.TitleBar != null)
            {
                double opacity;

                // Animating Width of the search box, from full width to 0 before it removed from view.
                var shrinkAnimation = new Animation(property =>
                {
                    SearchBox.WidthRequest = property;
                    opacity = property / TitleBar.Width;
                    SearchBox.Opacity = opacity;
                },
                TitleBar.Width, 0, Easing.Linear);
                shrinkAnimation.Commit(SearchBox, "Shrink", 16, 250, Easing.Linear, (p, q) => this.SearchBoxAnimationCompleted());
            }

            SearchEntry.Text = string.Empty;
        }

        /// <summary>
        /// Invokes when search box Animation completed.
        /// </summary>
        private void SearchBoxAnimationCompleted()
        {
            this.SearchBox.IsVisible = false;
            this.ProfileView.IsVisible = true;
        }

        /// <summary>
        /// Invoked when search button is clicked.
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">Event Args</param>
        private void SearchButton_Clicked(object sender, EventArgs e)
        {
            this.SearchBox.IsVisible = true;
            this.ProfileView.IsVisible = false;

            if (this.TitleBar != null)
            {
                double opacity;

                // Animating Width of the search box, from 0 to full width when it added to the view.
                var expandAnimation = new Animation(
                    property =>
                    {
                        SearchBox.WidthRequest = property;
                        opacity = property / TitleBar.Width;
                        SearchBox.Opacity = opacity;
                    }, 0, TitleBar.Width, Easing.Linear);
                expandAnimation.Commit(SearchBox, "Expand", 16, 250, Easing.Linear);
            }

            SearchEntry.Focus();
        }

        SearchBar searchBar = null;
        private void SearchEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchBar = (sender as SearchBar);


        }
    }
}