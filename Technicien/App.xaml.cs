using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Model.Business;
using Model.Data;

namespace Technicien
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender,StartupEventArgs e)
        {
            Dbal dbal = new Dbal("ppe3_mmd", "localhost", "root", "root");
            DaoFacture daoFacture = new DaoFacture(dbal);
            DaoClient daoClient = new DaoClient(dbal);
            DaoSite daoSite = new DaoSite(dbal);
            DaoSalle daoSalle = new DaoSalle(dbal);
            DaoPartie daoPartie = new DaoPartie(dbal);
            DaoHoraire daoHoraire =new DaoHoraire(dbal);
            DaoObstacle daoObstacle = new DaoObstacle(dbal);
            DaoJoueur daoJoueur = new DaoJoueur(dbal);


            MainWindow Wnd = new MainWindow(daoFacture, daoClient,daoSite,daoSalle,daoPartie,daoHoraire,daoObstacle,daoJoueur);
            Wnd.Show();
        }
    }
}
