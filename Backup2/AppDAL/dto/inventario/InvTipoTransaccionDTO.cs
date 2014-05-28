using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class InvTipoTransaccionDTO
  {

      //Propiedades
      private int _IdTipoTransaccion;
      private string _NombreTransaccion;
      private string _Estado;
      private string _Clase;

      //Constructor

      public InvTipoTransaccionDTO() { }

      public InvTipoTransaccionDTO(int _IdTipoTransaccion, string _NombreTransaccion, string _Estado, string _Clase)
      {
          this._IdTipoTransaccion = _IdTipoTransaccion;
          this._NombreTransaccion = _NombreTransaccion;
          this._Estado = _Estado;
          this._Clase = _Clase;
      }

      //Get y Set
      public int IdTipoTransaccion
      {
          get { return _IdTipoTransaccion; }
          set { _IdTipoTransaccion = value; }
      }
      public string NombreTransaccion
      {
          get { return _NombreTransaccion; }
          set { _NombreTransaccion = value; }
      }
      public string Estado
      {
          get { return _Estado; }
          set { _Estado = value; }
      }
      public string Clase
      {
          get { return _Clase; }
          set { _Clase = value; }
      }
  }
}
