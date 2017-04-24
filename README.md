# Xamarin.Auth.Samples.NugetReferences

This repo is Xamarin.Auth samples solution repo extracted/separated from
original Xamarin.Auth repo:

https://github.com/xamarin/Xamarin.Auth

current branch - portable-bait-and-switch:

https://github.com/xamarin/Xamarin.Auth/tree/portable-bait-and-switch

This repo has faster update cadence than actual nuget samples in Xamarin.Auth
repo:

https://github.com/xamarin/Xamarin.Auth/tree/portable-bait-and-switch/samples/Traditional.Standard/references02nuget/Providers

## Samples Technology

Samples are available as

1.	Xamarin Traditional/Standard (Xamarin.Android and Xamarin.iOS)		
	[./Providers/](./Providers/)			
2.	Xamarin.Forms Samples Evolve16 Labs				
	Presenters implementation, no Custom Renderers		
	[./Evolve16/](./Providers/)			
3.	Xamarin.Forms Sample TODO				
	Custom Renderersimplementation				
	[]()	
	
Suggestion: start with Xamarin Traditional/Standar samples.

## Community (Discussions) about Xamarin.Auth

Discussion[s] about Xamarin.Auth is on community Xamarin Chat (Slack team) in
`#xamarin-auth-social` channel/room:

https://xamarinchat.slack.com/messages/C4TD1NHPT/

For those without account go here and get one:

https://xamarinchat.herokuapp.com/

## Documentation

Following docs (in this repo) are working docs which will be copied to
Xamarin.Auth official repo together with samples:

*	[./docs/GettingStarted.md](./docs/GettingStarted.md)		
*	[./docs/Details.md](./docs/Details.md)		



## Setup




## Installing nugets for lazy butts like me

In Package Console - Visual Studio:

### Providers samples

Xamarin Traditional/Standard (Xamarin.Android and Xamarin.iOS) samples for
numerous OAuth providers:

    Get-Project Xamarin.Auth.Sample.XamarinAndroid              | Install-Package Xamarin.Auth
    Get-Project Xamarin.Auth.Sample.XamarinIOS                  | Install-Package Xamarin.Auth
    Get-Project Xamarin.Auth.Sample.UniversalWindowsPlatform    | Install-Package Xamarin.Auth
    Get-Project Xamarin.Auth.Sample.WindowsPhone8               | Install-Package Xamarin.Auth
    Get-Project Xamarin.Auth.Sample.WindowsPhone81              | Install-Package Xamarin.Auth
    Get-Project Xamarin.Auth.Sample.WinRTWindows81              | Install-Package Xamarin.Auth
    Get-Project Xamarin.Auth.Sample.WinRTWindowsPhone81         | Install-Package Xamarin.Auth
    Get-Project Xamarin.Auth.SamplesData                        | Install-Package Xamarin.Auth



    Get-Project Xamarin.Auth.Sample.XamarinAndroid              | Update-Package Xamarin.Auth
    Get-Project Xamarin.Auth.Sample.XamarinIOS                  | Update-Package Xamarin.Auth
    Get-Project Xamarin.Auth.Sample.UniversalWindowsPlatform    | Update-Package Xamarin.Auth
    Get-Project Xamarin.Auth.Sample.WindowsPhone8               | Update-Package Xamarin.Auth
    Get-Project Xamarin.Auth.Sample.WindowsPhone81              | Update-Package Xamarin.Auth
    Get-Project Xamarin.Auth.Sample.WinRTWindows81              | Update-Package Xamarin.Auth
    Get-Project Xamarin.Auth.Sample.WinRTWindowsPhone81         | Update-Package Xamarin.Auth
    Get-Project Xamarin.Auth.SamplesData                        | Update-Package Xamarin.Auth

	 
	 
    Get-Project Xamarin.Auth.Sample.XamarinAndroid              | Update-Package Xamarin.Auth -IncludePrerelease
    Get-Project Xamarin.Auth.Sample.XamarinIOS                  | Update-Package Xamarin.Auth -IncludePrerelease
    Get-Project Xamarin.Auth.Sample.UniversalWindowsPlatform    | Update-Package Xamarin.Auth -IncludePrerelease
    Get-Project Xamarin.Auth.Sample.WindowsPhone8               | Update-Package Xamarin.Auth -IncludePrerelease
    Get-Project Xamarin.Auth.Sample.WindowsPhone81              | Update-Package Xamarin.Auth -IncludePrerelease
    Get-Project Xamarin.Auth.Sample.WinRTWindows81              | Update-Package Xamarin.Auth -IncludePrerelease
    Get-Project Xamarin.Auth.Sample.WinRTWindowsPhone81         | Update-Package Xamarin.Auth -IncludePrerelease
    Get-Project Xamarin.Auth.SamplesData                        | Update-Package Xamarin.Auth -IncludePrerelease
	 
	 
	 
