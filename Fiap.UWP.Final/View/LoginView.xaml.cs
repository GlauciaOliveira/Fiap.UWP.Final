using Fiap.UWP.Final.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Fiap.UWP.Final.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginView : Page
    {
        Frame rootFrame = Window.Current.Content as Frame;

        public LoginView()
        {
            this.InitializeComponent();
        }

        private async void btnAuthetication_Click(object sender, RoutedEventArgs e)
        {
            var auth = AutenticaUsuario(txtUsuario, txtPassWord);

            if (auth)
                rootFrame.Navigate(typeof(EventosView));
            else
            {
                MessageDialog showDialog = new MessageDialog("Usuário ou senha inválidos");

                showDialog.Commands.Add(new UICommand("OK"));
                await showDialog.ShowAsync();
            }
        }

        private bool AutenticaUsuario(TextBox txtUsuario, PasswordBox txtPassWord)
        {
            using (DbArtContext context = new DbArtContext())
            {
                var resut = context.Usuario.Where(x => x.Email.Equals(txtUsuario.Text) && x.Senha.Equals(txtPassWord.Password)).SingleOrDefault();

                if (resut != null)
                    return true;
                
            }
            return false;
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(RegisterView));
        }
    }
}
