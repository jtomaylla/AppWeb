using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.seg.dal.dto
{
  public class PerfilFuncionDTO
  {

      //Propiedades
      private int _IdPerfil;
      private int _IdFuncion;
      private int _Orden;
      private string _Estado;
      private string _NombreFuncion;

      //Constructor

      public PerfilFuncionDTO() { }

      public PerfilFuncionDTO(int _IdPerfil, int _IdFuncion, int _Orden, string _Estado )
      {
          this._IdPerfil = _IdPerfil;
          this._IdFuncion = _IdFuncion;
          this._Orden = _Orden;
          this._Estado = _Estado;
      }

      //Get y Set
      public int IdPerfil
      {
          get { return _IdPerfil; }
          set { _IdPerfil = value; }
      }
      public int IdFuncion
      {
          get { return _IdFuncion; }
          set { _IdFuncion = value; }
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

      public string NombreFuncion
      {
          get { return _NombreFuncion; }
          set { _NombreFuncion = value; }
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
