using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Model.Business;
using Model.Data;

namespace Direction.viewModel
{
    class ViewModelStat : ViewModelBase
    {
        #region Attributs

        private DaoPartie _daoPartie;
        private DateTime _selectedDate;

        private string _annecySalle1Nom;
        private string _annecySalle1Stat;
        private string _annecySalle2Nom;
        private string _annecySalle2Stat;
        private string _annecySalle3Nom;
        private string _annecySalle3Stat;
        private string _annecySalle4Nom;
        private string _annecySalle4Stat;
        private string _thononSalle1Nom;
        private string _thononSalle1Stat;
        private string _thononSalle2Nom;
        private string _thononSalle2Stat;
        private string _bonnevilleSalle1Nom;
        private string _bonnevilleSalle1Stat;
        private string _chamonixSalle1Nom;
        private string _chamonixSalle1Stat;

        private ObservableCollection<Site> _listSite;

        #endregion

        #region Constructeur

        public ViewModelStat(DaoPartie daoPartie, DaoSite daoSite)
        {
            _daoPartie = daoPartie;
            
            _listSite = new ObservableCollection<Site>(daoSite.GetAllSite());
            AnnecySalle1Nom = _listSite[0].LstSalle[0].ToString();
            AnnecySalle2Nom = _listSite[0].LstSalle[1].ToString();
            AnnecySalle3Nom = _listSite[0].LstSalle[2].ToString();
            AnnecySalle4Nom = _listSite[0].LstSalle[3].ToString();
            ThononSalle1Nom = _listSite[1].LstSalle[0].ToString();
            ThononSalle2Nom = _listSite[1].LstSalle[1].ToString();
            BonnevilleSalle1Nom = _listSite[2].LstSalle[0].ToString();
            ChamonixSalle1Nom = _listSite[3].LstSalle[0].ToString();

            SelectedDate = DateTime.Now;
        }

        #endregion

        #region BINDING

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged("SelectedDate");


                AnnecySalle1Stat = _daoPartie.NbPartie(_listSite[0].LstSalle[0],_selectedDate).ToString();
                AnnecySalle2Stat = _daoPartie.NbPartie(_listSite[0].LstSalle[1],_selectedDate).ToString();
                AnnecySalle3Stat = _daoPartie.NbPartie(_listSite[0].LstSalle[2],_selectedDate).ToString();
                AnnecySalle4Stat = _daoPartie.NbPartie(_listSite[0].LstSalle[3],_selectedDate).ToString();
                ThononSalle1Stat = _daoPartie.NbPartie(_listSite[1].LstSalle[0],_selectedDate).ToString();
                ThononSalle2Stat = _daoPartie.NbPartie(_listSite[1].LstSalle[1],_selectedDate).ToString();
                BonnevilleSalle1Stat = _daoPartie.NbPartie(_listSite[2].LstSalle[0],_selectedDate).ToString();
                ChamonixSalle1Stat = _daoPartie.NbPartie(_listSite[3].LstSalle[0],_selectedDate).ToString();
            }
        }

        public string AnnecySalle1Nom
        {
            get => _annecySalle1Nom;
            set
            {
                _annecySalle1Nom = value;
                OnPropertyChanged("AnnecySalle1Nom");
            }
        }

        public string AnnecySalle1Stat
        {
            get => _annecySalle1Stat;
            set
            {
                _annecySalle1Stat = value;
                OnPropertyChanged("AnnecySalle1Stat");
            }
        }

        public string AnnecySalle2Nom
        {
            get => _annecySalle2Nom;
            set
            {
                _annecySalle2Nom = value;
                OnPropertyChanged("AnnecySalle2Nom");
            }
        }

        public string AnnecySalle2Stat
        {
            get => _annecySalle2Stat;
            set
            {
                _annecySalle2Stat = value;
                OnPropertyChanged("AnnecySalle2Stat");
            }
        }

        public string AnnecySalle3Nom
        {
            get => _annecySalle3Nom;
            set
            {
                _annecySalle3Nom = value;
                OnPropertyChanged("AnnecySalle3Nom");
            }
        }

        public string AnnecySalle3Stat
        {
            get => _annecySalle3Stat;
            set
            {
                _annecySalle3Stat = value;
                OnPropertyChanged("AnnecySalle3Stat");
            }
        }

        public string AnnecySalle4Nom
        {
            get => _annecySalle4Nom;
            set
            {
                _annecySalle4Nom = value;
                OnPropertyChanged("AnnecySalle4Nom");
            }
        }

        public string AnnecySalle4Stat
        {
            get => _annecySalle4Stat;
            set
            {
                _annecySalle4Stat = value;
                OnPropertyChanged("AnnecySalle4Stat");
            }
        }

        public string ThononSalle1Nom
        {
            get => _thononSalle1Nom;
            set
            {
                _thononSalle1Nom = value;
                OnPropertyChanged("ThononSalle1Nom");
            }
        }

        public string ThononSalle1Stat
        {
            get => _thononSalle1Stat;
            set
            {
                _thononSalle1Stat = value;
                OnPropertyChanged("ThononSalle1Stat");
            }
        }

        public string ThononSalle2Nom
        {
            get => _thononSalle2Nom;
            set
            {
                _thononSalle2Nom = value;
                OnPropertyChanged("ThononSalle2Nom");
            }
        }

        public string ThononSalle2Stat
        {
            get => _thononSalle2Stat;
            set
            {
                _thononSalle2Stat = value;
                OnPropertyChanged("ThononSalle2Stat");
            }
        }

        public string BonnevilleSalle1Nom
        {
            get => _bonnevilleSalle1Nom;
            set
            {
                _bonnevilleSalle1Nom = value;
                OnPropertyChanged("BonnevilleSalle1Nom");
            }
        }

        public string BonnevilleSalle1Stat
        {
            get => _bonnevilleSalle1Stat;
            set
            {
                _bonnevilleSalle1Stat = value;
                OnPropertyChanged("BonnevilleSalle1Stat");
            }
        }

        public string ChamonixSalle1Nom
        {
            get => _chamonixSalle1Nom;
            set
            {
                _chamonixSalle1Nom = value;
                OnPropertyChanged("ChamonixSalle1Nom");
            }
        }

        public string ChamonixSalle1Stat
        {
            get => _chamonixSalle1Stat;
            set
            {
                _chamonixSalle1Stat = value;
                OnPropertyChanged("ChamonixSalle1Stat");
            }
        }

        #endregion
    }
}