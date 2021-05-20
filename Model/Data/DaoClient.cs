using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model.Business;

namespace Model.Data
{
    public class DaoClient
    {
        private Dbal _dbal;
        private DaoFacture _daoFacture;
        public DaoClient(Dbal dbal)
        {
            _dbal = dbal;
            _daoFacture = new DaoFacture(dbal);
        }

        public void NouveauClient(Client c)
        {
            _dbal.Insert("client", c.ToArray());
        }
        public Client SearchClient(string prenom, string nom, string email)
        {
            try
            {
                return new Client(_dbal.Select("client",
                    "prenom = '" + prenom + "' AND " +
                    "nom = '" + nom + "' AND " +
                    "email = '" + email + "'"
                ).Rows[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Client();
            }
        }
        public void EditClient(Client c)
        {
            _dbal.Update("client", c.ToArray(), "id = " + c.Id);
        }

        public void AddCredits(Client client, int nbCredits)
        {
            Dictionary<string, dynamic> dic = new Dictionary<string, dynamic>();
            dic.Add("credit", client.Credit + nbCredits);
            _dbal.Update("client", dic, "id = " + client.Id);
        }
        public List<Client> GetAllClient()
        {
            List<Client> lst = new List<Client>();
            DataTable tab = _dbal.Select("client");

            foreach (DataRow row in tab.Rows)
            {
                lst.Add(new Client(row));
            }
            return lst;

        }
        public List<Client> GetClientByMail(string email)
        {
            List<Client> lst = new List<Client>();
            DataTable tab = _dbal.Select("Client", "email like '%" + email + "%'");
            foreach (DataRow row in tab.Rows)
            {
                lst.Add(new Client(row));
            }
            return lst;

        }
    }
}
