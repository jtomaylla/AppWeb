using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.seg.dal.dto
{
    public class UsuarioPerfilDTO
    {
        private int _IdUsuario;
        private int _IdPerfil;
        private int _Orden;
        private string _Estado;
        private string _NombrePerfil;

        public UsuarioPerfilDTO() { 
        
        }

        public UsuarioPerfilDTO(int _IdUsuario, int _IdPerfil, int _Orden, string _Estado)
        {
            this._IdUsuario = _IdUsuario;
            this._IdPerfil = _IdPerfil;
            this._Orden = _Orden;
            this._Estado = _Estado;
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

        public int Orden
        {
            get { return _Orden; }
            set { _Orden = value; }
        }

        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        public string NombrePerfil    
        {
            get { return _NombrePerfil; }
            set { _NombrePerfil = value; }
        }


    }
}
