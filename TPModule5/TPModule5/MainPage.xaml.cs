using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPModule5.Models;
using Xamarin.Forms;
using Xamarin.Essentials;

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

            this.btnLogin.Clicked += BtnLogin_Clicked; ;

            //vérification de la connection internet (cf. https://docs.microsoft.com/fr-fr/xamarin/essentials/connectivity?context=xamarin%2Fxamarin-forms&tabs=android)
            var current = Connectivity.NetworkAccess;
            if (current != NetworkAccess.Internet)
            {
                this.error.Text = "Veuillez vous connecter à Internet";
            }
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

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

        /**
         * vérification de la connection internet (cf. https://docs.microsoft.com/fr-fr/xamarin/essentials/connectivity?context=xamarin%2Fxamarin-forms&tabs=android)
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
            //si contraintes validées, on passe à l'authentification (authenticate())
            if (!String.IsNullOrEmpty(errorMessage))
            {
                this.error.Text = errorMessage;
                this.error.IsVisible = true;
            }
            else
            {
                //si l'authentification réussie on affiche les tweets et on masque le form de connexion.
                //Sinon on indique que cet utilisateur ne possède pas de tweets.
                if (twitterService.Authenticate(new User(login, password)))
                {
                    this.loginForm.IsVisible = false;
                    this.tweets.IsVisible = true;

                }
                else
                {
                    this.error.Text = "Cet utilisateur ne possède pas de Tweets.";
                }
            }
        }
    }
}
