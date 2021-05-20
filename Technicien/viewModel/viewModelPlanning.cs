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
    class viewModelPlanning : viewModelBase
    {
        private Planning _wnd;
        //DAO
        private DaoFacture _daoFacture;
        private DaoHoraire _daoHoraire;
        private DaoSite _daoSite;
        private DaoSalle _daoSalle;
        private DaoPartie _daoPartie;
        private DaoObstacle _daoObstacle;
        private DaoJoueur _daoJoueur;
        private DaoClient _daoClient;

        //LISTS
        private ObservableCollection<Partie> _listPlanning;
        private ObservableCollection<Site> _listSites;
        private ObservableCollection<Salle> _listSalles;
        private ObservableCollection<Client> _listClient;
        //SELECTIONS
        private Partie _selectedPlanning;
        private DateTime _datePlanning;
        private Site _selectedSite;
        private Client _selectedClient;
        private Salle _selectedSalle;

        //COMMANDE
        private ICommand _creerpartie;
        private ICommand _researchClient;

        private string researchTextClient;

        public viewModelPlanning(DaoFacture daoFacture, DaoClient daoClient, DaoSite daoSite, DaoSalle daoSalle, DaoPartie daoPartie, DaoHoraire daoHoraire,
            DaoObstacle daoObstacle, DaoJoueur daoJoueur, Planning planning)
        {
            _wnd = planning;

            _daoFacture = daoFacture;
            _daoClient = daoClient;
            _daoHoraire = daoHoraire;
            _daoPartie = daoPartie;
            _daoSalle = daoSalle;
            _daoSite = daoSite;
            _daoObstacle = daoObstacle;
            _daoJoueur = daoJoueur;

            _listPlanning = new ObservableCollection<Partie>();
            _listSalles = new ObservableCollection<Salle>();
            ListSites = new ObservableCollection<Site>(_daoSite.GetAllSite());
            _listClient = new ObservableCollection<Client>(daoClient.GetAllClient());
            DatePlanning = DateTime.Now;
            researchTextClient = "";
        }

        public ObservableCollection<Client> ListClient
        {
            get => _listClient;
            set => _listClient = value;
        }

        public ObservableCollection<Partie> ListPlanning
        {
            get => _listPlanning;
            set
            {
                _listPlanning = value;
                SelectedPlanning = _listPlanning.First();
            }
        }

        public ObservableCollection<Site> ListSites
        {
            get => _listSites;
            set
            {
                _listSites = value;
                SelectedSite = _listSites.First();
            }
        }

        public ObservableCollection<Salle> ListSalles
        {
            get => _listSalles;
            set { _listSalles = value; }
        }


        public DateTime DatePlanning
        {
            get => _datePlanning;
            set
            {
                _datePlanning = value;
                RefreshListPlanning();
                OnPropertyChanged("DatePlanning");
            }
        }


        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }
        public Site SelectedSite
        {
            get => _selectedSite;
            set
            {
                _selectedSite = value;
                RefreshListSalle();

                SelectedSalle = ListSalles.First();
                OnPropertyChanged("SelectedSite");
                OnPropertyChanged("ListSalles");
                OnPropertyChanged("SelectedSalle");
            }
        }

        public Salle SelectedSalle
        {
            get => _selectedSalle;
            set
            {
                _selectedSalle = value;
                RefreshListPlanning();
                OnPropertyChanged("SelectedSalle");
            }
        }

        public Partie SelectedPlanning
        {
            get => _selectedPlanning;
            set
            {
                _selectedPlanning = value;
                OnPropertyChanged("SelectedPlanning");
            }
        }
        public string ResearchTextClient
        {
            get
            {
                return researchTextClient;
            }
            set
            {
                if (value != researchTextClient)
                {
                    researchTextClient = value;
                    OnPropertyChanged("ResearchTextClient");
                }
            }
        }


        private void RefreshListSalle()
        {
            _listSalles.Clear();
            foreach (Salle salle in _daoSalle.GetBySite(_selectedSite))
            {
                ListSalles.Add(salle);
            }
        }

        private void RefreshListPlanning()
        {
            _listPlanning.Clear();
            foreach (Partie partie in _daoHoraire.GetPlanning(_datePlanning, _selectedSalle, _selectedSite))
            {
                ListPlanning.Add(partie);
            }

            OnPropertyChanged("ListPlanning");
        }


        public ICommand ResearchClient
        {
            get
            {
                if (this._researchClient == null)
                {
                    this._researchClient = new RelayCommand(() => RechercheClient(), () => true);
                }
                return this._researchClient;
            }
        }
        public ICommand CreerPartie
        {
            get
            {
                if (this._creerpartie == null)
                {
                    this._creerpartie = new RelayCommand(() => CreatePartie(), () => true);
                }

                return this._creerpartie;
            }
        }

        private void RechercheClient()
        {
            if (researchTextClient == "")
            {

                _listClient.Clear();

                foreach (Client client in _daoClient.GetAllClient())
                {
                    _listClient.Add(client);

                }
            }
            else
            {
                _listClient.Clear();

                foreach (Client client in _daoClient.GetClientByMail(researchTextClient))
                {
                    _listClient.Add(client);

                }
            }
        }

        private void CreatePartie()
        {
            if (_selectedPlanning == null)
            {
                MessageBox.Show("veuillez selectionner une partie !");
            }
            else
            {
                if (_selectedPlanning.Id == 0)
                {
                    if (_datePlanning < DateTime.Now.AddDays(-1))
                    {
                        MessageBox.Show("veuillez choisir une date supérieur a celle d'aujourd'hui !");
                    }
                    else
                    {
                        if (_selectedClient == null)
                        {
                            MessageBox.Show("veuillez selectionner un client");
                        }
                        else
                        {
                            _selectedPlanning.Date = _datePlanning;
                            _selectedPlanning.Salle = _selectedSalle;

                            Création_de_partie subWindow = new Création_de_partie(_daoFacture, _daoClient,_daoSite, _daoSalle, _daoPartie, _daoHoraire,
                                _daoObstacle, _daoJoueur, _selectedPlanning, _selectedClient);
                            subWindow.Show();
                            _wnd.Close();
                        }

                    }

                }
                else
                {
                    MessageBox.Show("veuillez selectionner un partie non réserver !");
                }
            }
        }
    }
}