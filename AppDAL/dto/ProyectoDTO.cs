using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
    public class ProyectoDTO
    {

        private int _IdProyecto;
        private string _NombreProyecto;
        private string _NombreCorto;
        private string _Estado;

        public ProyectoDTO() { 
        
        }

        public ProyectoDTO(int _IdProyecto, string _NombreProyecto, string _Estado)
        {
            this._IdProyecto = _IdProyecto;
            this._NombreProyecto = _NombreProyecto;
            this._Estado = _Estado;
        }

        public int IdProyecto
        {
            get { return _IdProyecto; }
            set { _IdProyecto = value; }
        }

        public string NombreProyecto
        {
            get { return _NombreProyecto; }
            set { _NombreProyecto = value; }
        }

        public string NombreCorto
        {
            get { return _NombreCorto; }
            set { _NombreCorto = value; }
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
