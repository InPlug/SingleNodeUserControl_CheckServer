using System.Windows;
using UserNodeControls;
using Vishnu.Interchange;
using Vishnu.ViewModel;

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
        }

        /// <summary>
        /// Konkrete Überschreibung von GetUserResultViewModel, returnt ein spezifisches ResultViewModel.
        /// </summary>
        /// <param name="vishnuViewModel">Ein spezifisches ResultViewModel.</param>
        /// <returns></returns>
        protected override DynamicUserControlViewModelBase GetUserResultViewModel(IVishnuViewModel vishnuViewModel)
        {
            return new ResultViewModel((IVishnuViewModel)this.DataContext);
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
