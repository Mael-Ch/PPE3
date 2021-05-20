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
    /// Logique d'interaction pour CreationClient.xaml
    /// </summary>
    public partial class CreationClient : Window
    {
        private Dbal _dbal;
        private DaoClient _daoClient;
        public CreationClient(Dbal dbal)
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

        private void Button_Valider(object sender, RoutedEventArgs e)
        {
            Client leClient = new Client(
                Box_Nom.Text,
                Box_Prenom.Text,
                Selection_Date.DisplayDate, 
                Box_Email.Text,
                Box_Numero.Text,
                Box_Adress.Text,
                0
                );
            _daoClient.NouveauClient(leClient);
            MessageBox.Show("Le client a bien été créé");
        }
    }
}
