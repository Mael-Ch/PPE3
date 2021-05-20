using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Model.Business
{
    public class Client : IHydrate
    {
        private int _id;
        private string _nom;
        private string _prenom;
        private string _photo;
        private string _email;
        private string _tel;
        private DateTime _naissance;
        private int _credit;
        private string _adresse;
        
        private List<Facture> _lstFacture;
        private List<Reservation> _lstReservation;

        public Client(DataRow row, List<Facture> lstFacture, List<Reservation> lstReservation)
        {
            Hydrate(row);
            foreach (Facture facture in lstFacture) facture.Client = this;
            _lstFacture = lstFacture;
            foreach (Reservation reservation in lstReservation) reservation.Client = this;
            _lstReservation = lstReservation;
        }
        public Client(string nom, string prenom, DateTime datedenaissance, string email, string numero, string adresse, int credit)
        {
            _nom = nom;
            _prenom = prenom;
            _naissance = datedenaissance;
            _email = email;
            _tel = numero;
            _adresse = adresse;
            _credit = credit;
            _photo = "default.png";
        }

        public Client()
        {
            _id = 0;
        }
        public Client(DataRow row)
        {
            Hydrate(row);
        }

        #region Getter and Setter

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

        public string Prenom
        {
            get => _prenom;
            set => _prenom = value;
        }

        public string Photo
        {
            get => _photo;
            set => _photo = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string Tel
        {
            get => _tel;
            set => _tel = value;
        }

        public DateTime Naissance
        {
            get => _naissance;
            set => _naissance = value;
        }

        public int Credit
        {
            get => _credit;
            set => _credit = value;
        }

        public string Adresse
        {
            get => _adresse;
            set => _adresse = value;
        }

        public List<Facture> LstFacture
        {
            get => _lstFacture;
            set => _lstFacture = value;
        }

        public List<Reservation> LstReservation
        {
            get => _lstReservation;
            set => _lstReservation = value;
        }

        #endregion

        public void Hydrate(DataRow row)
        {
            _id = (int)row["id"];
            _nom = (string)row["nom"];
            _prenom = (string)row["prenom"];
            _photo = (string)row["photo"];
            _email = (string)row["email"];
            _tel = (string)row["tel"];
            _naissance = (DateTime)row["naissance"];
            _credit = (int)row["credit"];
            _adresse = (string)row["adresse"];
        }
        public Dictionary<string, dynamic> ToArray()
        {
            Dictionary<string, dynamic> val = new Dictionary<string, dynamic>();
            val.Add("nom", _nom);
            val.Add("prenom", _prenom);
            val.Add("photo", _photo);
            val.Add("email", _email);
            val.Add("tel", _tel);
            val.Add("naissance", _naissance);
            val.Add("credit", _credit);
            val.Add("adresse", _adresse);
            return val;
        }
        public override string ToString()
        {
            return this._nom + " " + _prenom + " " + _email;
        }
    }
}
