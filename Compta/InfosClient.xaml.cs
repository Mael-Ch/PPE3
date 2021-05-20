using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour FenetreClient.xaml
    /// </summary>
    public partial class InfosClient : Window
    {
        private Dbal _dbal;
        private DaoClient _daoClient;
        private Client _client;
        public InfosClient(Client leClient, Dbal dbal)
        {
            _client = leClient;
            _dbal = dbal;
            _daoClient = new DaoClient(dbal);
            InitializeComponent();
            Box_Nom.Text = leClient.Nom;
            Box_Prenom.Text = leClient.Prenom;
            Selection_Date.SelectedDate = leClient.Naissance;
            Box_Email.Text = leClient.Email;
            Box_Crédits.Text = leClient.Credit.ToString();
            Box_Numero.Text = leClient.Tel;
            Box_Adress.Text = leClient.Adresse;
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            Client leClient = new Client(
                Box_Nom.Text,
                Box_Prenom.Text,
                Selection_Date.DisplayDate, 
                Box_Email.Text,
                Box_Numero.Text,
                Box_Adress.Text,
                int.Parse(Box_Crédits.Text)
                );
            _daoClient.EditClient(leClient);
            MessageBox.Show("Le client a bien été modifié");
        }

        private void Factu_Click(object sender, RoutedEventArgs e)
        {
            Facturation subWindow = new Facturation(_dbal, _client);
            subWindow.Show();
            Close();
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            SaisieClient subWindow = new SaisieClient(_dbal);
            subWindow.Show();
            Close();
        }

        private void Button_Factu(object sender, RoutedEventArgs e)
        {
            Facturation subWindow = new Facturation(_dbal, _client);
            subWindow.Show();
            Close();
        }
    }
}