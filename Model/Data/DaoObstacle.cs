using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model.Business;

namespace Model.Data
{
    public class DaoObstacle
    {
        private Dbal _dbal;

        public DaoObstacle(Dbal dbal)
        {
            _dbal = dbal;
        }

        public List<Obstacle> GetAllObstacle()
        {
            List<Obstacle> lst = new List<Obstacle>();
            DataTable tab = _dbal.Select("obstacle");
            foreach (DataRow row in tab.Rows)
            {
                lst.Add(new Obstacle(row));
            }
            return lst;
        }
        /*public void AddObstacleToPartie(Obstacle o, Partie p, int position)
        {
            Dictionary<string, dynamic> val = new Dictionary<string, dynamic>();
            val.Add("obstacle", o.Id);
            val.Add("partie", p.Id);
            val.Add("position", position);
            _dbal.Insert("obstacle_partie", val);
        }*/
    }
}
