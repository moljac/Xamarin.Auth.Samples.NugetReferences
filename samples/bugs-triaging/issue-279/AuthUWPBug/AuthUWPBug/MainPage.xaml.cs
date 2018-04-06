using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Forms;

namespace AuthUWPBug
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}
        void btn_Clicked(object sender, EventArgs e)
        {
            OAuth2Authenticator authenticator = new OAuth2Authenticator(
                      "client",
                      "secret",
                      "openid profile api1",
                      new Uri("authorize uri"),
                      new Uri("kasemlogin://localhost/oauth2redirect"),
                      new Uri("token uri"),
                      null,
                      true);


            authenticator.AllowCancel = false;

            authenticator.ShowErrors = true;
            authenticator.Completed += Authenticator_Completed;
            AuthenticationState.Authenticator = authenticator;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);
        }

        private void Authenticator_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;



            if (e.IsAuthenticated)
            {

                label.Text = "Authentication ok";
            }
            else
            {
                label.Text = "Authentication failed";
            }

        }

    }
}
