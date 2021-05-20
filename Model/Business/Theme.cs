using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Model.Business
{
    public class Theme : IHydrate
    {
        private int _id;
        private string _nom;
        
        public Theme(DataRow row)
        {
            Hydrate(row);
        }

        public Theme(string nom = "")
        {
            _id = 0;
            _nom = nom;
        }

        #region MyRegion

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Nom
        {
            get => _nom;
            set => _nom = value;
        }

        #endregion

        public void Hydrate(DataRow row)
        {
            _id = (int)row["id"];
            _nom = (string)row["nom"];
        }
        public Dictionary<string, dynamic> ToArray()
        {
            Dictionary<string, dynamic> val = new Dictionary<string, dynamic>();
            val.Add("nom", _nom);
            return val;
        }

        public override string ToString()
        {
            return _nom;
        }
    }
}
