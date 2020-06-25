using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using Switch = Xamarin.Forms.Switch;

namespace TPModule5.Models
{
    class LoginForm
    {
        //prop en lecture seule uniquement
        public Entry Login { get;}

        public Entry Password { get; }

        public Xamarin.Forms.Switch IsRemind { get; }

        public Label Error { get; }

        public View Tweets { get; }

        public View Form { get; }

        public LoginForm(Entry login, Entry password, Switch isRemind, Label error, Button btnLogin, View tweets, View form)
        {
            Login = login;
            Password = password;
            IsRemind = isRemind;
            Error = error;
            Tweets = tweets;
            Form = form;
        }

        public void BtnLogin_Clicked(object sender, EventArgs e)
        {
            //stocker les valeurs des champs dans des variables avant des les traiter
            String login = this.Login.Text;
            String password = this.Password.Text;
            String errorMessage = "";

            //utiliser Debug.WriteLine (et non Console.WriteLine)
            Debug.WriteLine("Login button is clicked");

            //vérification des conditions de validité
            if(String.IsNullOrEmpty(login) || login.Length < 3)
            {
                errorMessage = "Veuillez saisir un identifiant d'au moins 3 caractères.";
            }
            if(String.IsNullOrEmpty(password) || password.Length < 6)
            {
                errorMessage += "Veuillez saisir un mot de passe d'au moins 6 caractères.";
            }

            //si le message d'erreur est non null : on affiche l'erreur.
            //si pas d'erreur : masque le formulaire de connexion et on affiche les tweets.
            if (!String.IsNullOrEmpty(errorMessage))
            {
                this.Error.Text = errorMessage;
                this.Error.IsVisible = true;
            } else
            {
                this.Form.IsVisible = false;
                this.Tweets.IsVisible = true;
            }


        }


    }

    

}
