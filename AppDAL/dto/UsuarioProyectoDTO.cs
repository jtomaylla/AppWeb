using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class UsuarioProyectoDTO
  {

      //Propiedades
      private int _IDUSUARIO;
      private int _IDPROYECTO;
      private string _Estado;
      private string _TIPO;
      private string _NombreUsuario;
      private string _NombreTipo;

      //Constructor

      public UsuarioProyectoDTO() { }

      public UsuarioProyectoDTO(int _IdUsuario, int _IdProyecto, string _Estado, string _Tipo )
      {
          this._IDUSUARIO = _IdUsuario;
          this._IDPROYECTO = _IdProyecto;
          this._Estado = _Estado;
          this._TIPO = _Tipo;
      }

      //Get y Set
      public int IdUsuario
      {
          get { return _IDUSUARIO; }
          set { _IDUSUARIO = value; }
      }
      public int IdProyecto
      {
          get { return _IDPROYECTO; }
          set { _IDPROYECTO = value; }
      }
      public string Estado
      {
          get { return _Estado; }
          set { _Estado = value; }
      }
      public string Tipo
      {
          get { return _TIPO; }
          set { _TIPO = value; }
      }

      public string NombreUsuario
      {
          get { return _NombreUsuario; }
          set { _NombreUsuario = value; }
      }

      public string NombreTipo
      {
          get { return _NombreTipo; }
          set { _NombreTipo = value; }
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
