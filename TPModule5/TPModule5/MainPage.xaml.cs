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
        public MainPage()
        {
            InitializeComponent();

            var LoginForm = new LoginForm(
                this.idTwitter,
                this.password,
                this.isRemind,
                this.error,
                this.btnLogin,
                this.tweets,
                this.loginForm); ; 

            //gestion de l'évènement au clic sur le bouton "Se connecter"
            this.btnLogin.Clicked += LoginForm.BtnLogin_Clicked;

        }


    }
}
