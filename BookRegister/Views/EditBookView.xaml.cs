using System.Windows;

namespace BookRegister.Views
{
    /// <summary>
    /// Interaction logic for EditBookView.xaml
    /// </summary>
    public partial class EditBookView : Window
    {
        public EditBookView()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
