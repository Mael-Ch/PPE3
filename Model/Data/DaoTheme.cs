using Model.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Model.Data
{
    public class DaoTheme
    {
        private Dbal _dbal;

        public DaoTheme(Dbal dbal)
        {
            this._dbal = dbal;
        }
        public Theme GetThemeActuel(Salle s)
        {
            DataRow rowTs = this._dbal.Select("theme_salle",
                "salle = " + s.Id + " AND " +
                "dateDebut <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND " +
                "dateFin > '" + DateTime.Now.ToString("yyyy-MM-dd") + "'"
            ).Rows[0];
            DataRow row = this._dbal.SelectById("theme", (int)rowTs["theme"]);
            return new Theme(row);
        }

        public List<Theme> GetAllTheme()
        {
            DataTable tab = _dbal.Select("theme");
            List<Theme> lstT = new List<Theme>();
            foreach (DataRow row in tab.Rows)
            {
                lstT.Add(new Theme(row));
            }
            return lstT;
        }

        public void AssgneToSalle(Theme theme,ref Salle salle)
        {
            Theme themeActu = GetThemeActuel(salle);
            Dictionary<string, dynamic> dicA = new Dictionary<string, dynamic>();
            dicA.Add("dateFin",DateTime.Now);
            _dbal.Update("theme_salle",dicA,"salle = " + salle.Id + " AND theme = " + themeActu.Id);
            
            Dictionary<string, dynamic> dic = new Dictionary<string, dynamic>();
            dic.Add("salle", salle.Id);
            dic.Add("theme", theme.Id);
            dic.Add("dateDebut", DateTime.Now);
            _dbal.Insert("theme_salle",dic);

            salle.Theme = GetThemeActuel(salle);
        }

        public void Delete(Theme theme)
        {
            _dbal.Delete("theme","id = " + theme.Id);
        }

        public Theme New(Theme theme)
        {
            _dbal.Insert("theme",theme.ToArray());
            return new Theme(_dbal.Select("theme","nom = '" + theme.Nom + "'").Rows[0]);
        }
    }
}
