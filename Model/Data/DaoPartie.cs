using Model.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySqlX.XDevAPI.Relational;

namespace Model.Data
{
    public class DaoPartie
    {
        private Dbal _dbal;
        private DaoSalle _daoSalle;
        private DaoObstacle _daoObstacle;
        private DaoJoueur _daoJoueur;

        public DaoPartie(Dbal dbal)
        {
            _dbal = dbal;
            _daoSalle = new DaoSalle(dbal);
            _daoObstacle = new DaoObstacle(dbal);
            _daoJoueur = new DaoJoueur(dbal);
        }

        /*public List<Partie> GetPartiesDuJour(Salle salle, DateTime date)
        {
            DataTable tab = _dbal.Select("Partie",
                "date > '" + date.ToString("yyyy-MM-dd H:m:s") + "' AND " +
                "date < '" + date.AddDays(1).ToString("yyyy-MM-dd") + "' AND " +
                "salle = " + salle.Id
            );
            List<Partie> lstP = new List<Partie>();
            foreach (DataRow row in tab.Rows)
            {
                lstP.Add(new Partie(row, _daoSalle.GetSalle((int)row["salle"])));
            }
            return lstP;
        }*/
        /// <summary>
        /// Attention, la date doit déja être attribué
        /// </summary>
        /*public void Create(Partie p)
        {
            _dbal.Insert("partie", p.ToArray());
            DataRow dbP = _dbal.Select("partie","date = '" + p.Date.ToString("yyyy-MM-dd") + "'").Rows[0];
            p.Id = (int)dbP["id"];
            foreach (Joueur j in p.LstJoueur)
            {
                _daoJoueur.AddJoueurToPartie(j, p);
            }
            for (int i = 0; i < p.LstObstacle.Count; i++)
            {
                _daoObstacle.AddObstacleToPartie(p.LstObstacle[i], p, i);
            }
        }
        public void Edit(Partie p)
        {

        }*/
        // public Partie GetPartie(int id)
        // {
        //     DataRow rowP = _dbal.SelectById("partie", id);
        //     Partie partie = new Partie(rowP, _daoSalle.GetSalle((int)rowP["salle"]));
        //     partie.LstJoueur = _daoJoueur.GetJoueurToPartie(partie);
        //     return partie;
        // }
        public Partie GetPartieForHoraire(Horaire horaire, DateTime jour, Salle salle)
        {
            try
            {
                return new Partie(_dbal.Select("partie",
                        "salle = " + salle.Id +
                        " and date = '" + jour.ToString("yyyy-M-d") + "' and " +
                        "horaire = " + horaire.Id
                    ).Rows[0],
                    horaire);
            }
            catch (Exception e)
            {
                return  new Partie(salle,horaire,jour);
            }
        }

        public void NouvellePartie(Partie partie)
        {
            
            _dbal.Insert("partie", partie.ToArray());
           Partie p = new Partie(_dbal.SelectOrderBy("partie", "id", "DESC", "1").Rows[0]);
            
            foreach (Joueur joueur in partie.LstJoueur)
            {
                Dictionary<string, dynamic> dic = new Dictionary<string, dynamic>();
                dic.Add("joueur", joueur.Id);
                dic.Add("partie", p.Id);
                _dbal.Insert("joueur_partie", dic);
            }

            for (var i = 0; i < partie.LstObstacle.Count; i++)
            {
                Dictionary<string, dynamic> dic = new Dictionary<string, dynamic>();
                dic.Add("obstacle", partie.LstObstacle[i].Id);
                dic.Add("partie", p.Id);
                dic.Add("position", i+1);
                _dbal.Insert("obstacle_partie", dic);
            }
        }

        public int NbPartie(Salle salle, DateTime date)
        {
            DataRow row = _dbal.Select("partie", 
                "salle = " + salle.Id + " AND date = '" + date.ToString("yyyy-MM-dd") + "'", "count(id) as nb").Rows[0]; 
            return (int)(long)row["nb"]; 
        }
    }
}