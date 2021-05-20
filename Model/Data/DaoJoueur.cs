using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model.Business;

namespace Model.Data
{
    public class DaoJoueur
    {
        private Dbal _dbal;
        private DaoAvis _daoAvis;

        public DaoJoueur(Dbal dbal)
        {
            _dbal = dbal;
            _daoAvis = new DaoAvis(dbal, this);
        }
        /*public void AddJoueurToPartie(Joueur j, Partie p)
        {
            Dictionary<string, dynamic> val = new Dictionary<string, dynamic>();
            val.Add("joueur", j.Id);
            val.Add("partie", p.Id);
            _dbal.Insert("joueur_partie", val);
        }
        public List<Joueur> GetJoueurToPartie(Partie p)
        {
            List<Joueur> lst = new List<Joueur>();
            DataTable tab = _dbal.Select("joueur_partie", "partie = " + p.Id);
            foreach (DataRow row in tab.Rows)
            {
                lst.Add(new Joueur(row, _daoAvis.GetByJoueurId((int)row["id"])));
            }
            return lst;
        }
        

        public Joueur GetJoueurById(int id)
        {
            DataRow row = _dbal.SelectById("joueur", id);
            return new Joueur(row, _daoAvis.GetByJoueurId((int)row["id"]));
        }*/
        
        public List<Joueur> GetAllJoueur()
        {
            List<Joueur> lst = new List<Joueur>();
            DataTable tab = _dbal.Select("joueur");
            foreach (DataRow row in tab.Rows)
            {
                lst.Add(new Joueur(row, _daoAvis.GetByJoueurId((int)row["id"])));
            }
            return lst;
        }
        public List<Joueur> GetJoueurByPseudo(string pseudo)
        {
            List<Joueur> lst = new List<Joueur>();
            DataTable tab = _dbal.Select("Joueur","pseudo like '%"+ pseudo+"%'");
            foreach (DataRow row in tab.Rows)
            {
                lst.Add(new Joueur(row, _daoAvis.GetByJoueurId((int)row["id"])));
            }
            return lst;
        }

        public void AddJoueur(ref Joueur joueur)
        {
            _dbal.Insert("joueur", joueur.ToArray());
            joueur.Id = (int) _dbal.SelectLast("joueur")["id"];
        }
        

        public Joueur GetById(int id)
        {
            return new Joueur(_dbal.SelectById("joueur", id),_daoAvis.GetByJoueurId(id));
        }
    }
}
