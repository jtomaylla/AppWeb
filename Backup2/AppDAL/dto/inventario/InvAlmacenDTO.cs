using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class InvAlmacenDTO
  {

      //Propiedades
      private int _IdAlmacen;
      private string _CodAlmacen;
      private string _NombreAlmacen;
      private string _Direccion;
      private string _Estado;

      //Constructor

      public InvAlmacenDTO() { }

      public InvAlmacenDTO(int _IdAlmacen, string _CodAlmacen, string _NombreAlmacen, string _Direccion, string _Estado )
      {
          this._IdAlmacen = _IdAlmacen;
          this._CodAlmacen = _CodAlmacen;
          this._NombreAlmacen = _NombreAlmacen;
          this._Direccion = _Direccion;
          this._Estado = _Estado;
      }

      //Get y Set
      public int IdAlmacen
      {
          get { return _IdAlmacen; }
          set { _IdAlmacen = value; }
      }
      public string CodAlmacen
      {
          get { return _CodAlmacen; }
          set { _CodAlmacen = value; }
      }
      public string NombreAlmacen
      {
          get { return _NombreAlmacen; }
          set { _NombreAlmacen = value; }
      }
      public string Direccion
      {
          get { return _Direccion; }
          set { _Direccion = value; }
      }
      public string Estado
      {
          get { return _Estado; }
          set { _Estado = value; }
      }
  }
}
