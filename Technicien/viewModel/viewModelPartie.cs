using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Model.Business;
using Model.Data;

namespace Technicien.viewModel
{
    class viewModelPartie : viewModelBase
    {
        private Création_de_partie _wnd;
        //DAO
        private DaoFacture _daoFacture;
        private DaoClient _daoClient;
        private DaoHoraire _daoHoraire;
        private DaoSite _daoSite;
        private DaoSalle _daoSalle;
        private DaoPartie _daoPartie;
        private DaoObstacle _daoObstacle;
        private DaoJoueur _daoJoueur;

        private Client _activeclient;
        private Partie _activePartie;

        //LISTE
        private ObservableCollection<Joueur> _listJoueur;
        private ObservableCollection<Joueur> _listJoueurPartie;
        private ObservableCollection<Obstacle> _listObstacle;
        private ObservableCollection<Obstacle> _listObstaclePartie;

        //SELECTION
        private Joueur _selectedJoueur;
        private Joueur _selectedJoueurPartie;
        private Obstacle _selectedObstacle;
        private Obstacle _selectedObstaclePartie;


        //COMMANDE
        private ICommand _addJoueurPartie;
        private ICommand _addJoueur;
        private ICommand _researchJoueur;
        private ICommand _delJoueurPartie;
        private ICommand _addObstacle;
        private ICommand _delObstacle;
        private ICommand _createReservation;

        private string researchText;
        private string pseudoJoueur;
        private string emailJoueur;


        public viewModelPartie(DaoFacture daoFacture, DaoClient daoClient,DaoHoraire daoHoraire, DaoSite daoSite, DaoSalle daoSalle, DaoPartie daoPartie,
            DaoObstacle daoObstacle, DaoJoueur daoJoueur, Partie activePartie,Client activeclient, Création_de_partie création_De_Partie)
        {
            _wnd = création_De_Partie;

            _daoFacture = daoFacture;
            _daoClient = daoClient;
            _daoHoraire = daoHoraire;
            _daoSite = daoSite;
            _daoSalle = daoSalle;
            _daoPartie = daoPartie;
            _daoObstacle = daoObstacle;
            _daoJoueur = daoJoueur;
            _activePartie = activePartie;
            _activeclient = activeclient;

            _listJoueur = new ObservableCollection<Joueur>(daoJoueur.GetAllJoueur());
            _listObstacle = new ObservableCollection<Obstacle>(daoObstacle.GetAllObstacle());
            _listJoueurPartie = new ObservableCollection<Joueur>();
            _listObstaclePartie = new ObservableCollection<Obstacle>();
            researchText = "";
            pseudoJoueur = "";
            emailJoueur = "";

        }



        public ObservableCollection<Joueur> ListJoueur
        {
            get => _listJoueur;
            set => _listJoueur = value;
        }

        public ObservableCollection<Joueur> ListJoueurPartie
        {
            get => _listJoueurPartie;
            set => _listJoueurPartie = value;
        }

        public ObservableCollection<Obstacle> ListObstacle
        {
            get => _listObstacle;
            set => _listObstacle = value;
        }

        public ObservableCollection<Obstacle> ListObstaclePartie
        {
            get => _listObstaclePartie;
            set => _listObstaclePartie = value;
        }

        public Joueur SelectedJoueur
        {
            get => _selectedJoueur;
            set
            {
                _selectedJoueur = value;
                OnPropertyChanged("SelectedJoueur");
            }
        }

        public Joueur SelectedJoueurPartie
        {
            get => _selectedJoueurPartie;
            set
            {
                _selectedJoueurPartie = value;
                OnPropertyChanged("SelectedJoueurPartie");
            }
        }

        public Obstacle SelectedObstacle
        {
            get => _selectedObstacle;
            set
            {
                _selectedObstacle = value;
                OnPropertyChanged("SelectedObstacle");
            }
        }
        public Obstacle SelectedObstaclePartie
        {
            get => _selectedObstaclePartie;
            set
            {
                _selectedObstaclePartie = value;
                OnPropertyChanged("SelectedObstaclePartie");
            }
        }
        public string ResearchText
        {
            get
            {
                return researchText;
            }
            set
            {
                if (value != researchText)
                {
                    researchText = value;
                    OnPropertyChanged("ResearchText");
                }
            }
        }

        public string PseudoJoueur
        {
            get
            {
                return pseudoJoueur;
            }
            set
            {
                if (value != pseudoJoueur)
                {
                    pseudoJoueur = value;
                    OnPropertyChanged("PseudoJoueur");
                }
            }
        }
        public string EmailJoueur
        {
            get
            {
                return emailJoueur;
            }
            set
            {
                if (value != emailJoueur)
                {
                    emailJoueur = value;
                    OnPropertyChanged("EmailJoueur");
                }
            }
        }

