using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Model.Business;
using Model.Data;

namespace Direction.viewModel
{
    class ViewModelGestion : ViewModelBase
    {
        #region Attributs

        // DAO
        private DaoSite _daoSite;
        private DaoSalle _daoSalle;
        private DaoHoraire _daoHoraire;
        private DaoTheme _daoTheme;

        // LISTES
        private ObservableCollection<Site> _listSites;
        private ObservableCollection<Salle> _listSalles;
        private ObservableCollection<Horaire> _listHoraires;
        private ObservableCollection<Horaire> _listHorairesSite;
        private ObservableCollection<Theme> _listThemes;

        // SELECTIONS
        private Site _selectedSite;
        private Salle _selectedSalle;
        private Horaire _selectedHoraire;
        private Horaire _selectedHoraireSite;
        private DateTime _dateNewDate;
        private Theme _themeActif;
        private Theme _selectedTheme;
        private string _nameNewTheme;

        // COMMANDES
        private ICommand _addHoraireCommand;
        private ICommand _assigneHoraireCommand;
        private ICommand _dissosHoraireCommand;
        private ICommand _assigneToSalleCommand;
        private ICommand _deleteThemeCommand;
        private ICommand _addThemeCommand;

        #endregion

        #region Constructeur

        public ViewModelGestion(DaoSite daoSite, DaoSalle daoSalle, DaoHoraire daoHoraire, DaoTheme daoTheme)
        {
            // DAO
            _daoSite = daoSite;
            _daoSalle = daoSalle;
            _daoHoraire = daoHoraire;
            _daoTheme = daoTheme;
            // LISTES
            _listSalles = new ObservableCollection<Salle>();
            _listThemes = new ObservableCollection<Theme>(_daoTheme.GetAllTheme());
            ListSites = new ObservableCollection<Site>(_daoSite.GetAllSite());
            _listHoraires = new ObservableCollection<Horaire>(_daoHoraire.GetAllHoraires());
            // SELECTIONS
            _selectedSite = _listSites.First();
            _selectedSalle = _listSalles.First();
            _selectedHoraire = new Horaire();
            _selectedHoraireSite = new Horaire();
            _dateNewDate = new DateTime();
            _nameNewTheme = "";
        }

        #endregion

        #region BINDING LISTES

        public ObservableCollection<Site> ListSites
        {
            get => _listSites;
            set
            {
                _listSites = value;
                if (_listSites.First() != null) SelectedSite = _listSites.First();
            }
        }

        public ObservableCollection<Salle> ListSalles
        {
            get => _listSalles;
            set
            {
                _listSalles = value;
                if (_listSalles.First() != null) SelectedSalle = _listSalles.First();
            }
        }

        public ObservableCollection<Horaire> ListHoraires
        {
            get => _listHoraires;
            set => _listHoraires = value;
        }

        public ObservableCollection<Horaire> ListHorairesSite
        {
            get => _listHorairesSite;
            set => _listHorairesSite = value;
        }

        public ObservableCollection<Theme> ListThemes
        {
            get => _listThemes;
            set => _listThemes = value;
        }

        #endregion

        #region BINDING SELECTIONS

        public Site SelectedSite
        {
            get => _selectedSite;
            set
            {
                if (value != null &&
                    value != _selectedSite)
                {
                    _selectedSite = value;
                    RefreshListSalle();
                    SelectedSalle = ListSalles.First();
                    ListHorairesSite = new ObservableCollection<Horaire>(_daoHoraire.GetHorairesForSite(_selectedSite));
                    OnPropertyChanged("SelectedSite");
                    OnPropertyChanged("ListSalles");
                    OnPropertyChanged("ListHorairesSite");
                }
            }
        }

        public Salle SelectedSalle
        {
            get => _selectedSalle;
            set
            {
                if (value != null &&
                    value != _selectedSalle)
                {
                    _selectedSalle = value;
                    ThemeActif = _selectedSalle.Theme;
                    OnPropertyChanged("SelectedSalle");
                }
            }
        }

        public Horaire SelectedHoraire
        {
            get => _selectedHoraire;
            set
            {
                if (value != null &&
                    value != _selectedHoraire)
                {
                    _selectedHoraire = value;

                    OnPropertyChanged("SelectedHoraire");
                }
            }
        }

        public Horaire SelectedHoraireSite
        {
            get => _selectedHoraireSite;
            set
            {
                if (value != null &&
                    value != _selectedHoraireSite)
                {
                    _selectedHoraireSite = value;

                    OnPropertyChanged("SelectedHoraireSite");
                }
            }
        }

        public DateTime DateNewDate
        {
            get => _dateNewDate;
            set
            {
                if (value != null &&
                    value != _dateNewDate)
                {
                    _dateNewDate = value;

                    OnPropertyChanged("DateNewDate");
                }
            }
        }

