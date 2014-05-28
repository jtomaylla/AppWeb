using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class RecepcionRemisionDTO
  {

      //Propiedades
      private int _IdRecepcionRemision;
      private string _NumeroSerie;
      private int _NumeroCorretativoSerie;
      private int _IdPuntoPartida;
      private int _IdPuntoLlegada;
      private DateTime _FechaEmision;
      private DateTime _FechaInicioTraslado;
      private string _Destinatario;
      private string _RucDestinatario;
      private string _Transportista;
      private string _RucTransportista;
      private string _MarcaUnidadTransporte;
      private string _NumeroPlacaTrasporte;
      private string _NumeroLicenciaConducir;
      private string _NumeroCertificadoInscripcion;
      private string _Estado;
      private int _IdRecepcion;
      private string _UsuarioCreacion;
      private DateTime _FechaCreacion;
      private string _UsuarioModificacion;
      private DateTime _FechaModificacion;

      //Constructor

      public RecepcionRemisionDTO() { }

      public RecepcionRemisionDTO(int _IdRecepcionRemision, string _NumeroSerie, int _NumeroCorretativoSerie, int _IdPuntoPartida, int _IdPuntoLlegada, DateTime _FechaEmision, DateTime _FechaInicioTraslado, string _Destinatario, string _RucDestinatario, string _Transportista, string _RucTransportista, string _MarcaUnidadTransporte, string _NumeroPlacaTrasporte, string _NumeroLicenciaConducir, string _NumeroCertificadoInscripcion, string _Estado, int _IdRecepcion, string _UsuarioCreacion, DateTime _FechaCreacion, string _UsuarioModificacion, DateTime _FechaModificacion )
      {
          this._IdRecepcionRemision = _IdRecepcionRemision;
          this._NumeroSerie = _NumeroSerie;
          this._NumeroCorretativoSerie = _NumeroCorretativoSerie;
          this._IdPuntoPartida = _IdPuntoPartida;
          this._IdPuntoLlegada = _IdPuntoLlegada;
          this._FechaEmision = _FechaEmision;
          this._FechaInicioTraslado = _FechaInicioTraslado;
          this._Destinatario = _Destinatario;
          this._RucDestinatario = _RucDestinatario;
          this._Transportista = _Transportista;
          this._RucTransportista = _RucTransportista;
          this._MarcaUnidadTransporte = _MarcaUnidadTransporte;
          this._NumeroPlacaTrasporte = _NumeroPlacaTrasporte;
          this._NumeroLicenciaConducir = _NumeroLicenciaConducir;
          this._NumeroCertificadoInscripcion = _NumeroCertificadoInscripcion;
          this._Estado = _Estado;
          this._IdRecepcion = _IdRecepcion;
          this._UsuarioCreacion = _UsuarioCreacion;
          this._FechaCreacion = _FechaCreacion;
          this._UsuarioModificacion = _UsuarioModificacion;
          this._FechaModificacion = _FechaModificacion;
      }

      //Get y Set
      public int IdRecepcionRemision
      {
          get { return _IdRecepcionRemision; }
          set { _IdRecepcionRemision = value; }
      }
      public string NumeroSerie
      {
          get { return _NumeroSerie; }
          set { _NumeroSerie = value; }
      }
      public int NumeroCorretativoSerie
      {
          get { return _NumeroCorretativoSerie; }
          set { _NumeroCorretativoSerie = value; }
      }
      public int IdPuntoPartida
      {
          get { return _IdPuntoPartida; }
          set { _IdPuntoPartida = value; }
      }
      public int IdPuntoLlegada
      {
          get { return _IdPuntoLlegada; }
          set { _IdPuntoLlegada = value; }
      }
      public DateTime FechaEmision
      {
          get { return _FechaEmision; }
          set { _FechaEmision = value; }
      }
      public DateTime FechaInicioTraslado
      {
          get { return _FechaInicioTraslado; }
          set { _FechaInicioTraslado = value; }
      }
      public string Destinatario
      {
          get { return _Destinatario; }
          set { _Destinatario = value; }
      }
      public string RucDestinatario
      {
          get { return _RucDestinatario; }
          set { _RucDestinatario = value; }
      }
      public string Transportista
      {
          get { return _Transportista; }
          set { _Transportista = value; }
      }
      public string RucTransportista
      {
          get { return _RucTransportista; }
          set { _RucTransportista = value; }
      }
      public string MarcaUnidadTransporte
      {
          get { return _MarcaUnidadTransporte; }
          set { _MarcaUnidadTransporte = value; }
      }
      public string NumeroPlacaTrasporte
      {
          get { return _NumeroPlacaTrasporte; }
          set { _NumeroPlacaTrasporte = value; }
      }
      public string NumeroLicenciaConducir
      {
          get { return _NumeroLicenciaConducir; }
          set { _NumeroLicenciaConducir = value; }
      }
      public string NumeroCertificadoInscripcion
      {
          get { return _NumeroCertificadoInscripcion; }
          set { _NumeroCertificadoInscripcion = value; }
      }
      public string Estado
      {
          get { return _Estado; }
          set { _Estado = value; }
      }
      public int IdRecepcion
      {
          get { return _IdRecepcion; }
          set { _IdRecepcion = value; }
      }
      public string UsuarioCreacion
      {
          get { return _UsuarioCreacion; }
          set { _UsuarioCreacion = value; }
      }
      public DateTime FechaCreacion
      {
          get { return _FechaCreacion; }
          set { _FechaCreacion = value; }
      }
      public string UsuarioModificacion
      {
          get { return _UsuarioModificacion; }
          set { _UsuarioModificacion = value; }
      }
      public DateTime FechaModificacion
      {
          get { return _FechaModificacion; }
          set { _FechaModificacion = value; }
      }
  }
}
