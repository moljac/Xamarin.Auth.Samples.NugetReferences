using System;

//TODO: move to Xamarin.Auth.XamarinForms
namespace ComicBookPCL
{
    public interface IWebViewConfiguration
    {
        bool IsUsingWKWebView 
        {
            get;
            set;
        }
    }
}