        public Theme ThemeActif
        {
            get => _themeActif;
            set
            {
                if (value != null &&
                    value != _themeActif)
                {
                    _themeActif = value;

                    OnPropertyChanged("ThemeActif");
                }
            }
        }

        public Theme SelectedTheme
        {
            get => _selectedTheme;
            set
            {
                if (value != null &&
                    value != _selectedTheme)
                {
                    _selectedTheme = value;

                    OnPropertyChanged("SelectedTheme");
                }
            }
        }

        public string NameNewTheme
        {
            get => _nameNewTheme;
            set
            {
                if (value != null &&
                    value != _nameNewTheme)
                {
                    _nameNewTheme = value;

                    OnPropertyChanged("NameNewTheme");
                }
            }
        }

        #endregion

        #region Commande (boutons)

        public ICommand AddHoraireCommand
        {
            get
            {
                if (_addHoraireCommand == null)
                {
                    _addHoraireCommand = new RelayCommand(() => AddHoraire(), () => true);
                }

                return _addHoraireCommand;
            }
        }

        public ICommand AssigneHoraireCommand
        {
            get
            {
                if (_assigneHoraireCommand == null)
                {
                    _assigneHoraireCommand = new RelayCommand(() => AssigneHoraire(), () => true);
                }

                return _assigneHoraireCommand;
            }
        }

        public ICommand DissosHoraireCommand
        {
            get
            {
                if (_dissosHoraireCommand == null)
                {
                    _dissosHoraireCommand = new RelayCommand(() => DissosHoraire(), () => true);
                }

                return _dissosHoraireCommand;
            }
        }

        public ICommand AssigneToSalleCommand
        {
            get
            {
                if (_assigneToSalleCommand == null)
                {
                    _assigneToSalleCommand = new RelayCommand(() => AssigneToSalle(), () => true);
                }

                return _assigneToSalleCommand;
            }
        }

        public ICommand DeleteThemeCommand
        {
            get
            {
                if (_deleteThemeCommand == null)
                {
                    _deleteThemeCommand = new RelayCommand(() => DeleteTheme(), () => true);
                }

                return _deleteThemeCommand;
            }
        }

        public ICommand AddThemeCommand
        {
            get
            {
                if (_addThemeCommand == null)
                {
                    _addThemeCommand = new RelayCommand(() => AddTheme(), () => true);
                }

                return _addThemeCommand;
            }
        }

        #endregion

        #region Action

        private void AddHoraire()
        {
            if (_dateNewDate != null)
            {
                Horaire horaire = new Horaire(DateNewDate.TimeOfDay);
                _daoHoraire.New(ref horaire);
                ListHoraires.Add(horaire);
            }
        }

        private void AssigneHoraire()
        {
            if (IsNotNull(SelectedHoraire, "Il faut sélectionner un horaire"))
            {
                _daoHoraire.AssigneToSite(SelectedHoraire, SelectedSite);
                ListHorairesSite.Add(SelectedHoraire);
            }
        }

        private void DissosHoraire()
        {
            if (IsNotNull(SelectedHoraireSite, "Il faut sélectionner un horaire"))
            {
                _daoHoraire.DissosToSite(SelectedHoraireSite, SelectedSite);
                ListHorairesSite.Remove(SelectedHoraireSite);
            }
        }

        private void AssigneToSalle()
        {
            if (IsNotNull(SelectedTheme, "Il faut sélectionner un thème"))
            {
                _daoTheme.AssgneToSalle(SelectedTheme, ref _selectedSalle);
                Salle activeSalle = _selectedSalle;
                int index = ListSalles.IndexOf(_selectedSalle);
                RefreshListSalle();
                SelectedSalle = ListSalles[index];
            }
        }

        private void DeleteTheme()
        {
            if (VerifThemeNotUse(SelectedTheme))
            {
                _daoTheme.Delete(SelectedTheme);
                ListThemes.Remove(SelectedTheme);
            }
        }

        private void AddTheme()
        {
            ListThemes.Add(_daoTheme.New(new Theme(NameNewTheme)));
            SelectedTheme = ListThemes.Last();
            NameNewTheme = "";
        }

        #endregion

        #region Autre methode

        private bool IsNotNull(dynamic val, string msg, bool isnot = true)
        {
            bool r = val != null;
            r = r == isnot;
            if (!r) MessageBox.Show(msg);
            return r;
        }

        private void RefreshListSalle()
        {
            _listSalles.Clear();
            foreach (Salle salle in _daoSalle.GetBySite(_selectedSite))
            {
                foreach (Theme theme in ListThemes)
                {
                    if (salle.Theme.Id == theme.Id) salle.Theme = theme;
                }

                ListSalles.Add(salle);
            }
        }

        private bool VerifThemeNotUse(Theme theme)
        {
            bool r = true;
            foreach (Salle salle in _daoSalle.GetAll())
            {
                if (salle.Theme.Id == theme.Id)
                {
                    r = false;
                }
            }

            return r;
        }

        #endregion
    }
}