using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Model.Business
{
    public class Facture : IHydrate
    {
        private int _id;
        private DateTime _date;
        private double _montant;
        private int _nbCredit;
        
        private Client _client;
        
        public Facture(DataRow row, Client client)
        {
            Hydrate(row);
            _client = client;
        }

        public Facture(DateTime date, double montant, int nbCredit, Client client)
        {
            _id = 0;
            _date = date;
            _montant = montant;
            _nbCredit = nbCredit;
            _client = client;
        }

        #region Getter and Setter
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public DateTime Date
        {
            get => _date;
            set => _date = value;
        }

        public double Montant
        {
            get => _montant;
            set => _montant = value;
        }

        public int NbCredit
        {
            get => _nbCredit;
            set => _nbCredit = value;
        }

        public Client Client
        {
            get => _client;
            set => _client = value;
        }
        #endregion

        public void Hydrate(DataRow row)
        {
            _id = (int)row["id"];
            _date = (DateTime)row["date"];
            _montant = (double)row["montant"];
            _nbCredit = (int)row["nbCredit"];
        }
        public Dictionary<string, dynamic> ToArray()
        {
            Dictionary<string, dynamic> val = new Dictionary<string, dynamic>();
            val.Add("date", _date);
            val.Add("montant", _montant);
            val.Add("nbCredit", _nbCredit);
            val.Add("client", _client.Id);
            return val;
        }
    }
}