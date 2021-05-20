using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Model.Business
{
    public class Reservation : IHydrate
    {
        private int _id;
        private int _montant;
        private DateTime _date;
        private Client _client;
        private Partie _partie;

        public Reservation(DataRow row, Client c, Partie p)
        {
            Hydrate(row);
            _client = c;
            _partie = p;
        }
        
        #region Getter and Setter
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public int Montant
        {
            get => _montant;
            set => _montant = value;
        }

        public DateTime Date
        {
            get => _date;
            set => _date = value;
        }

        public Client Client
        {
            get => _client;
            set => _client = value;
        }

        public Partie Partie
        {
            get => _partie;
            set => _partie = value;
        }
#endregion
        
        public void Hydrate(DataRow row)
        {
            _id = (int) row["id"];
            _montant = (int)row["montant"];
            _date = (DateTime)row["date"];
        }
        public Dictionary<string, dynamic> ToArray()
        {
            Dictionary<string, dynamic> val = new Dictionary<string, dynamic>();
            val.Add("id", _id);
            val.Add("montant", _montant);
            val.Add("date", _date);
            val.Add("client", _client.Id);
            val.Add("partie", _partie.Id);
            return val;
        }
    }
}
