using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBook.UniversalWindowsPlatform
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App
    {
        protected override void OnActivated(Windows.ApplicationModel.Activation.IActivatedEventArgs args)
        {
            if (args.Kind == Windows.ApplicationModel.Activation.ActivationKind.Protocol)
            {
                var protocolArgs = args as Windows.ApplicationModel.Activation.ProtocolActivatedEventArgs;
                try
                {
                    ComicBookPCL.AuthenticationState.Authenticator.OnPageLoading(protocolArgs.Uri);
                }
                catch (System.IO.FileLoadException exc_fl)
                {
                    throw new Xamarin.Auth.AuthException("UWP custom scheme exception", exc_fl);

                }
            }

            Windows.UI.Xaml.Window.Current.Activate();
        }
    }
}
