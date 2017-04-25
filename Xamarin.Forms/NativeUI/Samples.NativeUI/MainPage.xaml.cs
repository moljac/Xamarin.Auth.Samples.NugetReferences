using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Samples.NativeUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        Xamarin.Auth.OAuth2Authenticator authenticator = null;

        private void Button_Login_Fitbit_Clicked(object sender, EventArgs e)
        {
            authenticator
                = new Xamarin.Auth.OAuth2Authenticator
                (
                    /*       
                    clientId: "185391188679-9pa23l08ein4m4nmqccr9jm01udf3oup.apps.googleusercontent.com",
                    scope: "https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/plus.login",
                    authorizeUrl: new Uri("https://accounts.google.com/o/oauth2/auth"),
                    redirectUrl: new Uri
                                    (
                                        "comauthenticationapp://localhost"
                                    //"com.authentication.app://localhost"
                                    //"com-authentication-app://localhost"
                                    ),
                    */
                    clientId:
                        new Func<string>
                           (
                                () =>
                                {
                                    string retval_client_id = "oops something is wrong!";

                                    // some people are sending the same AppID for google and other providers
                                    // not sure, but google (and others) might check AppID for Native/Installed apps
                                    // Android and iOS against UserAgent in request from 
                                    // CustomTabs and SFSafariViewContorller
                                    // TODO: send deliberately wrong AppID and note behaviour for the future
                                    // fitbit does not care - server side setup is quite liberal
                                    switch (Xamarin.Forms.Device.RuntimePlatform)
                                    {
                                        case "iOS":
                                            retval_client_id = "228CVW";
                                            break;
                                        case "Android":
                                            retval_client_id = "228CVW";
                                            break;
                                    }
                                    return retval_client_id;
                                }
                          ).Invoke(),
                    authorizeUrl: new Uri("https://www.fitbit.com/oauth2/authorize"),
                    redirectUrl: new Uri("xamarin-auth://localhost"),
                    scope: "profile",
                    getUsernameAsync: null,
                    isUsingNativeUI: false
                )
                {
                    AllowCancel = true,
                };

            NavigateLoginPage();

            return;
        }

        private void Button_Login_Google_New_NativeUI_Clicked(object sender, EventArgs e)
        {
            return;
        }

        private void Button_Login_Google_Old_WebApp_Clicked(object sender, EventArgs e)
        {
        	return;
        }

        Xamarin.Auth.XamarinForms.AuthenticatorPage login_page = null;

        private void NavigateLoginPage()
        {
            // / *
            //---------------------------------------------------------------------
            // ContentPage with CustomRenderers
            login_page = new Xamarin.Auth.XamarinForms.AuthenticatorPage()
                                    {
                                        Authenticator = authenticator,
                                    };
            Navigation.PushAsync(login_page);
        	//---------------------------------------------------------------------
        	// Xamarin.UNiversity Team Presenters Concept
        	// Xamarin.Auth.Presenters.OAuthLoginPresenter presenter = null;
        	// presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
        	//presenter.Login (authenticator);
        	//---------------------------------------------------------------------
        	// * /

        	return;
        }

        public void Authentication_Completed(object sender, Xamarin.Auth.AuthenticatorCompletedEventArgs e)
        {
        	return;
        }

        public void Authentication_Error(object sender, Xamarin.Auth.AuthenticatorErrorEventArgs e)
        {
        	return;
        }

        public void Authentication_BrowsingCompleted(object sender, EventArgs e)
        {
        	return;
        }
    
    }
}
