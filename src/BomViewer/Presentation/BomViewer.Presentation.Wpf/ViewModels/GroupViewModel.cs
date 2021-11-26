using System.Collections.Generic;

namespace BomViewer.Presentation.Wpf.ViewModels
{
    public class GroupViewModel : ViewModelBase
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public GroupViewModel Parent { get; set; }
        public IList<GroupViewModel> Children { get; set; } = new List<GroupViewModel>();

        #endregion


        #region Constructors

        public GroupViewModel(ViewModelEnvironment environment) : base(environment)
        {
        }

        #endregion



    }
}