using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.UWP.Final.Model
{
    public class Usuario
    {

        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Gender SelectedGender { get; set; }
        public string Uf { get; set; }
        public int Idade { get; set; }

    }

    public class Gender
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }

    }
}
