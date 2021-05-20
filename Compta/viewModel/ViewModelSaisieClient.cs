using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Model.Business;
using Model.Data;

namespace Compta.viewModel
{
    class ViewModelSaisieClient : ViewModelBase
    {
        #region Attributs

        // DAO
        private DaoClient _daoClient;

        private DaoFacture _daoFacture;

        // SAISIE
        private string _prenom;
        private string _nom;

        private string _email;

        // BOUTON
        private ICommand _faireLaRecherche;

        #endregion

        #region Constructeur

        public ViewModelSaisieClient(DaoClient daoClient, DaoFacture daoFacture)
        {
            _daoClient = daoClient;
            _daoFacture = daoFacture;
        }

        #endregion

        #region BINDING SAISIE

        public string Prenom
        {
            get => _prenom;
            set => _prenom = value;
        }

        public string Nom
        {
            get => _nom;
            set => _nom = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        #endregion

        #region BOUTON

        public ICommand FaireLaRecherche
        {
            get
            {
                if (_faireLaRecherche == null)
                {
                    _faireLaRecherche = new RelayCommand(() => ChangeWnd(), () => true);
                }

                return _faireLaRecherche;
            }
        }

        private void ChangeWnd()
        {
            
        }

        #endregion
    }
}