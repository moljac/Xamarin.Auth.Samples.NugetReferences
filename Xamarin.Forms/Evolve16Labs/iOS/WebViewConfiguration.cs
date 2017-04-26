using System;

//TODO: move to Xamarin.Auth.XamarinForms
using ComicBook.iOS;//enables registration outside of namespace

[assembly: Xamarin.Forms.Dependency(typeof(WebViewConfiguration))]
namespace ComicBook.iOS
{
    public class WebViewConfiguration : ComicBookPCL.IWebViewConfiguration
    {
        public WebViewConfiguration()
        {
        }

        public bool IsUsingWKWebView
        {
            get
            {
                return Xamarin.Auth.WebViewConfiguration.IOS.IsUsingWKWebView;
            }
            set
            {
                Xamarin.Auth.WebViewConfiguration.IOS.IsUsingWKWebView = value;
            }
        }
    }
}
