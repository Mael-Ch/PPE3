using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Model.Business
{
    public class Salle : IHydrate
    {
        private int _id;
        private Site _site;
        private Theme _theme;

      
        public Salle(DataRow row)
        {
            Hydrate(row);
        }

        public Salle()
        {
            _id = 0;
            _site = new Site();
            _theme = new Theme();
        }

        #region Getter and Setter

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public Site Site
        {
            get => _site;
            set => _site = value;
        }

        public Theme Theme
        {
            get => _theme;
            set => _theme = value;
        }

        #endregion
        
        public void Hydrate(DataRow row)
        {
            _id = (int)row["id"];
        }
        public Dictionary<string, dynamic> ToArray()
        {
            Dictionary<string, dynamic> val = new Dictionary<string, dynamic>();
            val.Add("site", _site.Id);
            return val;
        }
        public override string ToString()
        {
            return "[" + _id + "] " + _theme.Nom;
        }
    }
}
