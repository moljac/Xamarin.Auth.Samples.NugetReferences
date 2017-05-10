# Xamarin.Auth

Xamarin.Auth is a cross platform library that helps developers authenticate 
users via OAuth protocol (OAuth1 and OAuth2). 

OAuth flow (process) is setup in 5 major steps:

1.  Initialization of Authenticator object      
    preparing all relevant OAuth Data in Authenticator object
2.  Creating and optionally customising UI      
3.  Lunching UI and authenticating user
4.  Detecting/Fetching/Intercepting URL change - redirect url   
    and     
    parsing OAuth data from redirect_url
5.  Triggering Events based on OAuth data 

Those steps and (substeps) which will be used in detailed documentation 
[./Details.md](./Details.md).


## 1. Initialization

### 1.1 Server Side 

Server side setup of the particular OAuth provider like Google, Facebook or Microsoft Live
is the source of misunderstandings and errors. This setup differs from provider to provider,
especially nomenclature (naming).

In general there are 2 common types of "apps", "projects" or "credentials":

1.  Web Application

    Web app is considered to be secure, i.e. client_secret is secure and can be stored and  
    not easily accessed/retrieved by malicious user.
    
    Web app uses http[s] schemes for redirect_url, because it loads real web page (url-authority
    can be localhost or real hostname). 
    
    Xamarin.Auth prior to version 1.4.0 used to support only http[s] url-scheme with real   
    url-authority (existing host, no localhost) and arbitrary url-path. 
    
2.  Native or Installed (mobile or desktop) apps    
    
    This group is usually divided into Android, iOS, Chrome (javascript) and other (.net)   
    subtypes. Each subtype can have different setup. Custom schemes can be predefined (generated)       
    by provider (Google or Facebook) or defined by user (Fitbit).
    
    Xamarin Components Team is working on the doc with minimal info for common used providers and       
    how to setup server side.
    
    Xamarin.Auth implements requirements for native/installed apps since nuget version 1.4.0, but   
    the API was broken (`GetUI()` returned `System.Object`, so cast was necessary)

Server side setup details will be explained in separate document.

    
### 1.2 Client (mobile) application initialization

Initialization is based on Oauth Grant (flow) in use which is determined by OAuth 
provider and it's server side setup.

Initialization is performed thorugh Authenticator constructors for:

*   OAuth2 Implicit Grant flow with parameters:     
    *   clientId        
    *   scope       
    *   authorizeUrl        
    *   redirectUrl     
*   OAuth2 Authorization Code Grant flow with parameters:       
    *   clientId        
    *   scope       
    *   authorizeUrl        
    *   redirectUrl 
    *   clientSecret

More about OAuth can be found here: []().

#### 1.2.1 Create and configure an authenticator

Let's authenticate a user to access Facebook which uses OAuth2 Implicit flow:

```csharp
using Xamarin.Auth;
// ...
OAuth2Authenticator auth = new OAuth2Authenticator 
    (
        clientId: "App ID from https://developers.facebook.com/apps",
        scope: "",
        authorizeUrl: new Uri ("https://m.facebook.com/dialog/oauth/"),
        redirectUrl: new Uri ("http://www.facebook.com/connect/login_success.html"),
        // switch for new Native UI API
        //      true = Android Custom Tabs and/or iOS Safari View Controller
        //      false = Embedded Browsers used (Android WebView, iOS UIWebView)
        //  default = false  (not using NEW native UI)
        isUsingNativeUI: use_native_ui
    );
```

Facebook uses OAuth 2.0 authentication, so we create an `OAuth2Authenticator`. 
Authenticators are responsible for managing the user interface and communicating with 
authentication services.

Authenticators take a variety of parameters; in this case, the application's ID, its 
authorization scope, and Facebook's various service locations are required.

#### 1.2.2 Setup Authentication Event Handlers

To capture events and information in the OAuth flow simply subscribe to Authenticator
events (add event handlers):

Xamarin.Android

```csharp
auth.Completed += (sender, eventArgs) => 
{
    // UI presented, so it's up to us to dimiss it on Android
    // dismiss Activity with WebView or CustomTabs
    this.Finish();

    if (eventArgs.IsAuthenticated) 
    {
        // Use eventArgs.Account to do wonderful things
    } else 
    {
        // The user cancelled
    }
};
```

Xamarin.iOS

