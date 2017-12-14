using Fiap.UWP.Final.Data;
using Fiap.UWP.Final.Model;
using Fiap.UWP.Final.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using static Fiap.UWP.Final.App;

namespace Fiap.UWP.Final.ViewModel
{
   
    public class UsuarioViewModel : NotificationBase<Usuario>
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Gender> genders;
        private Usuario usuario;

        public Usuario Usuario
        {
            get { return usuario; }
            private set
            {
                usuario = value;
            }
        }

        private Gender sexo;
        public Gender Sexo
        {
            get { return sexo; }
            private set
            {
                sexo = value;
            }
        }

        public UsuarioViewModel()
        {

            //this.genders = new ObservableCollection<Gender>();
            this.genders = new ObservableCollection<Gender>();
            this.genders.Add(new Gender() { Codigo = "F", Descricao = "Feminino" });
            this.genders.Add(new Gender() { Codigo = "M", Descricao = "Masculino" });

            usuario = new Usuario();
            sexo = new Gender();
        }

        void NotifyPropertyChanged(string propertyName)
        {
            var handlers = this.PropertyChanged;
            if (handlers != null)
            {
                handlers(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        public String Nome
        {
            get { return This.Nome; }
            set { SetProperty(This.Nome, value, () => This.Nome = value); }
        }

        public int Idade
        {
            get { return This.Idade; }
            set { SetProperty(This.Idade, value, () => This.Idade = value); }
        }

        public string Email
        {
            get { return This.Email; }
            set { SetProperty(This.Email, value, () => This.Email = value); }
        }

        public string Senha
        {
            get { return This.Senha; }
            set { SetProperty(This.Senha, value, () => This.Senha = value); }
        }

        public string Uf
        {
            get { return This.Uf; }

            set
            {
                if (This.Uf != value)
                {
                    This.Uf = value;
                    RaisePropertyChanged("Ufs");
                }
            }
        }

        
        public ObservableCollection<Gender> Genders
        {
            get { return this.genders; }
            private set
            {
                genders = value;
                EventPropertyChanged("Gender");
            }
        }

        
        private Gender selectedGender;

        public Gender SelectedGender
        {
            get { return selectedGender; }
            set
            {
                // Set the local field value.
                this.selectedGender = value;
                EventPropertyChanged("SelectedGender");
                //SetProperty(This.Sexo, value, () => This.Sexo = value.Codigo);
                Usuario.SelectedGender = value;
                // this.NotifyPropertyChanged("SelectedGender");
                
            }
        }
        


        public void Incluir()
        {
            // Actual setting happens here

            //var teste = selectedGender.Codigo;
            var result = Sexo; //(SelectedGender ?? new Gender()).Codigo;
            Usuario.Nome = Nome;
            Usuario.Email = Email;
            Usuario.Idade = Idade;
            //Usuario.Sexo = SexoFem == true ? "F" : "M";
            //Usuario.Sexo = Sexo.ToString();
            Usuario.Uf = Uf;
            Usuario.Senha = Senha;

            using (DbArtContext context = new DbArtContext())
            {
                context.Usuario.Add(Usuario);
                //context.SaveChanges();
            }
        }
    }
}
