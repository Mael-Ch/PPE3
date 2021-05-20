using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Model.Business
{
    public class Partie : IHydrate
    {
        private int _id;
        private DateTime _date;
        private TimeSpan _temps;
        private bool _win;

        private Horaire _horaire;
        private Salle _salle;
        private List<Joueur> _lstJoueur;
        private List<Obstacle> _lstObstacle; // L'indice correspond à la position (0 à 11)

        public Partie(Salle salle, Horaire horaire, DateTime jour)
        {
            _id = 0;
           _date = jour;
           _temps = new TimeSpan();
           _win = false;
           _horaire = horaire;
           _salle = salle;
           _lstJoueur = new List<Joueur>();
           _lstObstacle = new List<Obstacle>();
        }
        public Partie()
        {

        }
        public Partie(DataRow row)
        {
            Hydrate(row);
        }

        public Partie(DataRow row, Horaire horaire, Salle salle)
        {
            Hydrate(row);
            _salle = salle;
            _horaire = horaire;
        }
        public Partie(DataRow row, Horaire horaire)
        {
            Hydrate(row);
            _horaire = horaire;
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

        public TimeSpan Temps
        {
            get => _temps;
            set => _temps = value;
        }

        public bool Win
        {
            get => _win;
            set => _win = value;
        }

        public Salle Salle
        {
            get => _salle;
            set => _salle = value;
        }

        public List<Joueur> LstJoueur
        {
            get => _lstJoueur;
            set => _lstJoueur = value;
        }

        public List<Obstacle> LstObstacle
        {
            get => _lstObstacle;
            set => _lstObstacle = value;
        }

        #endregion
        
        public void Hydrate(DataRow row)
        {
            _id = (int)row["id"];
            _date = (DateTime)row["date"];
            _temps = (TimeSpan)row["temps"];
            //_win = (int)row["win"];
           _win = (bool)row["win"];
           
            
            
        }
        public Dictionary<string, dynamic> ToArray()
        {
            Dictionary<string, dynamic> val = new Dictionary<string, dynamic>();
            val.Add("date", _date);
            val.Add("horaire", _horaire.Id);
            val.Add("temps", _temps);
            val.Add("win", _win);
            val.Add("salle", _salle.Id);
            return val;
        }

        public override string ToString()
        {
            return _id + "===>" + _horaire.Heure;
        }
    }
}
