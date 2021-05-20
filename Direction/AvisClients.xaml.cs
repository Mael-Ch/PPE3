using System.Windows;
using Model.Data;

namespace Direction
{
    public partial class AvisClients : Window
    {
        private Dbal _dbal;
        public AvisClients(Dbal dbal)
        {
            InitializeComponent();
            _dbal = dbal;
            MainGrid.DataContext = new viewModel.ViewModelAvis(
                new DaoTheme(dbal),
                new DaoAvis(dbal)
            );
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Home wnd = new Home(_dbal);
            wnd.Show();
            Close();
        }
    }
}