using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.seg.dal.dto
{
    public class PerfilDTO
    {
        private int _IdPerfil;
        private string _NombrePerfil;
        private string _Estado;

        public PerfilDTO() { 
        
        }

        public PerfilDTO(int _IdPerfil, string _NombrePerfil, string _Estado)
        {
            this._IdPerfil = _IdPerfil;
            this._NombrePerfil = _NombrePerfil;
            this._Estado = _Estado;
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

        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        public Boolean EstadoBool
        {
            get
            {
                if (_Estado == "1")
                    return true;
                else
                    return false;
            }
        }


    }
}
