# Xamarin.Auth.Samples.NugetReferences

This repo is Xamarin.Auth samples solution repo extracted/separated from
original Xamarin.Auth repo:

https://github.com/xamarin/Xamarin.Auth

current branch - portable-bait-and-switch:

https://github.com/xamarin/Xamarin.Auth/tree/portable-bait-and-switch

This repo has faster update cadence than actual nuget samples in Xamarin.Auth
repo:

https://github.com/xamarin/Xamarin.Auth/tree/portable-bait-and-switch/samples/Traditional.Standard/references02nuget/Providers


## Installing nugets for lazy butts like me

In Package Console - Visual Studio:


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


