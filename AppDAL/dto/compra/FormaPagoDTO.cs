using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class FormaPagoDTO
  {

      //Propiedades
      private int _IdFormaPago;
      private string _NombreFormaPago;
      private int _Dias;

      //Constructor

      public FormaPagoDTO() { }

      public FormaPagoDTO(int _IdFormaPago, string _NombreFormaPago, int _Dias )
      {
          this._IdFormaPago = _IdFormaPago;
          this._NombreFormaPago = _NombreFormaPago;
          this._Dias = _Dias;
      }

      //Get y Set
      public int IdFormaPago
      {
          get { return _IdFormaPago; }
          set { _IdFormaPago = value; }
      }
      public string NombreFormaPago
      {
          get { return _NombreFormaPago; }
          set { _NombreFormaPago = value; }
      }
      public int Dias
      {
          get { return _Dias; }
          set { _Dias = value; }
      }
  }
}
