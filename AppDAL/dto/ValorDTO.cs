using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
    public class ValorDTO
    {
        private string _Valor;
        private string _Descripcion;

        public ValorDTO() { 

        }

        public ValorDTO(string _Valor, string _Descripcion)
        {
            this._Valor = _Valor;
            this._Descripcion = _Descripcion;
        }

        public string Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

    
    }
}
