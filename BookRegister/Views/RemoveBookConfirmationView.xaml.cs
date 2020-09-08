using System.Windows;

namespace BookRegister.Views
{
    /// <summary>
    /// Interaction logic for RemoveBookConfirmationView.xaml
    /// </summary>
    public partial class RemoveBookConfirmationView : Window
    {
        public RemoveBookConfirmationView()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
