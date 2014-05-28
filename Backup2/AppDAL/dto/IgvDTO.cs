using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class IgvDTO
  {

      //Propiedades
      private int _IdRegistro;
      private Decimal _Igv;
      private string _Descripcion;
      private DateTime _FechaInicio;
      private DateTime _FechaFin;

      //Constructor

      public IgvDTO() { }

      public IgvDTO(int _IdRegistro, Decimal _Igv, string _Descripcion, DateTime _FechaInicio, DateTime _FechaFin )
      {
          this._IdRegistro = _IdRegistro;
          this._Igv = _Igv;
          this._Descripcion = _Descripcion;
          this._FechaInicio = _FechaInicio;
          this._FechaFin = _FechaFin;
      }

      //Get y Set
      public int IdRegistro
      {
          get { return _IdRegistro; }
          set { _IdRegistro = value; }
      }
      public Decimal Igv
      {
          get { return _Igv; }
          set { _Igv = value; }
      }
      public string Descripcion
      {
          get { return _Descripcion; }
          set { _Descripcion = value; }
      }
      public DateTime FechaInicio
      {
          get { return _FechaInicio; }
          set { _FechaInicio = value; }
      }
      public DateTime FechaFin
      {
          get { return _FechaFin; }
          set { _FechaFin = value; }
      }
  }
}
