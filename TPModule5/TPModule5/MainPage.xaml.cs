using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPModule5.Models;
using Xamarin.Forms;
using Xamarin.Essentials;
using TPModule5.Data;

namespace TPModule5
{

    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public TwitterService twitterService;
        public MainPage()
        {
            InitializeComponent();

            this.twitterService = new TwitterService();

            this.error.IsVisible = false;
            this.btnLogin.Clicked += BtnLogin_Clicked; ;

            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

            var context = new AppDbContext();

        }


        /**
         * vérification de la connection internet
         */
        public bool IsConnected()
        {
            bool isConnected = true;
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                isConnected = false;   
            }
            return isConnected;
        }

        /**
         * gestion de l'évènement au clic sur le bouton "Se connecter"
         */
        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            //stocker les valeurs des champs dans des variables avant des les traiter
            String login = this.idTwitter.Text;
            String password = this.password.Text;

            String errorMessage = "";

            //vérification de la connection Internet
            if (!IsConnected())
            {
                this.error.Text = "Veuillez vous connecter à Internet";
                return;
            }
            
            //vérification des contraintes de format
            if (String.IsNullOrEmpty(login) || login.Length < 3)
            {
                errorMessage = "Veuillez saisir un identifiant d'au moins 3 caractères.";
            }
            if (String.IsNullOrEmpty(password) || password.Length < 6)
            {
                errorMessage += "Veuillez saisir un mot de passe d'au moins 6 caractères.";
            }

            //si contraintes non validées, on affiche un message d'erreur
            if (!String.IsNullOrEmpty(errorMessage))
            {
                this.error.Text = errorMessage;
                this.error.IsVisible = true;
            }
            else
            {
                //si l'authentification réussie on passe à la page Tweets
                if (twitterService.Authenticate(new User(login, password)))
                {
                    GoToTweetsPage();
                }
                else
                {
                    this.error.Text = "Cet utilisateur ne possède pas de Tweets.";
                }
            }
        }

        async void GoToTweetsPage()
        {
            await Navigation.PushAsync(new TweetsPage());
        }

        /**
         * gestion de l'évènement si la connexion à Internet change
         */
        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                this.error.IsVisible = false;
            }
            else
            {
                this.error.IsVisible = true;
                this.error.Text = "Veuillez vous connecter à Internet";
            }
        }

    }
}
