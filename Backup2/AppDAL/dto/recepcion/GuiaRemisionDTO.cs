using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class GuiaRemisionDTO
  {

      //Propiedades
      private int _IdGuiaRemision;
      private int _IdPuntoPartida;
      private int _IdPuntoLlegada;
      private DateTime _FechaEmision;
      private DateTime _FechaInicioTraslado;
      private string _RazonSocialDestinatario;
      private string _RucDestinatario;
      private string _RazonSocialTransportista;
      private string _RucTransportista;
      private string _Marca;
      private string _Placa;
      private string _Certificado;
      private string _Licencia;
      private string _NumeroComprobantePago;
      private string _Serie;
      private string _Numero;

      private string _Impreso;
      private DateTime _FechaImpresion;
      private int _IdDespacho;
      
      private int _IdUsuarioCreacion;
      private DateTime _FechaCreacion;
      private int _IdUsuarioModificacion;
      private DateTime _FechaModificacion;

      //Constructor

      public GuiaRemisionDTO() { }

      public GuiaRemisionDTO(int _IdGuiaRemision, int _IdPuntoPartida, int _IdPuntoLlegada, DateTime _FechaEmision, DateTime _FechaInicioTraslado, string _RazonSocialDestinatario, string _RucDestinatario, string _RazonSocialTransportista, string _RucTransportista, string _Marca, string _Placa, string _Certificado, string _Licencia, string _NumeroComprobantePago, string _Serie, string _Numero, int _IdUsuarioCreacion, DateTime _FechaCreacion, int _IdUsuarioModificacion, DateTime _FechaModificacion )
      {
          this._IdGuiaRemision = _IdGuiaRemision;
          this._IdPuntoPartida = _IdPuntoPartida;
          this._IdPuntoLlegada = _IdPuntoLlegada;
          this._FechaEmision = _FechaEmision;
          this._FechaInicioTraslado = _FechaInicioTraslado;
          this._RazonSocialDestinatario = _RazonSocialDestinatario;
          this._RucDestinatario = _RucDestinatario;
          this._RazonSocialTransportista = _RazonSocialTransportista;
          this._RucTransportista = _RucTransportista;
          this._Marca = _Marca;
          this._Placa = _Placa;
          this._Certificado = _Certificado;
          this._Licencia = _Licencia;
          this._NumeroComprobantePago = _NumeroComprobantePago;
          this._Serie = _Serie;
          this._Numero = _Numero;
          this._IdUsuarioCreacion = _IdUsuarioCreacion;
          this._FechaCreacion = _FechaCreacion;
          this._IdUsuarioModificacion = _IdUsuarioModificacion;
          this._FechaModificacion = _FechaModificacion;
      }

      //Get y Set
      public int IdGuiaRemision
      {
          get { return _IdGuiaRemision; }
          set { _IdGuiaRemision = value; }
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
      public string RazonSocialDestinatario
      {
          get { return _RazonSocialDestinatario; }
          set { _RazonSocialDestinatario = value; }
      }
      public string RucDestinatario
      {
          get { return _RucDestinatario; }
          set { _RucDestinatario = value; }
      }
      public string RazonSocialTransportista
      {
          get { return _RazonSocialTransportista; }
          set { _RazonSocialTransportista = value; }
      }
      public string RucTransportista
      {
          get { return _RucTransportista; }
          set { _RucTransportista = value; }
      }
      public string Marca
      {
          get { return _Marca; }
          set { _Marca = value; }
      }
      public string Placa
      {
          get { return _Placa; }
          set { _Placa = value; }
      }
      public string Certificado
      {
          get { return _Certificado; }
          set { _Certificado = value; }
      }
      public string Licencia
      {
          get { return _Licencia; }
          set { _Licencia = value; }
      }
      public string NumeroComprobantePago
      {
          get { return _NumeroComprobantePago; }
          set { _NumeroComprobantePago = value; }
      }
      public string Serie
      {
          get { return _Serie; }
          set { _Serie = value; }
      }
      public string Numero
      {
          get { return _Numero; }
          set { _Numero = value; }
      }

      public string Impreso
      {
          get { return _Impreso; }
          set { _Impreso = value; }
      }

      public DateTime FechaImpresion
      {
          get { return _FechaImpresion; }
          set { _FechaImpresion = value; }
      }

      public int IdDespacho
      {
          get { return _IdDespacho; }
          set { _IdDespacho = value; }
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
      public int IdUsuarioModificacion
      {
          get { return _IdUsuarioModificacion; }
          set { _IdUsuarioModificacion = value; }
      }
      public DateTime FechaModificacion
      {
          get { return _FechaModificacion; }
          set { _FechaModificacion = value; }
      }
  }
}
