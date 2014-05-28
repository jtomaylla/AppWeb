using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class MonedaDTO
  {

      //Propiedades
      private string _CodMoneda;
      private string _NombreMoneda;
      private string _Simbolo;

      //Constructor

      public MonedaDTO() { }

      public MonedaDTO(string _CodMoneda, string _NombreMoneda, string _Simbolo )
      {
          this._CodMoneda = _CodMoneda;
          this._NombreMoneda = _NombreMoneda;
          this._Simbolo = _Simbolo;
      }

      //Get y Set
      public string CodMoneda
      {
          get { return _CodMoneda; }
          set { _CodMoneda = value; }
      }
      public string NombreMoneda
      {
          get { return _NombreMoneda; }
          set { _NombreMoneda = value; }
      }
      public string Simbolo
      {
          get { return _Simbolo; }
          set { _Simbolo = value; }
      }
  }
}
