using System;
using System.Collections.Generic;
using System.Data;

namespace Model.Business
{
    public class Horaire : IHydrate
    {
        private int _id;
        private TimeSpan _heure;

        public Horaire(DataRow row)
        {
            Hydrate(row);
        }

        public Horaire()
        {
            _id = 0;
            _heure = new TimeSpan();
        }
        public Horaire(TimeSpan heure)
        {
            _id = 0;
            _heure = heure;
        }

        #region Getter and Setter

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public TimeSpan Heure
        {
            get => _heure;
            set => _heure = value;
        }

        #endregion

        public void Hydrate(DataRow row)
        {
            _id = (int)row["id"];
            _heure = (TimeSpan)row["heure"];
        }

        public Dictionary<string, dynamic> ToArray()
        {
            Dictionary<string, dynamic> tab = new Dictionary<string, dynamic>();
            tab.Add("heure", _heure.ToString());
            return tab;
        }

        public override string ToString()
        {
            return _heure.ToString("g");
        }
    }
}