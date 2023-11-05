using Microsoft.Web.WebView2.Core;
using Morpho.Envimet.Handlers;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;

namespace Morpho.Envimet.UI
{
    /// <summary>
    /// Interaction logic for EntityForm.xaml
    /// </summary>
    public partial class EntityForm : Window
    {
        public MorphoConnection Connection { get; }

        public EntityForm(string schema, string values)
        {
            InitializeComponent();
            Connection = new MorphoConnection(schema, values);
            Dispatcher.Invoke(new Action(() => { InitializeAsync(); }));

            Connection.PropertyChanged += Connection_PropertyChanged;
            SetUpLayout(schema);
        }

        private void SetUpLayout(string schema)
        {
            switch (schema)
            {
                case "receptor":
                    this.Height = 225;
                    break;
                case "terrain":
                    this.Height = 275;
                    break;
                case "plant3D":
                    this.Height = 525;
                    break;
                case "plant2D":
                case "soil":
                case "source":
                    this.Height = 625;
                    break;
                default:
                    break;
            }
        }

        private async void InitializeAsync()
        {
            var env = await CoreWebView2Environment.CreateAsync(userDataFolder: "C:\\Temp\\Morpho.Envimet",
                options: new CoreWebView2EnvironmentOptions(
                    additionalBrowserArguments: "--disable-web-security",
                    allowSingleSignOnUsingOSPrimaryAccount: true));
            if (env != null) await webView2.EnsureCoreWebView2Async(env);
            else return;

            webView2.CoreWebView2.Settings.AreDevToolsEnabled = false;
            webView2.CoreWebView2.Settings.IsSwipeNavigationEnabled = false;
            webView2.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;

            var html = Properties.Resources.index;
            webView2.CoreWebView2.AddHostObjectToScript("connection", Connection);
            webView2.NavigateToString(html);
        }

        private void Connection_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Dispatcher.Invoke(new Action(() => { this.Close(); }));
        }
    }
}
