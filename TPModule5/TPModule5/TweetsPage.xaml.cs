using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPModule5.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TPModule5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TweetsPage : ContentPage
    {

        public TwitterService twitterService;

        public TweetsPage()
        {
            InitializeComponent();

            this.twitterService = new TwitterService();

            //On récupère l'ensemble des tweets pour alimenter la vue
            ObservableCollection<Tweet> listTweets = new ObservableCollection<Tweet>(twitterService.GetTweets());
            this.tweets.ItemsSource = listTweets;
        }
    }
}