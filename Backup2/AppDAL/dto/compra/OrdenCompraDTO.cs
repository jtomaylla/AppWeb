using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class OrdenCompraDTO
  {

      //Propiedades
      private int _IdOrdenCompra;
      private int _IdProyecto;
      private int _IdSede;
      private int _IdProveedor;
      private string _NumeroOrdenCompra;
      private DateTime _FechaOrdenCompra;
      private string _DescripcionOrdenCompra;
      private string _CodMoneda;
      private Decimal _ImporteOrdenCompra;
      private int _IdFormaPago;
      private string _FlagIGV;

      private int _IdCotizacion;
      string _EstadoControl;
      string _EstadoAprobacion;
      DateTime _FechaAprobacion;
      int _IdUsuarioAprobacion;

      string _EnviadoProveedor;
      DateTime _FechaEnvioProveedor;
      string _ComentariosEnvioProveedor;
      private DateTime _FechaEntrega;
      int _IdTipoOrdenCompra;

      //CESAR BOCANEGRA
      private string _NroCotizProv;



      private DateTime _FechaCreacion;
      private int _IdUsuarioCreacion;
      private DateTime _FechaModificacion;
      private int _IdUsuarioModificacion;

      

      //Extendido
      private string _NombreProyecto;
      private string _NombreSede;
      private string _NombreMoneda;
      private string _RazonSocial;
      private string _NombreEstadoAprobacion;
      private string _NombreEstadoControl;
      private string _NombreTipoOrdenCompra;

      private Decimal _totalitems;


      private Decimal _recepcionadoitems;



      
      //Constructor

      public OrdenCompraDTO() { }

      public OrdenCompraDTO(int _IdOrdenCompra, int _IdProyecto, int _IdSede, int _IdProveedor, string _NumeroOrdenCompra, DateTime _FechaOrdenCompra, string _DescripcionOrdenCompra, string _CodMoneda, Decimal _ImporteOrdenCompra, int _IdTerminoPago, DateTime _FechaCreacion, int _IdUsuarioCreacion, DateTime _FechaModificacion, int _IdUsuarioModificacion )
      {
          this._IdOrdenCompra = _IdOrdenCompra;
          this._IdProyecto = _IdProyecto;
          this._IdSede = _IdSede;
          this._IdProveedor = _IdProveedor;
          this._NumeroOrdenCompra = _NumeroOrdenCompra;
          this._FechaOrdenCompra = _FechaOrdenCompra;
          this._DescripcionOrdenCompra = _DescripcionOrdenCompra;
          this._CodMoneda = _CodMoneda;
          this._ImporteOrdenCompra = _ImporteOrdenCompra;
          this._IdFormaPago = _IdTerminoPago;
          this._FechaCreacion = _FechaCreacion;
          this._IdUsuarioCreacion = _IdUsuarioCreacion;
          this._FechaModificacion = _FechaModificacion;
          this._IdUsuarioModificacion = _IdUsuarioModificacion;
      }

      //Get y Set
      public int IdOrdenCompra
      {
          get { return _IdOrdenCompra; }
          set { _IdOrdenCompra = value; }
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
      public int IdProveedor
      {
          get { return _IdProveedor; }
          set { _IdProveedor = value; }
      }
      public string NumeroOrdenCompra
      {
          get { return _NumeroOrdenCompra; }
          set { _NumeroOrdenCompra = value; }
      }
      public DateTime FechaOrdenCompra
      {
          get { return _FechaOrdenCompra; }
          set { _FechaOrdenCompra = value; }
      }
      public string DescripcionOrdenCompra
      {
          get { return _DescripcionOrdenCompra; }
          set { _DescripcionOrdenCompra = value; }
      }
      public string CodMoneda
      {
          get { return _CodMoneda; }
          set { _CodMoneda = value; }
      }
      public Decimal ImporteOrdenCompra
      {
          get { return _ImporteOrdenCompra; }
          set { _ImporteOrdenCompra = value; }
      }
      public int IdFormaPago
      {
          get { return _IdFormaPago; }
          set { _IdFormaPago = value; }
      }

      public int IdCotizacion
      {
          get { return _IdCotizacion; }
          set { _IdCotizacion = value; }
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

      public string EstadoControl
      {
          get { return _EstadoControl; }
          set { _EstadoControl = value; }
      }

      public string EstadoAprobacion
      {
          get { return _EstadoAprobacion; }
          set { _EstadoAprobacion = value; }
      }

      public DateTime FechaAprobacion
      {
          get { return _FechaAprobacion; }
          set { _FechaAprobacion = value; }
      }

      public int IdUsuarioAprobacion
      {
          get { return _IdUsuarioAprobacion; }
          set { _IdUsuarioAprobacion = value; }
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

      public string NombreMoneda
      {
          get { return _NombreMoneda; }
          set { _NombreMoneda = value; }
      }

      public string RazonSocial
      {
          get { return _RazonSocial; }
          set { _RazonSocial = value; }
      }

      public string NombreEstadoAprobacion
      {
          get { return _NombreEstadoAprobacion; }
          set { _NombreEstadoAprobacion = value; }
      }

      public string NombreEstadoControl
      {
          get { return _NombreEstadoControl; }
          set { _NombreEstadoControl = value; }
      }

      
      public string EnviadoProveedor
      {
          get { return _EnviadoProveedor; }
          set { _EnviadoProveedor = value; }
      }

      public DateTime FechaEnvioProveedor
      {
          get { return _FechaEnvioProveedor; }
          set { _FechaEnvioProveedor = value; }
      }

      public string ComentariosEnvioProveedor
      {
          get { return _ComentariosEnvioProveedor; }
          set { _ComentariosEnvioProveedor = value; }
      }

      public DateTime FechaEntrega
      {
          get { return _FechaEntrega; }
          set { _FechaEntrega = value; }
      }

      public int IdTipoOrdenCompra
      {
          get { return _IdTipoOrdenCompra; }
          set { _IdTipoOrdenCompra = value; }
      }

      public string NombreTipoOrdenCompra
      {
          get { return _NombreTipoOrdenCompra; }
          set { _NombreTipoOrdenCompra = value; }
      }

      public string FlagIGV
      {
          get { return _FlagIGV; }
          set { _FlagIGV = value; }
      }

      public string NroCotizProv
      {
          get { return _NroCotizProv; }
          set { _NroCotizProv = value; }
      }

      public Decimal Totalitems
      {
          get { return _totalitems; }
          set { _totalitems = value; }
      }

      public Decimal Recepcionadoitems
      {
          get { return _recepcionadoitems; }
          set { _recepcionadoitems = value; }
      }

      public Boolean FlagIGVBool
      {
          get
          {
              if (_FlagIGV == "1")
                  return true;
              else
                  return false;
          }
      }
      
  }
}
