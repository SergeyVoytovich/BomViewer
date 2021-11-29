using System.Collections.Generic;

namespace BomViewer.Presentation.Wpf.ViewModels
{
    /// <summary>
    /// Group view model
    /// </summary>
    public class GroupViewModel : ViewModelBase
    {
        #region Properties

        /// <summary>
        /// Group id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Group name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Parent group
        /// </summary>
        public GroupViewModel Parent { get; set; }

        /// <summary>
        /// Child groups
        /// </summary>
        public IList<GroupViewModel> Children { get; set; } = new List<GroupViewModel>();

        #endregion


        #region Constructors

        /// <summary>
        /// Init new instance
        /// </summary>
        /// <param name="environment"></param>
        public GroupViewModel(ViewModelEnvironment environment) : base(environment)
        {
        }

        #endregion



    }
}