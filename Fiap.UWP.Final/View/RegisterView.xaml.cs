using Fiap.UWP.Final.Data;
using Fiap.UWP.Final.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class RegisterView : Page
    {
        public List<string> Ufs { get; set; }
        public UsuarioViewModel UsuarioViewModel { get; set; }

        public RegisterView()
        {
            this.InitializeComponent();
            UsuarioViewModel = new UsuarioViewModel();
            LoadUfs();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            //rootFrame.Navigate(typeof(LoginView));
        }

        private void LoadUfs()
        {
            Ufs = new List<string>();
            Ufs.AddRange(new string[] {"AC", "AL", "AP", "AM", "BA", "CE", "DF", "GO", "ES", "MA",
                                            "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN",
                                            "RS", "RO", "RR", "SP", "SC", "SE", "TO", ""});
        }
    }
}
