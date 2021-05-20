using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Intrinsics.X86;
using System.Text;
using Model.Business;

namespace Model.Data
{
    public class DaoFacture
    {
        private Dbal _dbal;

        public DaoFacture(Dbal dbal)
        {
            _dbal = dbal;
        }
        
        public void NouvelleFacture(Facture f)
        {
            _dbal.Insert("facture", f.ToArray());
        }
    }
}
