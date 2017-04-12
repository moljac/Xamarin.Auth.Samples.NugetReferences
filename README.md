# Xamarin.Auth.Samples.NugetReferences

This repo is Xamarin.Auth samples solution repo extracted/separated from
original Xamarin.Auth repo:

https://github.com/xamarin/Xamarin.Auth

current branch - portable-bait-and-switch:

https://github.com/xamarin/Xamarin.Auth/tree/portable-bait-and-switch

This repo has faster update cadence than actual nuget samples in Xamarin.Auth
repo:

https://github.com/xamarin/Xamarin.Auth/tree/portable-bait-and-switch/samples/Traditional.Standard/references02nuget/Providers

## Community (Discussions) about Xamarin.Auth

Discussion[s] about Xamarin.Auth is on community Xamarin Chat (Slack team) in
`#xamarin-auth-social` channel/room:

https://xamarinchat.slack.com/messages/C4TD1NHPT/

For those without account go here and get one:

https://xamarinchat.herokuapp.com/

## Installing nugets for lazy butts like me

In Package Console - Visual Studio:

### Providers samples

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

### Evolve16 samples - Xamarin.Forms 

Xamarin.Forms with Presenters (without CustomRenderers) implementation of Xamarin.Auth

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
	 