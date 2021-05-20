using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Model.Business;
using Model.Data;

namespace Compta
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Facturation : Window
    {
        private Dbal _dbal;
        private DaoClient _daoClient;
        private DaoFacture _daoFacture;
        private Client _client;

        public Facturation(Dbal dbal, Client leClient)
        {
            _client = leClient;
            _dbal = dbal;
            _daoClient = new DaoClient(dbal);
            _daoFacture = new DaoFacture(dbal);
            InitializeComponent();
            Box_Nom.Text = leClient.Nom;
            Box_Prenom.Text = leClient.Prenom;
            Selection_Date.Text = DateTime.Now.ToString("d");
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            InfosClient subWindow = new InfosClient(_client, _dbal);
            subWindow.Show();
            Close();
        }

        private void Button_Create_facture(object sender, RoutedEventArgs e)
        {
            _daoFacture.NouvelleFacture(new Facture(
                Selection_Date.DisplayDate,
                double.Parse(Box_Montant.Text),
                int.Parse(Box_Credits.Text),
                _client
                ));
            _daoClient.AddCredits(_client,int.Parse(Box_Credits.Text));
            MessageBox.Show("La facture a bien été créé et le client a bien reçu " + Box_Credits.Text + " crédits.");
        }
    }
}