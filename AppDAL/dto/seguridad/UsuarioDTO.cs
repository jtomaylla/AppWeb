using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.seg.dal.dto
{
  public class UsuarioDTO
  {

      //Propiedades
      private int _IdUsuario;
      private string _LoginUsuario;
      private string _NombreUsuario;
      private string _Clave;
      private string _Estado;
      private string _Email;
      private DateTime _FechaCreacion;
      private string _UsuarioCreacion;
      private DateTime _FechaModificacion;
      private string _UsuarioModificacion;

      private string _AnulaDescarta;

      //Constructor

      public UsuarioDTO() { }

      public UsuarioDTO(int _IdUsuario, string _LoginUsuario, string _NombreUsuario, string _Clave, string _Estado, DateTime _FechaCreacion, string _UsuarioCreacion, DateTime _FechaModificacion, string _UsuarioModificacion )
      {
          this._IdUsuario = _IdUsuario;
          this._LoginUsuario = _LoginUsuario;
          this._NombreUsuario = _NombreUsuario;
          this._Clave = _Clave;
          this._Estado = _Estado;
          this._FechaCreacion = _FechaCreacion;
          this._UsuarioCreacion = _UsuarioCreacion;
          this._FechaModificacion = _FechaModificacion;
          this._UsuarioModificacion = _UsuarioModificacion;
      }

      //Get y Set
      public string AnulaDescarta
      {
          get { return _AnulaDescarta; }
          set { _AnulaDescarta = value; }
      }

      public int IdUsuario
      {
          get { return _IdUsuario; }
          set { _IdUsuario = value; }
      }
      public string LoginUsuario
      {
          get { return _LoginUsuario; }
          set { _LoginUsuario = value; }
      }
      public string NombreUsuario
      {
          get { return _NombreUsuario; }
          set { _NombreUsuario = value; }
      }
      public string Clave
      {
          get { return _Clave; }
          set { _Clave = value; }
      }
      
      public string Estado
      {
          get { return _Estado; }
          set { _Estado = value; }
      }

      public string Email
      {
          get { return _Email; }
          set { _Email = value; }
      }

      public DateTime FechaCreacion
      {
          get { return _FechaCreacion; }
          set { _FechaCreacion = value; }
      }
      public string UsuarioCreacion
      {
          get { return _UsuarioCreacion; }
          set { _UsuarioCreacion = value; }
      }
      public DateTime FechaModificacion
      {
          get { return _FechaModificacion; }
          set { _FechaModificacion = value; }
      }
      public string UsuarioModificacion
      {
          get { return _UsuarioModificacion; }
          set { _UsuarioModificacion = value; }
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
