using System.Windows;
using Model.Data;

namespace Direction
{
    public partial class Gestion : Window
    {
        private Dbal _dbal;
        public Gestion(Dbal dbal)
        {
            InitializeComponent();
            _dbal = dbal;
            MainGrid.DataContext = new viewModel.ViewModelGestion(
                new DaoSite(dbal), 
                new DaoSalle(dbal), 
                new DaoHoraire(dbal),
                new DaoTheme(dbal)
            );
        }
        private void Back(object sender, RoutedEventArgs routedEventArgs)
        {
            Home wnd = new Home(_dbal);
            wnd.Show();
            Close();
        }
    }
}