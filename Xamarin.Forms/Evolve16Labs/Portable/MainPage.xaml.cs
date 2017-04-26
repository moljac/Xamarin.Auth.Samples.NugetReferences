﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Auth;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace ComicBook
{
    public partial class MainPage : ContentPage
    {
        const string ServiceId = "ComicBook";
        const string Scope = "profile";

        Account account;
        AccountStore store;

        public MainPage()
        {
            InitializeComponent();

            implicitButton.Clicked += ImplicitButtonClicked;
            authorizationCodeButton.Clicked += AuthorizationCodeButtonClicked;
            getProfileButton.Clicked += GetProfileButtonClicked;
            refreshButton.Clicked += RefreshButtonClicked;

            store = AccountStore.Create();
            account = store.FindAccountsForService(ServiceId).FirstOrDefault();

            if (account != null)
            {
                statusText.Text = "Restored previous session";
                getProfileButton.IsEnabled = true;
                refreshButton.IsEnabled = true;
            }

            this.BindingContext = this;

            this.pickerUIFrameworks.SelectedIndex = 0;
            this.pickerFormsImplementations.SelectedIndex = 0;

            return;
        }

        void ImplicitButtonClicked(object sender, EventArgs e)
        {
            var authenticator = new OAuth2Authenticator
                (
                    ServerInfo.ClientId,
                    Scope,
                    ServerInfo.AuthorizationEndpoint,
                    ServerInfo.RedirectionEndpoint,
                    null,
                    isUsingNativeUI: true
                );

            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);
        }

        void AuthorizationCodeButtonClicked(object sender, EventArgs e)
        {
            var authenticator = new OAuth2Authenticator
                (
                    ServerInfo.ClientId,
                    ServerInfo.ClientSecret,
                    Scope,
                    ServerInfo.AuthorizationEndpoint,
                    ServerInfo.RedirectionEndpoint,
                    ServerInfo.TokenEndpoint,
                    null,
                    isUsingNativeUI: true
                );

            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);
        }

        async void GetProfileButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var request = new OAuth2Request("GET", ServerInfo.ApiEndpoint, null, account);
                var response = await request.GetResponseAsync();

                var text = response.GetResponseText();

                var json = JObject.Parse(text);

                var name = (string)json["Name"];
                var email = (string)json["Email"];
                var imageUrl = (string)json["ImageUrl"];

                nameText.Text = name;
                emailText.Text = email;

                var imageRequest = new OAuth2Request("GET", new Uri(imageUrl), null, account);
                var stream = await (await imageRequest.GetResponseAsync()).GetResponseStreamAsync();

                profileImage.Source = ImageSource.FromStream(() => stream);

                statusText.Text = "Get data succeeded";
            }
            catch (Exception x)
            {
                getProfileButton.IsEnabled = false;
                statusText.Text = "Get data failure: " + x.Message + "\r\nHas the access token expired?";
            }
        }

        async void RefreshButtonClicked(object sender, EventArgs e)
        {
            var refreshToken = account.Properties["refresh_token"];

            if (string.IsNullOrWhiteSpace(refreshToken))
                return;

            var queryValues = new Dictionary<string, string>
            {
                {"refresh_token", refreshToken},
                {"client_id", ServerInfo.ClientId},
                {"grant_type", "refresh_token"},
                {"client_secret", ServerInfo.ClientSecret},
            };

            var authenticator = new OAuth2Authenticator
                (
                    ServerInfo.ClientId,
                    ServerInfo.ClientSecret,
                    "profile",
                    ServerInfo.AuthorizationEndpoint,
                    ServerInfo.RedirectionEndpoint,
                    ServerInfo.TokenEndpoint,
                    null,
                    isUsingNativeUI: true
                );

            try
            {
                var result = await authenticator.RequestAccessTokenAsync(queryValues);

                if (result.ContainsKey("access_token"))
                    account.Properties["access_token"] = result["access_token"];

                if (result.ContainsKey("refresh_token"))
                    account.Properties["refresh_token"] = result["refresh_token"];

                store.Save(account, ServiceId);

                statusText.Text = "Refresh succeeded";
            }
            catch (Exception ex)
            {
                statusText.Text = "Refresh failed " + ex.Message;
            }
        }

        void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;

            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            if (e.IsAuthenticated)
            {
                getProfileButton.IsEnabled = true;

                if (this.account != null)
                    store.Delete(this.account, ServiceId);

                store.Save(account = e.Account, ServiceId);

                getProfileButton.IsEnabled = true;

                if (account.Properties.ContainsKey("expires_in"))
                {
                    var expires = int.Parse(account.Properties["expires_in"]);
                    statusText.Text = "Token lifetime is: " + expires + "s";
                }
                else
                {
                    statusText.Text = "Authentication succeeded";
                }

                if (account.Properties.ContainsKey("refresh_token"))
                    refreshButton.IsEnabled = true;
            }
            else
            {
                statusText.Text = "Authentication failed";
            }
        }

        void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;

            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            statusText.Text = "Authentication error: " + e.Message;
        }

        // *
        public List<string> UIFrameworks => _UIFrameworks;

        List<string> _UIFrameworks = new List<string>()
		{
			"Native UI (Custom Tabs or SFSafariViewController",
			"Embedded WebView",
		};

        bool native_ui = true;

        protected void pickerUIFrameworks_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Picker p = sender as Picker;

            if (((string)p.SelectedItem).Equals("Native UI (Custom Tabs or SFSafariViewController"))
            {
                native_ui = true;
            }
            else if (((string)p.SelectedItem).Equals("Embedded WebView"))
            {
                native_ui = false;
            }
            else
            {
                throw new ArgumentException("UIFramework error");
            }

            return;
        }

        bool forms_implementation_renderers = false;

        public List<string> FormsImplementations => _FormsImplementations;

        List<string> _FormsImplementations = new List<string>()
		{
			"Presenters (Dependency Service/Injection)",
			"Custom Renderers",
		};

        protected void pickerFormsImplementations_SelectedIndex(object sender, System.EventArgs e)
        {
            Picker p = sender as Picker;

            string implementation = ((string)p.SelectedItem);
            if (implementation == "Presenters (Dependency Service/Injection)")
            {
                forms_implementation_renderers = false;
            }
            else if (implementation == "Custom Renderers")
            {
                forms_implementation_renderers = true;
            }
            else
            {
                throw new ArgumentException("FormsImplementation error");
            }
            
            return;
        }

        string web_view = null;

        public List<string> Views => _Views;

        List<string> _Views = new List<string>()
		{
			"UIWebView",
			"WKWebView",
		};

        protected void pickerViews_SelectedIndex(object sender, System.EventArgs e)
        {
            Picker p = sender as Picker;

            web_view = ((string)p.SelectedItem);

            if (web_view == "UIWebView")
            {
                DependencyService.Get<ComicBookPCL.IWebViewConfiguration>().IsUsingWKWebView = false;
            }
            else if (web_view == "WKWebView")
            {
                DependencyService.Get<ComicBookPCL.IWebViewConfiguration>().IsUsingWKWebView = true;
            }
            else
            {
                throw new ArgumentException("WebView error");
            }

        	return;
        }
    }
}