```csharp
auth.Completed += (sender, eventArgs) => 
{
    // UI presented, so it's up to us to dimiss it on iOS
    // dismiss ViewController with UIWebView or SFSafariViewController
    this.DismissViewController (true, null);

    if (eventArgs.IsAuthenticated) 
    {
        // Use eventArgs.Account to do wonderful things
    } else 
    {
        // The user cancelled
    }
};
```

## 2. Authenticate the user

While authenticators manage their own UI, it's up to user to initially present the 
authenticator's UI on the screen. This lets one control how the authentication UI is 
displayed–modally, in navigation controllers, in popovers, etc.

Before the UI is presented, user needs to start listening to the `Completed` event which fires 
when the user successfully authenticates or cancels. One can find out if the authentication 
succeeded by testing the `IsAuthenticated` property of `eventArgs`:


All the information gathered from a successful authentication is available in 
`eventArgs.Account`.

Now, the login UI can be obtained using `GetUI()` method and afterwards login screen is 
ready to be presented.  

The `GetUI()` method returns 

*   `UINavigationController` on iOS, and 
*   `Intent` on Android.  
*   `System.Type` on WinRT (Windows 8.1 and Windows Phone 8.1)    
*   `Syste.Uri` on Windows Phone 8.x Silverlight

NOTE: if user does need customizations of the NativeUI (Custom Tabs on Android and/or 
SFSafariViewController) there is extra step needed - cast to appropriate type, so the   
API can be accessed (more in Details).

On Android, user would write the following code to present the UI.

```csharp
StartActivity (auth.GetUI (this));
```

On iOS, one would present UI in following way (with differences fromold API)

```csharp
PresentViewController (auth.GetUI ());
```

On Windows 

## 3. Using identity - Making requests

With obtained access_token (identity) user can now access protected ressources.

Since Facebook is an OAuth2 service, user can make requests with `OAuth2Request` providing 
the account retrieved from the `Completed` event. Assuming user is authenticated, it is possible     
to grab the user's info:

```csharp
OAuth2Request request = new OAuth2Request 
							(
								"GET",
								 new Uri ("https://graph.facebook.com/me"), 
								 null, 
								 eventArgs.Account
							);
request.GetResponseAsync().ContinueWith 
    (
        t => 
        {
            if (t.IsFaulted)
                Console.WriteLine ("Error: " + t.Exception.InnerException.Message);
            else 
            {
                string json = t.Result.GetResponseText();
                Console.WriteLine (json);
            }
        }
    );
```


## 4. Store the account

Xamarin.Auth securely stores `Account` objects so that users don't always have to reauthenticate 
the user. The `AccountStore` class is responsible for storing `Account` information, backed by 
the 
[Keychain](https://developer.apple.com/library/ios/#documentation/security/Reference/keychainservices/Reference/reference.html) 
on iOS and a [KeyStore](http://developer.android.com/reference/java/security/KeyStore.html) on 
Android.

Creating `AccountStore` on Android:

```csharp
// On Android:
AccountStore.Create (this).Save (eventArgs.Account, "Facebook");
```

Creating `AccountStore` on iOS:

```csharp
// On iOS:
AccountStore.Create ().Save (eventArgs.Account, "Facebook");
```

Saved Accounts are uniquely identified using a key composed of the account's 
`Username` property and a "Service ID". The "Service ID" is any string that is 
used when fetching accounts from the store.

If an `Account` was previously saved, calling `Save` again will overwrite it. 
This is convenient for services that expire the credentials stored in the account 
object.


## 5. Retrieve stored accounts

Fetching all `Account` objects stored for a given service is possible with follwoing API:

Retrieving accounts on Android:

```csharp
// On Android:
IEnumerable<Account> accounts = AccountStore.Create (this).FindAccountsForService ("Facebook");
```

Retrieving accounts on iOS:

```csharp
// On iOS:
IEnumerable<Account> accounts = AccountStore.Create ().FindAccountsForService ("Facebook");
```

It's that easy.


## 6. Make your own authenticator

Xamarin.Auth includes OAuth 1.0 and OAuth 2.0 authenticators, providing support for thousands 
of popular services. For services that use traditional username/password authentication, one 
can roll own authenticator by deriving from `FormAuthenticator`.

If user wants to authenticate against an ostensibly unsupported service, fear not – Xamarin.Auth 
is extensible! It's very easy to create own custom authenticators – just derive from any of the 
existing authenticators and start overriding methods.

