using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Model.Data;
using Model.Business;
using Technicien.viewModel;


namespace Technicien
{
    /// <summary>
    /// Logique d'interaction pour Création_de_partie.xaml
    /// </summary>
    public partial class Création_de_partie : Window
    {

        /// <summary>
        /// Logique d'interaction pour Création_de_partie.xaml
        /// </summary>
        private DaoFacture thedaoFacture;
        private DaoClient thedaoClient;
        private DaoSite thedaoSite;
        private DaoSalle thedaoSalle;
        private DaoPartie thedaoPartie;
        private DaoHoraire thedaoHoraire;
        private DaoObstacle thedaoObstacle;
        private DaoJoueur thedaoJoueur;
        private Partie _partie;
        private Client _client;

        public Création_de_partie(DaoFacture daofacture, DaoClient daoclient, DaoSite daosite, DaoSalle daosalle, DaoPartie daopartie, DaoHoraire daohoraire,
            DaoObstacle daoobstacle, DaoJoueur daojoueur, Partie partie, Client client)
        {
            InitializeComponent();
            thedaoFacture = daofacture;
            thedaoClient = daoclient;
            thedaoSite = daosite;
            thedaoSalle = daosalle;
            thedaoHoraire = daohoraire;
            thedaoPartie = daopartie;
            thedaoObstacle = daoobstacle;
            thedaoJoueur = daojoueur;
            _partie = partie;
            _client = client;
            MainGrid.DataContext = new viewModelPartie(daofacture, daoclient, daohoraire, daosite, daosalle, daopartie, daoobstacle, daojoueur, partie, client, this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Btn_Cree_Partie_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Btn_Retour_Click(object sender, RoutedEventArgs e)
        {
            Planning wnd = new Planning(thedaoFacture, thedaoClient,thedaoSite,thedaoSalle,thedaoPartie,thedaoHoraire,thedaoObstacle,thedaoJoueur);
            wnd.Show();
            this.Close();
        }

        private void txt_recherche_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
        }

        private void Button_ajouter_joueur_list(object sender, RoutedEventArgs e)
        {
        }

        

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
        }

        
    }
}