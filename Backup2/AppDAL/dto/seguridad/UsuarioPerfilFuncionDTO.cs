using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.seg.dal.dto
{
    public class UsuarioPerfilFuncionDTO
    {
        int _IdUsuario;
        int _IdPerfil;
        int _IdFuncion;
        string _NombrePerfil;
        string _NombreFuncion;
        string _Funcion;

        public UsuarioPerfilFuncionDTO() { 
        
        }

        public int IdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; }
        }

        public int IdPerfil
        {
            get { return _IdPerfil; }
            set { _IdPerfil = value; }
        }

        public string NombrePerfil
        {
            get { return _NombrePerfil; }
            set { _NombrePerfil = value; }
        }

        public int IdFuncion
        {
            get { return _IdFuncion; }
            set { _IdFuncion = value; }
        }

        public string NombreFuncion
        {
            get { return _NombreFuncion; }
            set { _NombreFuncion = value; }
        }

        public string Funcion
        {
            get { return _Funcion; }
            set { _Funcion = value; }
        }

    }
}
