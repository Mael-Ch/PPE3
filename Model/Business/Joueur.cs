using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Model.Business
{
    public class Joueur : IHydrate
    {
        private int _id;
        private string _pseudo;
        private string _email;

        private List<Avis> _lstAvis;

        public Joueur(DataRow row, List<Avis> lstAvis)
        {
            Hydrate(row);
            foreach (Avis avis in lstAvis) avis.Joueur = this;
            _lstAvis = lstAvis;
        }
        public Joueur (string pseudo,string email)
        {
            _pseudo = pseudo;
            _email = email;
        }

        #region Getter and Setter

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Pseudo
        {
            get => _pseudo;
            set => _pseudo = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public List<Avis> LstAvis
        {
            get => _lstAvis;
            set
            {
                foreach (Avis avis in value) avis.Joueur = this;
                _lstAvis = value;
            }
        }

        #endregion

        public void Hydrate(DataRow row)
        {
            _id = (int)row["id"];
            _pseudo = (string)row["pseudo"];
            _email = (string)row["email"];
        }
        public Dictionary<string, dynamic> ToArray()
        {
            Dictionary<string, dynamic> val = new Dictionary<string, dynamic>();
            val.Add("pseudo", _pseudo);
            val.Add("email", _email);
            return val;
        }
        public override string ToString()
        {
            return this._pseudo+" ===> "+this._email;
        }
    }
}
