using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model.Business;

namespace Model.Data
{
    public class DaoAvis
    {
        private Dbal _dbal;
        private DaoJoueur _daoJoueur;
        public DaoAvis(Dbal dbal)
        {
            _dbal = dbal;
            _daoJoueur = new DaoJoueur(dbal);
        }
        public DaoAvis(Dbal dbal, DaoJoueur daoJoueur)
        {
            _dbal = dbal;
            _daoJoueur = daoJoueur;
        }
        /*public void Insert(Avis avis)
        {
            _dbal.Insert("avis", avis.ToArray());
        }
        public void Update(Avis avis)
        {
            _dbal.Update("avis", avis.ToArray(), "id = " + avis.Id);
        }
        public void Delete(Avis avis)
        {
            _dbal.Delete("Avis", "id = " + avis.Id);
        }
        public List<Avis> GetAll()
        {
            DataTable tab = _dbal.Select("avis");
            List<Avis> lst = new List<Avis>();
            foreach (DataRow row in tab.Rows)
            {
                lst.Add(new Avis(row, _daoJoueur.GetJoueurById((int)row["joueur"])));
            }
            return lst;
        }
        public List<Avis> GetForJoueur(Joueur joueur)
        {
            DataTable tab = _dbal.Select("avis","joueur = " + joueur.Id);
            List<Avis> lst = new List<Avis>();
            foreach (DataRow row in tab.Rows)
            {
                lst.Add(new Avis(row, joueur));
            }
            return lst;
        }*/
        public List<Avis> GetByJoueurId(int id)
        {
            DataTable tab = _dbal.Select("avis","joueur = " + id);
            List<Avis> lst = new List<Avis>();
            foreach (DataRow row in tab.Rows)
            {
                lst.Add(new Avis(row));
            }
            return lst;
        }

        public List<Avis> GetForTheme(Theme theme)
        {
            string query = "";
            query += "select avis.id,avis.commentaire,avis.date,avis.joueur from avis ";
            query += "join joueur on joueur.id = avis.joueur ";
            query += "join joueur_partie ON joueur.id = joueur_partie.joueur ";
            query += "join partie ON joueur_partie.partie = partie.id ";
            query += "join salle ON partie.salle = salle.id ";
            query += "join theme_salle ON salle.id = theme_salle.salle ";
            query += "where theme_salle.theme = " + theme.Id + " AND ";
            query += "theme_salle.dateDebut < avis.date AND ";
            query += "theme_salle.dateFin > avis.date ";
            query += "group by avis.id, avis.commentaire, avis.date, avis.joueur ";
            query += "order by avis.date";
            DataTable tab = _dbal.RQuery(query).Tables[0];
            List<Avis> lstAvis = new List<Avis>();
            foreach (DataRow row in tab.Rows)
            {
                Avis avis = new Avis(row);
                avis.Joueur = _daoJoueur.GetById((int)row["joueur"]);
                lstAvis.Add(avis);
            }
            return lstAvis;
        }

        public void Add(Joueur joueur, DateTime date, string comm)
        {
            Dictionary<string, dynamic> dic = new Dictionary<string, dynamic>();
            dic.Add("commentaire",comm);
            dic.Add("joueur",joueur.Id);
            dic.Add("date",date);
            _dbal.Insert("avis",dic);
        }
    }
}
