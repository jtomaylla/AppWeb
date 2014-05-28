/*
* RBTEC
* Creado por: Antonio Anampa
* Fecha: 15/01/2014
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class OrdenCompraAprobadorDTO
  {

      //Propiedades
      private int _IdOrdenCompra;
      private int _IdUsuarioAprobacion;
      private DateTime _FechaAprobacion;

      //Constructor

      public OrdenCompraAprobadorDTO() { }

      public OrdenCompraAprobadorDTO(int _IdOrdenCompra, int _IdUsuarioAprobacion, DateTime _FechaAprobacion)
      {
          this._IdOrdenCompra = _IdOrdenCompra;
          this._IdUsuarioAprobacion = _IdUsuarioAprobacion;
          this._FechaAprobacion = _FechaAprobacion;
      }

      //Get y Set
      public int IdOrdenCompra
      {
          get { return _IdOrdenCompra; }
          set { _IdOrdenCompra = value; }
      }
      public int IdUsuarioAprobacion
      {
          get { return _IdUsuarioAprobacion; }
          set { _IdUsuarioAprobacion = value; }
      }
      public DateTime FechaAprobacion
      {
          get { return _FechaAprobacion; }
          set { _FechaAprobacion = value; }
      }
  }
}
