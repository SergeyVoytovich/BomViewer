namespace BomViewer.Presentation.Wpf.ViewModels
{
    public class PartViewModel : ViewModelBase
    {
        #region Properties

        /// <summary>
        /// Component name
        /// </summary>
        public string ComponentName { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Part number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Item
        /// </summary>
        public string Item { get; set; }

        /// <summary>
        /// Material
        /// </summary>
        public string Material { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get; set; }

        #endregion


        #region Constructors

        public PartViewModel(ViewModelEnvironment environment) : base(environment)
        {
        }

        #endregion
    }
}