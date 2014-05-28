using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class PedidoDTO
  {

      //Propiedades
      private int _IdPedido;
      private int _IdProyecto;
      private int _IdSede;
      private int _IdSolicitante;
      private int _IdResponsableProyecto;
      private int _IdTipoPedido;
      private string _CodMoneda;
      private string _NumeroPedido;
      private DateTime _FechaPedido;
      private string _Descripcion;
      private string _Observaciones;
      private string _Estado;
      private DateTime _FechaAprobacion;
      private string _EstadoControl;
      private string _Cancelado;
      private DateTime _FechaCancelacion;
      private int _IdUsuarioCancelacion;
      private string _CodigoPresupuesto;
      private DateTime _FechaCreacion;
      private int _IdUsuarioCreacion;
      private DateTime _FechaModificacion;
      private int _IdUsuarioModificacion;

      private string _NombreProyecto;
      private string _NombreSede;
      private string _NombreEstado;
      private string _NombreMoneda;
      private string _NombreSolicitante;
      private string _NombreTipoPedido;
      private string _OrdenCompra;
      private string _NombreEstadoControl;
      private string _FechaAprobacionTexto;

      //Constructor

      public PedidoDTO() { }

      public PedidoDTO(int _IdPedido, int _IdProyecto, int _IdSede, int _IdSolicitante, int _IdResponsableProyecto, int _IdTipoPedido, 
          string _CodMoneda,
          string _NumeroPedido, DateTime _FechaPedido, string _Descripcion, string _Observaciones, string _Estado, DateTime _FechaAprobacion, string _Cancelado, DateTime _FechaCancelacion, int _IdUsuarioCancelacion, DateTime _FechaCreacion, int _IdUsuarioCreacion, DateTime _FechaModificacion, int _IdUsuarioModificacion )
      {
          this._IdPedido = _IdPedido;
          this._IdProyecto = _IdProyecto;
          this._IdSede = _IdSede;
          this._IdSolicitante = _IdSolicitante;
          this._IdResponsableProyecto = _IdResponsableProyecto;
          this._IdTipoPedido = _IdTipoPedido;
          this._CodMoneda = _CodMoneda;
          this._NumeroPedido = _NumeroPedido;
          this._FechaPedido = _FechaPedido;
          this._Descripcion = _Descripcion;
          this._Observaciones = _Observaciones;
          this._Estado = _Estado;
          this._FechaAprobacion = _FechaAprobacion;
          this._Cancelado = _Cancelado;
          this._FechaCancelacion = _FechaCancelacion;
          this._IdUsuarioCancelacion = _IdUsuarioCancelacion;
          this._FechaCreacion = _FechaCreacion;
          this._IdUsuarioCreacion = _IdUsuarioCreacion;
          this._FechaModificacion = _FechaModificacion;
          this._IdUsuarioModificacion = _IdUsuarioModificacion;
      }

      //Get y Set
      public int IdPedido
      {
          get { return _IdPedido; }
          set { _IdPedido = value; }
      }
      public int IdProyecto
      {
          get { return _IdProyecto; }
          set { _IdProyecto = value; }
      }
      public int IdSede
      {
          get { return _IdSede; }
          set { _IdSede = value; }
      }
      public int IdSolicitante
      {
          get { return _IdSolicitante; }
          set { _IdSolicitante = value; }
      }
      public int IdResponsableProyecto
      {
          get { return _IdResponsableProyecto; }
          set { _IdResponsableProyecto = value; }
      }

      public int IdTipoPedido
      {
          get { return _IdTipoPedido; }
          set { _IdTipoPedido = value; }
      }

      public string CodMoneda
      {
          get { return _CodMoneda; }
          set { _CodMoneda = value; }
      }

      public string NumeroPedido
      {
          get { return _NumeroPedido; }
          set { _NumeroPedido = value; }
      }
      public DateTime FechaPedido
      {
          get { return _FechaPedido; }
          set { _FechaPedido = value; }
      }
      public string Descripcion
      {
          get { return _Descripcion; }
          set { _Descripcion = value; }
      }
      public string Observaciones
      {
          get { return _Observaciones; }
          set { _Observaciones = value; }
      }
      public string Estado
      {
          get { return _Estado; }
          set { _Estado = value; }
      }
      public DateTime FechaAprobacion
      {
          get { return _FechaAprobacion; }
          set { _FechaAprobacion = value; }
      }
      public string EstadoControl
      {
          get { return _EstadoControl; }
          set { _EstadoControl = value; }
      }

      
      public string Cancelado
      {
          get { return _Cancelado; }
          set { _Cancelado = value; }
      }
      public DateTime FechaCancelacion
      {
          get { return _FechaCancelacion; }
          set { _FechaCancelacion = value; }
      }
      public int IdUsuarioCancelacion
      {
          get { return _IdUsuarioCancelacion; }
          set { _IdUsuarioCancelacion = value; }
      }

      public string CodigoPresupuesto
      {
          get { return _CodigoPresupuesto; }
          set { _CodigoPresupuesto = value; }
      }
      
      public DateTime FechaCreacion
      {
          get { return _FechaCreacion; }
          set { _FechaCreacion = value; }
      }
      public int IdUsuarioCreacion
      {
          get { return _IdUsuarioCreacion; }
          set { _IdUsuarioCreacion = value; }
      }
      public DateTime FechaModificacion
      {
          get { return _FechaModificacion; }
          set { _FechaModificacion = value; }
      }
      public int IdUsuarioModificacion
      {
          get { return _IdUsuarioModificacion; }
          set { _IdUsuarioModificacion = value; }
      }

      //Extendido
      public string NombreProyecto
      {
          get { return _NombreProyecto; }
          set { _NombreProyecto = value; }
      }

      public string NombreSede
      {
          get { return _NombreSede; }
          set { _NombreSede = value; }
      }


      public string NombreEstado
      {
          get { return _NombreEstado; }
          set { _NombreEstado = value; }
      }

      public string NombreMoneda
      {
          get { return _NombreMoneda; }
          set { _NombreMoneda = value; }
      }

      public string NombreSolicitante
      {
          get { return _NombreSolicitante; }
          set { _NombreSolicitante = value; }
      }

      public string NombreTipoPedido
      {
          get { return _NombreTipoPedido; }
          set { _NombreTipoPedido = value; }
      }

      public string OrdenCompra
      {
          get { return _OrdenCompra; }
          set { _OrdenCompra = value; }
      }

      public string NombreEstadoControl
      {
          get { return _NombreEstadoControl; }
          set { _NombreEstadoControl = value; }
      }

      public string FechaAprobacionTexto
      {
          get { 
              if (_FechaAprobacion.Year == 1)
                  return ""; 
              else
                  return _FechaAprobacion.ToString("dd/MM/yyyy HH:mm:ss");
          }
      }
      
  }
}
