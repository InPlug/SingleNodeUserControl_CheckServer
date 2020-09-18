using System.Windows;
using Vishnu.Interchange;
using UserNodeControls;

namespace SingleNodeUserControl_CheckServer
{
    /// <summary>
    /// Interaktionslogik für SingleNodeUserControl_CheckServer.xaml
    /// </summary>
    public partial class SingleNodeUserControl_CheckServer : DynamicUserControlBase
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public SingleNodeUserControl_CheckServer()
        {
            InitializeComponent();
            DynamicUserControl_ContentRendered
              += new RoutedEventHandler(content_Rendered);
        }

        /// <summary>
        /// Übernimmt den aktuellen, spezifischen DataContext für Vishnu als IVishnuViewModel.
        /// </summary>
        public ResultViewModel UserResultViewModel { get; set; }

        private void ContentControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                this.UserResultViewModel = new ResultViewModel((IVishnuViewModel)this.DataContext);
                ((IVishnuViewModel)this.DataContext).UserDataContext = this.UserResultViewModel;
            }
        }

        private void content_Rendered(object sender, RoutedEventArgs e)
        {
        }

        private delegate void NoArgDelegate();

        /// <summary>
        /// Sorgt im Kontext des aufrufenden Moduls durch das übergebene DependencyObject "obj"
        /// für ein neues Rendern des Controls.
        /// </summary>
        /// <param name="obj">Das aufrufende DependencyObject selbst.</param>
        public static void Refresh(DependencyObject obj)
        {
            obj.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle, (NoArgDelegate)delegate { });
        }
    }
}
