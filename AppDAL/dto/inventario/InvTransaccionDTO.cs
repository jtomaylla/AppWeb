using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class InvTransaccionDTO
  {

      //Propiedades
      private int _IdTransaccion;
      private int _IdArticulo;
      private int _IdAlmacen;
      private int _IdTipoTransaccion;
      private DateTime _Fecha;
      private Decimal _Cantidad;
      private Decimal _CostoUnitario;
      private Decimal _Costo;
      private string _TipoOrigen;
      private int _IdTransaccionOrigen;
      private int _IdLineaOrigen;
      private string _Descripcion;

      private int _IdSede;
      private int _IdProyecto;
      private DateTime _FechaVencimiento;
      private string _Ubicacion;
      private string _Marca;
      private string _Modelo;
      private string _Serie;
      private string _Lote;
      private string _ObservacionesAlmacenamiento;

      private int _IdUsuarioCreacion;
      private DateTime _FechaCreacion;
      private int _IdUsuarioModificador;
      private DateTime _FechaModificacion;

      private string _NombreTransaccion;
      
      //Constructor

      public InvTransaccionDTO() { }

      public InvTransaccionDTO(int _IdTransaccion, int _IdArticulo, int _IdAlmacen, int _IdTipoTransaccion, DateTime _Fecha, Decimal _Cantidad, Decimal _CostoUnitario, Decimal _Costo, string _TipoOrigen, int _IdTransaccionOrigen, int _IdLineaOrigen, string _Descripcion, int _IdUsuarioCreacion, DateTime _FechaCreacion, int _IdUsuarioModificador, DateTime _FechaModificacion )
      {
          this._IdTransaccion = _IdTransaccion;
          this._IdArticulo = _IdArticulo;
          this._IdAlmacen = _IdAlmacen;
          this._IdTipoTransaccion = _IdTipoTransaccion;
          this._Fecha = _Fecha;
          this._Cantidad = _Cantidad;
          this._CostoUnitario = _CostoUnitario;
          this._Costo = _Costo;
          this._TipoOrigen = _TipoOrigen;
          this._IdTransaccionOrigen = _IdTransaccionOrigen;
          this._IdLineaOrigen = _IdLineaOrigen;
          this._Descripcion = _Descripcion;
          this._IdUsuarioCreacion = _IdUsuarioCreacion;
          this._FechaCreacion = _FechaCreacion;
          this._IdUsuarioModificador = _IdUsuarioModificador;
          this._FechaModificacion = _FechaModificacion;
      }

      //Get y Set
      public int IdTransaccion
      {
          get { return _IdTransaccion; }
          set { _IdTransaccion = value; }
      }
      public int IdArticulo
      {
          get { return _IdArticulo; }
          set { _IdArticulo = value; }
      }
      public int IdAlmacen
      {
          get { return _IdAlmacen; }
          set { _IdAlmacen = value; }
      }
      public int IdTipoTransaccion
      {
          get { return _IdTipoTransaccion; }
          set { _IdTipoTransaccion = value; }
      }
      public DateTime Fecha
      {
          get { return _Fecha; }
          set { _Fecha = value; }
      }
      public Decimal Cantidad
      {
          get { return _Cantidad; }
          set { _Cantidad = value; }
      }
      public Decimal CostoUnitario
      {
          get { return _CostoUnitario; }
          set { _CostoUnitario = value; }
      }
      public Decimal Costo
      {
          get { return _Costo; }
          set { _Costo = value; }
      }
      public string TipoOrigen
      {
          get { return _TipoOrigen; }
          set { _TipoOrigen = value; }
      }
      public int IdTransaccionOrigen
      {
          get { return _IdTransaccionOrigen; }
          set { _IdTransaccionOrigen = value; }
      }
      public int IdLineaOrigen
      {
          get { return _IdLineaOrigen; }
          set { _IdLineaOrigen = value; }
      }
      public string Descripcion
      {
          get { return _Descripcion; }
          set { _Descripcion = value; }
      }
      public int IdUsuarioCreacion
      {
          get { return _IdUsuarioCreacion; }
          set { _IdUsuarioCreacion = value; }
      }
      public DateTime FechaCreacion
      {
          get { return _FechaCreacion; }
          set { _FechaCreacion = value; }
      }
      public int IdUsuarioModificador
      {
          get { return _IdUsuarioModificador; }
          set { _IdUsuarioModificador = value; }
      }
      public DateTime FechaModificacion
      {
          get { return _FechaModificacion; }
          set { _FechaModificacion = value; }
      }

      public string NombreTransaccion
      {
          get { return _NombreTransaccion; }
          set { _NombreTransaccion = value; }
      }

      public int IdSede
      {
          get { return _IdSede; }
          set { _IdSede = value; }
      }

      public int IdProyecto
      {
          get { return _IdProyecto; }
          set { _IdProyecto = value; }
      }
      
      public DateTime FechaVencimiento
      {
          get { return _FechaVencimiento; }
          set { _FechaVencimiento = value; }
      }
      
      public string Ubicacion
      {
          get { return _Ubicacion; }
          set { _Ubicacion = value; }
      }
      
      public string Marca
      {
          get { return _Marca; }
          set { _Marca = value; }
      }
      
      public string Modelo
      {
          get { return _Modelo; }
          set { _Modelo = value; }
      }
      
      public string Serie
      {
          get { return _Serie; }
          set { _Serie = value; }
      }
      
      public string Lote
      {
          get { return _Lote; }
          set { _Lote = value; }
      }
      
      public string ObservacionesAlmacenamiento
      {
          get { return _ObservacionesAlmacenamiento; }
          set { _ObservacionesAlmacenamiento = value; }
      }

  }
}