### NativeUI samples Xamarin.Forms 

Xamarin.Forms with CustomRenderers implementation of Xamarin.Auth

Samples.NativeUI


#### Installation

    Get-Project Samples.NativeUI            | Install-Package Xamarin.Auth
    Get-Project Samples.NativeUI.Android    | Install-Package Xamarin.Auth
    Get-Project Samples.NativeUI.iOS        | Install-Package Xamarin.Auth
    Get-Project Samples.NativeUI.UWP        | Install-Package Xamarin.Auth
    Get-Project Samples.NativeUI            | Install-Package Xamarin.Auth.XamarinForms
    Get-Project Samples.NativeUI.Android    | Install-Package Xamarin.Auth.XamarinForms
    Get-Project Samples.NativeUI.iOS        | Install-Package Xamarin.Auth.XamarinForms
    Get-Project Samples.NativeUI.UWP        | Install-Package Xamarin.Auth.XamarinForms


    Get-Project Samples.NativeUI            | Update-Package Xamarin.Auth
    Get-Project Samples.NativeUI.Android    | Update-Package Xamarin.Auth
    Get-Project Samples.NativeUI.iOS        | Update-Package Xamarin.Auth
    Get-Project Samples.NativeUI.UWP        | Update-Package Xamarin.Auth
    Get-Project Samples.NativeUI            | Update-Package Xamarin.Auth.XamarinForms
    Get-Project Samples.NativeUI.Android    | Update-Package Xamarin.Auth.XamarinForms
    Get-Project Samples.NativeUI.iOS        | Update-Package Xamarin.Auth.XamarinForms
    Get-Project Samples.NativeUI.UWP        | Update-Package Xamarin.Auth.XamarinForms


    Get-Project Samples.NativeUI            | Update-Package -IncludePrerelease Xamarin.Auth
    Get-Project Samples.NativeUI.Android    | Update-Package -IncludePrerelease Xamarin.Auth
    Get-Project Samples.NativeUI.iOS        | Update-Package -IncludePrerelease Xamarin.Auth
    Get-Project Samples.NativeUI.UWP        | Update-Package -IncludePrerelease Xamarin.Auth
    Get-Project Samples.NativeUI            | Update-Package -IncludePrerelease Xamarin.Auth.XamarinForms
    Get-Project Samples.NativeUI.Android    | Update-Package -IncludePrerelease Xamarin.Auth.XamarinForms
    Get-Project Samples.NativeUI.iOS        | Update-Package -IncludePrerelease Xamarin.Auth.XamarinForms
    Get-Project Samples.NativeUI.UWP        | Update-Package -IncludePrerelease Xamarin.Auth.XamarinForms

	
### Evolve16 samples - Xamarin.Forms 

Xamarin.Forms with Presenters (without CustomRenderers) implementation of Xamarin.Auth


#### Usage Init

Android

https://github.com/moljac/Xamarin.Auth.Samples.NugetReferences/blob/master/Evolve16Labs/Droid/MainActivity.cs#L20
	
	global::Xamarin.Auth.Presenters.XamarinAndroid.AuthenticationConfiguration.Init(this, bundle);

iOS

https://github.com/moljac/Xamarin.Auth.Samples.NugetReferences/blob/master/Evolve16Labs/iOS/AppDelegate.cs#L16

	global::Xamarin.Auth.Presenters.XamarinIOS.AuthenticationConfiguration.Init();
	
#### Usage Present

Shared Code (Portable Class Library)

https://github.com/moljac/Xamarin.Auth.Samples.NugetReferences/blob/master/Evolve16Labs/Portable/MainPage.xaml.cs#L41-L55

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

	
#### Installation	

     Get-Project ComicBook              | Install-Package Xamarin.Auth
     Get-Project ComicBook.Droid        | Install-Package Xamarin.Auth
     Get-Project ComicBook.iOS          | Install-Package Xamarin.Auth
     Get-Project ComicBook.WinPhone8    | Install-Package Xamarin.Auth

     Get-Project ComicBook              | Update-Package Xamarin.Auth
     Get-Project ComicBook.Droid        | Update-Package Xamarin.Auth
     Get-Project ComicBook.iOS          | Update-Package Xamarin.Auth
     Get-Project ComicBook.WinPhone8    | Update-Package Xamarin.Auth

     Get-Project ComicBook              | Update-Package Xamarin.Auth -IncludePrerelease
     Get-Project ComicBook.Droid        | Update-Package Xamarin.Auth -IncludePrerelease
     Get-Project ComicBook.iOS          | Update-Package Xamarin.Auth -IncludePrerelease
     Get-Project ComicBook.WinPhone8    | Update-Package Xamarin.Auth -IncludePrerelease
	 