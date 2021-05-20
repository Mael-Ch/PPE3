using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Model.Business;
using Model.Data;

namespace Compta.viewModel
{
    class ViewModelInfoClient : ViewModelBase
    {
        #region Attributs

        // DAO
        private DaoClient _daoClient;


        #endregion

        #region Constructeur

        public ViewModelInfoClient(DaoClient daoClient)
        {
            _daoClient = daoClient;
        }

        #endregion
    }
}