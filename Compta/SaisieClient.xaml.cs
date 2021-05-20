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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class SaisieClient : Window
    {
        private Dbal _dbal;
        private DaoClient _daoClient;
        public SaisieClient(Dbal dbal)
        {
            _dbal = dbal;
            _daoClient = new DaoClient(dbal);
            InitializeComponent();
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
                SelectWindow subWindow = new SelectWindow(_dbal);
                subWindow.Show();
                Close();
        }

        private void Button_Chercher(object sender, RoutedEventArgs e)
        {
            Client c = _daoClient.SearchClient(TextBox_Prenom.Text, TextBox_Nom.Text, TextBox_Email.Text);
            if (c.Id != 0)
            {
                InfosClient wnd = new InfosClient(c,_dbal);
                wnd.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Ce client n'existe pas");
            }
        }
    }
}
