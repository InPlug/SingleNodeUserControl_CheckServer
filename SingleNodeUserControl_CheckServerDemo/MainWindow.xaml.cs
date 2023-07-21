using System.Windows;

namespace SingleNodeUserControl_CheckServerDemo
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new SingleNodeViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((SingleNodeViewModel)this.DataContext).RaiseAllProperties();
        }
    }
}
