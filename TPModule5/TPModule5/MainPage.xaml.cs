using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPModule5.Models;
using Xamarin.Forms;

namespace TPModule5
{

    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public TwitterService twitterService;
        public MainPage()
        {
            InitializeComponent();

            //gestion de l'évènement au clic sur le bouton "Se connecter"
            this.btnLogin.Clicked += BtnLogin_Clicked; ;

            this.twitterService = new TwitterService();
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
