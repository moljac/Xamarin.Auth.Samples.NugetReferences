


System.MissingMethodException

Method 'Android.Support.CustomTabs.CustomTabsIntent.LaunchUrl' not found.



# Success Stories

https://xamarinchat.slack.com/archives/C4TD1NHPT/p1493059446261920
https://xamarinchat.slack.com/archives/C4TD1NHPT/p1493060274542109

https://github.com/xamarin/Xamarin.Auth/issues/167#issuecomment-297368679

@subhamoy Glad you found the solution. Sorry I was (still am) out with kids on the sports practice. Sorry for delay.

[8:44] 
So most of the things are OK?

[8:44] 
most - because there are still some issues…

leobaillard [8:45 PM] 
@moljac err :stuck_out_tongue: I can _try_, but I'm not sure I'll succeed ^^ I'm still fairly new to all this

moljac [8:45 PM] 
No.

[8:45] 
You don;t need to…

[8:45] 
I just wanted to understand what you want to acomplish…

leobaillard [8:45 PM] 
oh sorry

[8:46] 
then yes, that's what I'm trying to do :stuck_out_tongue:

moljac [8:46 PM] 
I have code from 2015. Let me show you… But needs refactoring a bit (I hope)

subhamoy [8:46 PM] 
@moljac  - yes pretty much, I think Xamarin.Auth custom tabs are quite stable now. The only thing we are struggling is to add a host domain in Xamarin.Auth so that we can restrict user to a particular domain only while logging in.

moljac [8:47 PM] 
Cool. Glad to hear that.

[8:47] 
Forms are still problematic… Nuget dependencies and when linker jumps in => problems

[8:47] 
1.5.0 looks good. Todays tests

subhamoy [8:48 PM] 
In 1.5.0 Auth ctor - are we expecting "hd" parameter?

[8:48] 
That will make the life easier I suppose.

moljac [8:48 PM] 
what is hd?

[8:49] 
domain?

subhamoy [8:49 PM] 
Host Domain

moljac [8:49 PM] 
I’m not aware of that in Xamarin.Auth. I need to check RFC (standard)

subhamoy [8:49 PM] 
https://developers.google.com/identity/protocols/OpenIDConnect#hd-param

[8:49] 
^^ FYI.

moljac [8:51 PM] 
seems like this is google specific (thus OPTIONAL)

subhamoy [8:51 PM] 
Is it that - we are currently developing the app for stanford.edu domain login. Which uses google oauth behind the scenes. But in current Xamarin.Auth we don't have any way to restrict that.

[8:52] 
Yes quite right.

[8:52] 
Is there any way you could think of to implement it in current Xamarin.Auth, I could try it from my end then.

moljac [8:54 PM] 
I mean this parameter needs to be added to all other REQUIRED parametes in the URL it is simple as that :sunglasses:

[8:56] 
The problem for me (as non author, just late-came-in (unfortunate :sunglasses: ) maintainer) is that everything happens in the ctor of OAuth2Authenticator even 1st request.
For me something like React’s Redux would be nicer for API and explicitly to say: now go…

[8:57] 
Right now the problem is security and stability.

[8:57] 
Adding CustomTabs and SFSafariViewController passed with mid range sleepless nights

[8:57] 
And looks good.

leobaillard [8:57 PM] 
holy crap! the custom tab opened ! \o/ ok, I got an "Unsupported response type" error, but I got the freakin' custom tab

subhamoy [8:58 PM] 
\m/ way to go @leobaillard

moljac [8:58 PM] 
I read that other libs have even bigger problems.

[8:58] 
@leobaillard Use other ctor

[8:58] 
With client secret.

leobaillard [8:59 PM] 
ok

moljac [8:59 PM] 
I fixed it not to require client_secret

[8:59] 
In Xamarin.Auth it was required

[9:00] 
the fix is in 1.5.0-alpha-08, but seems like something was not packaged properly

subhamoy [9:00 PM] 
great - @moljac - meantime if you could think of anyway developers could tweak - Xamarin.Auth to support "host domain" it would be great.

moljac [9:02 PM] 
all I can think of…  Besides these 2 ctors to add ctor where all those properties are added as key-value pairs - check property Properties of those classes. This is actually in what ctors write…

[9:02] 
before requesting…

subhamoy [9:03 PM] 
Ok, can we override that one?

moljac [9:03 PM] 
Why not?

[9:04] 
you mean inherit + override?

[9:04] 
the classes are not sealed.

[9:04] 
Wait

[9:04] 
Maybe initializer could work…

[9:04] 
Let me try