        //commande
        //rechercher un joueur
        public ICommand ResearchJoueur
        {
            get
            {
                if (this._researchJoueur == null)
                {
                    this._researchJoueur = new RelayCommand(() => RechercheJoueur(), () => true);
                }
                return this._researchJoueur;
            }
        }
        //ajouter le jouer a la partie
        public ICommand AddJoueurPartie
        {
            get
            {
                if (this._addJoueurPartie == null)
                {
                    this._addJoueurPartie = new RelayCommand(() => AjouterJoueurPartie(), () => true);
                }
                return this._addJoueurPartie;
            }
        }
        //ajouter le jouer dans la bdd
        public ICommand AddJoueur
        {
            get
            {
                if (this._addJoueur == null)
                {
                    this._addJoueur = new RelayCommand(() => AjouterJoueur(), () => true);
                }
                return this._addJoueur;
            }
        }
        public ICommand DelJoueurPartie
        {
            get
            {
                if (this._delJoueurPartie == null)
                {
                    this._delJoueurPartie = new RelayCommand(() => SupprimerJoueurPartie(), () => true);
                }
                return this._delJoueurPartie;
            }

        }
        public ICommand AddObstacle
        {
            get
            {
                if (this._addObstacle == null)
                {
                    this._addObstacle = new RelayCommand(() => AjouterObstacle(), () => true);
                }
                return this._addObstacle;
            }
        }

        public ICommand DelObstacle
        {
            get
            {
                if (this._delObstacle == null)
                {
                    this._delObstacle = new RelayCommand(() => RetirerObstacle(), () => true);
                }
                return this._delObstacle;
            }
        }
        public ICommand CreateReservation
        {
            get
            {
                if (this._createReservation == null)
                {
                    this._createReservation = new RelayCommand(() => CreerPartie(), () => true);
                }
                return this._createReservation;
            }
        }

        //methode commande
        private void RechercheJoueur()
        {
            if (researchText == "")
            {
                
                _listJoueur.Clear();
                
                foreach (Joueur joueur in _daoJoueur.GetAllJoueur())
                {
                    _listJoueur.Add(joueur);
                    foreach (Joueur j in _listJoueurPartie)
                    {
                        if (j == joueur)
                        {
                            _listJoueur.Remove(joueur);
                        }
                        
                    }
                    
                }
            }
            else
            {
                _listJoueur.Clear();

                foreach (Joueur joueur in _daoJoueur.GetJoueurByPseudo(researchText))
                {
                    _listJoueur.Add(joueur);
                    foreach (Joueur j in _listJoueurPartie)
                    {
                        if (j == joueur)
                        {
                            _listJoueur.Remove(joueur);
                        }
                        
                    }
                }
            }
        }

        private void AjouterJoueurPartie()
        {
            if (_selectedJoueur == null)
            {
                MessageBox.Show("veuillez selectionner un joueur !");
            }
            else
            {
                _listJoueurPartie.Add(_selectedJoueur);
                _listJoueur.Remove(_selectedJoueur);
            }
        }

        private void AjouterJoueur()
        {
            if (pseudoJoueur == "" || emailJoueur == "")
            {
                MessageBox.Show("veuillez insérer un pseudo et un email");
            }
            else
            {
                Joueur j = new Joueur(pseudoJoueur, emailJoueur);
                _listJoueur.Add(j);
                _daoJoueur.AddJoueur(ref j);
                foreach (Joueur joueur in _daoJoueur.GetJoueurByPseudo(researchText))
                {
                    _listJoueur.Add(joueur);
                }
            }
        }
        private void SupprimerJoueurPartie()
        {
            if (_selectedJoueurPartie == null)
            {
                MessageBox.Show("Veuillez selectioner un joueur dans la partie !");
            }
            else
            {
                _listJoueurPartie.Remove(_selectedJoueurPartie);
                _listJoueur.Clear();
                foreach (Joueur joueur in _daoJoueur.GetAllJoueur())
                {
                    _listJoueur.Add(joueur);
                }

            }
        }
        private void AjouterObstacle()
        {
            if (_selectedObstacle == null)
            {
                MessageBox.Show("veuillez selectionner un obstacle !");
            }
            else
            {
                _listObstaclePartie.Add(_selectedObstacle);
                _listObstacle.Remove(_selectedObstacle);
            }
        }

        private void RetirerObstacle()
        {
            if (_selectedObstaclePartie == null)
            {
                MessageBox.Show("veuillez selectionner un obstacle !");
            }
            else
            {
                _listObstacle.Add(_selectedObstaclePartie);
                _listObstaclePartie.Remove(_selectedObstaclePartie);
            }
        }
        private void CreerPartie()
        {
            if (_listJoueurPartie.Count() >= 2 && _listJoueurPartie.Count() <= 7 && _listObstaclePartie.Count()<=12 && _listObstaclePartie.Count() >= 6)
            {
                foreach (Joueur joueur in _listJoueurPartie)
                {
                    _activePartie.LstJoueur.Add(joueur);
                }
                foreach (Obstacle obstacle in _listObstaclePartie)
                {
                    _activePartie.LstObstacle.Add(obstacle);
                }

                Facture _newfacture = new Facture(DateTime.Now, 10, 10, _activeclient);
                _daoPartie.NouvellePartie(_activePartie);
                _daoFacture.NouvelleFacture(_newfacture);
                Planning subWindows = new Planning(_daoFacture, _daoClient, _daoSite, _daoSalle, _daoPartie, _daoHoraire, _daoObstacle, _daoJoueur);
                subWindows.Show();
                _wnd.Close();
                
                
            }
            else
            {
                MessageBox.Show("Veuillez vérifier qu'il y est bien entre 2 et 7 joueurs dans la partie et qu'il est bien 12 obstacle");
            }
        }

    }
         
}