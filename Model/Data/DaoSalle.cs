using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using Model.Business;

namespace Model.Data
{
    public class DaoSalle
    {
        private Dbal _dbal;
        private DaoSite _daoSite;
        private DaoTheme _daoTheme;

        public DaoSalle(Dbal dbal)
        {
            _dbal = dbal;
            _daoSite = new DaoSite(dbal);
            _daoTheme = new DaoTheme(dbal);
        }
        public DaoSalle(Dbal dbal, DaoSite daoSite)
        {
            _dbal = dbal;
            _daoSite = daoSite;
            _daoTheme = new DaoTheme(dbal);
        }
        public List<Salle> GetBySite(Site site)
        {
            DataTable tab = _dbal.Select("salle", "site = " + site.Id);
            List<Salle> lst = new List<Salle>();
            foreach (DataRow row in tab.Rows)
            {
                Salle s = new Salle(row);
                s.Site = site;
                s.Theme = _daoTheme.GetThemeActuel(s);
                lst.Add(s);
            }
            return lst;
        }

        public List<Salle> GetAll()
        {
            DataTable tab = _dbal.Select("salle");
            List<Salle> lst = new List<Salle>();
            foreach (DataRow row in tab.Rows)
            {
                Salle s = new Salle(row);
                s.Site = _daoSite.GetById((int)row["site"]);
                s.Theme = _daoTheme.GetThemeActuel(s);
                lst.Add(s);
            }
            return lst;
        }
    }
}
