using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class ParametroDTO
  {

      //Propiedades
      private int _IdRegistro;
      private string _RazonSocial;
      private string _Ruc;
      private string _Direccion;
      private string _Telefono1;
      private string _Contacto;
      private string _TelefonoContacto;
      private string _EmailContacto;
      private string _WebSite;
      private string _Logo;
      private int _IdAlmacen;

      //Constructor

      public ParametroDTO() { }

      public ParametroDTO(int _IdRegistro, string _RazonSocial, string _Ruc, string _Direccion, string _Telefono1, string _Contacto, string _TelefonoContacto, string _EmailContacto, string _WebSite, string _Logo)
      {
          this._IdRegistro = _IdRegistro;
          this._RazonSocial = _RazonSocial;
          this._Ruc = _Ruc;
          this._Direccion = _Direccion;
          this._Telefono1 = _Telefono1;
          this._Contacto = _Contacto;
          this._TelefonoContacto = _TelefonoContacto;
          this._EmailContacto = _EmailContacto;
          this._WebSite = _WebSite;
          this._Logo = _Logo;
      }

      //Get y Set
      public int IdRegistro
      {
          get { return _IdRegistro; }
          set { _IdRegistro = value; }
      }
      public string RazonSocial
      {
          get { return _RazonSocial; }
          set { _RazonSocial = value; }
      }
      public string Ruc
      {
          get { return _Ruc; }
          set { _Ruc = value; }
      }
      public string Direccion
      {
          get { return _Direccion; }
          set { _Direccion = value; }
      }
      public string Telefono1
      {
          get { return _Telefono1; }
          set { _Telefono1 = value; }
      }
      public string Contacto
      {
          get { return _Contacto; }
          set { _Contacto = value; }
      }
      public string TelefonoContacto
      {
          get { return _TelefonoContacto; }
          set { _TelefonoContacto = value; }
      }
      public string EmailContacto
      {
          get { return _EmailContacto; }
          set { _EmailContacto = value; }
      }
      public string WebSite
      {
          get { return _WebSite; }
          set { _WebSite = value; }
      }
      
      public string Logo
      {
          get { return _Logo; }
          set { _Logo = value; }
      }

      public int IdAlmacen
      {
          get { return _IdAlmacen; }
          set { _IdAlmacen = value; }
      }

  }
}
