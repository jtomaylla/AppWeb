using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pe.com.sil.dal.dto
{
  public class InvFamiliaDTO
  {

      //Propiedades
      private int _IdFamilia;
      private string _CodFamilia;
      private string _NombreFamilia;
      private string _Estado;

      //Constructor

      public InvFamiliaDTO() { }

      public InvFamiliaDTO(int _IdFamilia, string _CodFamilia, string _NombreFamilia, string _Estado )
      {
          this._IdFamilia = _IdFamilia;
          this._CodFamilia = _CodFamilia;
          this._NombreFamilia = _NombreFamilia;
          this._Estado = _Estado;
      }

      //Get y Set
      public int IdFamilia
      {
          get { return _IdFamilia; }
          set { _IdFamilia = value; }
      }
      public string CodFamilia
      {
          get { return _CodFamilia; }
          set { _CodFamilia = value; }
      }
      public string NombreFamilia
      {
          get { return _NombreFamilia; }
          set { _NombreFamilia = value; }
      }
      public string Estado
      {
          get { return _Estado; }
          set { _Estado = value; }
      }

	public Boolean EstadoBool
	{
		get
		{
			if (_Estado == "1")
				return true;
			else
				return false;
		}
	}

  }
}
