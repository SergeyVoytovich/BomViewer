using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper.Internal;
using BomViewer.DomainObjects;
using BomViewer.Presentation.Wpf.Commands;

namespace BomViewer.Presentation.Wpf.ViewModels
{
    /// <summary>
    /// Main view model
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region Properties

        /// <summary>
        /// Groups
        /// </summary>
        public IList<GroupViewModel> Groups
        {
            get => Get<IList<GroupViewModel>>();
            set => Set(value);
        }

        /// <summary>
        /// Selected group
        /// </summary>
        public GroupViewModel SelectedGroup
        {
            get => Get<GroupViewModel>();
            set => Set(value);
        }

        /// <summary>
        /// Parts
        /// </summary>
        public ObservableCollection<IPart> Parts
        {
            get => Get<ObservableCollection<IPart>>();
            set => Set(value);
        }

        /// <summary>
        /// Populate data in tree command
        /// </summary>
        public ICommand LoadGroupsCommand { get; }

        /// <summary>
        /// Exit command
        /// </summary>
        public ICommand ExitCommand { get; }

        #endregion


        #region Constructros

        public MainViewModel(ViewModelEnvironment environment) : base(environment)
        {
            LoadGroupsCommand = new AsyncCommand(LoadGroupsAsync, () => Groups != null);
            Groups = new List<GroupViewModel>();
        }

        #endregion


        #region Methods

        internal virtual async Task LoadGroupsAsync()
        {
            Groups = null;
            SelectedGroup = null;

            Groups = MapGroups(await Application.GetGroupsAsync());
        }

        private List<GroupViewModel> MapGroups(IList<IGroup> groups)
            => MapGroups(groups.Where(i => !i.ParentId.HasValue), groups);

        private List<GroupViewModel> MapGroups(IEnumerable<IGroup> toMap, IList<IGroup> source)
            => MapGroups(toMap, source, null);

        private List<GroupViewModel> MapGroups(IEnumerable<IGroup> toMap, IList<IGroup> source, GroupViewModel parent)
            => Mapper.Map<IEnumerable<IGroup>, IList<GroupViewModel>>
            (
                toMap,
                options =>
                {
                    options.ConstructServicesUsing(_ => ViewModel(e => new GroupViewModel(e) { Parent = parent }));
                    options.AfterMap(
                        (_, dst) => dst.ForAll(
                            g => g.Children = MapGroups(source.Where(i => i.ParentId == g.Id), source, g)
                            )
                        );
                }
            ).ToList();

        #endregion
    }
}