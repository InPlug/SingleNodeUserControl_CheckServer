using Vishnu.Interchange;
using CheckServer;
using Vishnu.ViewModel;

namespace UserNodeControls
{
    /// <summary>
    /// Funktion: ViewModel für das User-spezifische Result.
    /// Löst das ReturnObject eines Checkers in Properties auf.
    /// </summary>
    /// <remarks>
    /// File: ResultViewModel
    /// Autor: Erik Nagel
    ///
    /// 13.03.2015 Erik Nagel: erstellt
    /// </remarks>
    public class ResultViewModel : DynamicUserControlViewModelBase
    {
        /// <summary>
        /// Name des Servers, der angepingt werden soll.
        /// </summary>
        public string? Server
        {
            get
            {
                return this.GetResultProperty<string>(typeof(ComplexServerReturnObject), "Server");
            }
        }

        /// <summary>
        /// Timeout für einen einzelnen Ping.
        /// </summary>
        public string Timeout
        {
            get
            {
                return this.GetResultProperty<int>(typeof(ComplexServerReturnObject), "Timeout").ToString();
            }
        }

        /// <summary>
        /// Anzahl Ping-Versuche, bevor ein Fehler erzeugt wird.
        /// </summary>
        public string Retries
        {
            get
            {
                return this.GetResultProperty<int>(typeof(ComplexServerReturnObject), "Retries").ToString();
            }
        }

        /// <summary>
        /// Erfolgreicher Ping.
        /// </summary>
        public string SuccessfulRetry
        {
            get
            {
                return this.GetResultProperty<int>(typeof(ComplexServerReturnObject), "SuccessfulRetry").ToString();
            }
        }

        /// <summary>
        /// Die speziell für die Darstellung von CheckServer-Results entwickelte IVishnuViewModel-Implementierung.
        /// </summary>
        /// <param name="parentViewModel">Von Vishnu übergebenes IVishnuViewModel.</param>
        public ResultViewModel(IVishnuViewModel parentViewModel)
        {
            this.ParentViewModel = parentViewModel;
            if (parentViewModel != null) // wg. ReferenceNullException im DesignMode
            {
                this.ParentViewModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(parentViewModel_PropertyChanged);
            }
        }

        void parentViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Result")
            {
                this.RaisePropertyChanged("Server");
                this.RaisePropertyChanged("Timeout");
                this.RaisePropertyChanged("Retries");
                this.RaisePropertyChanged("SuccessfulRetry");
            }
        }

    }
}
