using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class InvArticuloProyectoDTO
  {

      //Propiedades
      private int _IdArticulo;
      private int _IdProyecto;
      private Decimal _Stock;
      private string _NombreProyecto;
      //Constructor

      public InvArticuloProyectoDTO() { }

      public InvArticuloProyectoDTO(int _IdArticulo, int _IdProyecto, Decimal _Stock )
      {
          this._IdArticulo = _IdArticulo;
          this._IdProyecto = _IdProyecto;
          this._Stock = _Stock;
      }

      //Get y Set
      public int IdArticulo
      {
          get { return _IdArticulo; }
          set { _IdArticulo = value; }
      }
      public int IdProyecto
      {
          get { return _IdProyecto; }
          set { _IdProyecto = value; }
      }
      
      public Decimal Stock
      {
          get { return _Stock; }
          set { _Stock = value; }
      }

      public string NombreProyecto
      {
          get { return _NombreProyecto; }
          set { _NombreProyecto = value; }
      }

  }
}
