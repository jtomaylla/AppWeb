using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class PedidoPresupuestoDTO
  {

      //Propiedades
      private int _IdPedidoPresupuesto;
      private int _IdPedido;
      private string _CodigoPresupuesto;
      private string _Descripcion;

      //Constructor

      public PedidoPresupuestoDTO() { }

      public PedidoPresupuestoDTO(int _IdPedidoPresupuesto, int _IdPedido, string _CodigoPresupuesto, string _Descripcion )
      {
          this._IdPedidoPresupuesto = _IdPedidoPresupuesto;
          this._IdPedido = _IdPedido;
          this._CodigoPresupuesto = _CodigoPresupuesto;
          this._Descripcion = _Descripcion;
      }

      //Get y Set
      public int IdPedidoPresupuesto
      {
          get { return _IdPedidoPresupuesto; }
          set { _IdPedidoPresupuesto = value; }
      }
      public int IdPedido
      {
          get { return _IdPedido; }
          set { _IdPedido = value; }
      }
      public string CodigoPresupuesto
      {
          get { return _CodigoPresupuesto; }
          set { _CodigoPresupuesto = value; }
      }
      public string Descripcion
      {
          get { return _Descripcion; }
          set { _Descripcion = value; }
      }
  }
}
