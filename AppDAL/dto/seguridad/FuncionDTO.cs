using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.seg.dal.dto
{
    public class FuncionDTO
    {
        private int _IdFuncion;
        private string _NombreFuncion;
        private string _Funcion;
        private string _Estado;

        public FuncionDTO() { 

        }

        public FuncionDTO(int _IdFuncion, string _NombreFuncion, string _Estado)
        {
            this._IdFuncion = _IdFuncion;
            this._NombreFuncion = _NombreFuncion;
            this._Estado = _Estado;
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
