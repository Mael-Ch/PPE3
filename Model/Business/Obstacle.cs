using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Model.Business
{
    public class Obstacle : IHydrate
    {
        private int _id;
        private string _nom;
        private string _type;
        private string _description;
        private string _photo;

        public Obstacle(DataRow row)
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

        public string Type
        {
            get => _type;
            set => _type = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public string Photo
        {
            get => _photo;
            set => _photo = value;
        }

        #endregion

        public void Hydrate(DataRow row)
        {
            _id = (int)row["id"];
            _nom = (string)row["nom"];
            _type = (string)row["type"];
            _description = (string)row["description"];
            _photo = (string)row["photo"];
        }
        public Dictionary<string, dynamic> ToArray()
        {
            Dictionary<string, dynamic> val = new Dictionary<string, dynamic>();
            val.Add("nom", _nom);
            val.Add("type", _type);
            val.Add("description", _description);
            val.Add("photo", _photo);
            return val;
        }
        public override string ToString()
        {
            return this.Id + " ===> " + this.Nom+"-"+this.Type;
        }
    }
}
