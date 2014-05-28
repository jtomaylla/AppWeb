using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class SedeDTO
  {

      //Propiedades
      private int _IdSede;
      private string _NombreSede;
      private string _Estado;
      private string _Direccion;

      //Constructor

      public SedeDTO() { }

      public SedeDTO(int _IdSede, string _NombreSede, string _Estado )
      {
          this._IdSede = _IdSede;
          this._NombreSede = _NombreSede;
          this._Estado = _Estado;
      }

      //Get y Set
      public int IdSede
      {
          get { return _IdSede; }
          set { _IdSede = value; }
      }
      public string NombreSede
      {
          get { return _NombreSede; }
          set { _NombreSede = value; }
      }
      
      public string Estado
      {
          get { return _Estado; }
          set { _Estado = value; }
      }

      public string Direccion
      {
          get { return _Direccion; }
          set { _Direccion = value; }
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
