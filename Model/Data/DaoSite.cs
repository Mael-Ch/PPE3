using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model.Business;

namespace Model.Data
{
    public class DaoSite
    {
        private Dbal _dbal;
        private DaoSalle _daoSalle;

        public DaoSite(Dbal dbal)
        {
            _dbal = dbal;
            _daoSalle = new DaoSalle(dbal, this);
        }
        public List<Site> GetAllSite()
        {
            DataTable tab = this._dbal.Select("site");
            List<Site> lstS = new List<Site>();
            foreach (DataRow row in tab.Rows)
            {
                Site s = new Site(row);
                s.LstSalle = (_daoSalle.GetBySite(s));
                lstS.Add(s);
            }
            return lstS;
        }

        public Site GetById(int i)
        {
            return new Site(_dbal.SelectById("site", i));
        }
    }
}
