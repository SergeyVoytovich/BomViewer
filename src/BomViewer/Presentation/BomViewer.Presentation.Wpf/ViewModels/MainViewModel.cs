using System.Collections.Generic;
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
        public IList<PartViewModel> Parts
        {
            get => Get<IList<PartViewModel>>();
            set => Set(value);
        }

        /// <summary>
        /// Populate data in tree command
        /// </summary>
        public ICommand LoadGroupsCommand { get; }

        /// <summary>
        /// Load parts command
        /// </summary>
        public ICommand LoadPartsCommand { get; }

        /// <summary>
        /// Exit command
        /// </summary>
        public ICommand ExitCommand { get; }

        #endregion


        #region Constructros

        public MainViewModel(ViewModelEnvironment environment) : base(environment)
        {
            LoadGroupsCommand = new AsyncCommand(LoadGroupsAsync, () => Groups != null);
            LoadPartsCommand = new AsyncCommand<GroupViewModel>(LoadPartsAsync, g => g != null);

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

        internal virtual Task LoadPartsAsync(GroupViewModel group)
        {
            Parts = null;
            return LoadPartsAsync(Expand(group));
        }

        internal virtual Task LoadPartsAsync(IList<GroupViewModel> groups)
            => LoadPartsAsync(Mapper.Map<IList<IGroup>>(groups));

        internal virtual async Task LoadPartsAsync(IList<IGroup> groups)
        {
            Parts = MapParts(groups, await Application.GetPartsAsync(groups));
        }

        internal virtual IList<PartViewModel> MapParts(IList<IGroup> groups, IList<IPart> parts)
            => groups.Select(g => MapPart(g, parts.FirstOrDefault(p => p.GroupId == g.Id))).ToList();

        internal virtual PartViewModel MapPart(IGroup group, IPart part)
        {
            var result = Mapper.Map<IGroup, PartViewModel>(
                group,
                opt => opt.ConstructServicesUsing(
                    _ => ViewModel(e => new PartViewModel(e))
                )
            );

            return part is null ? result : Mapper.Map(part, result);
        }

        internal virtual IList<GroupViewModel> Expand(GroupViewModel group)
            => Expand(new[] {group});

        internal virtual IList<GroupViewModel> Expand(IList<GroupViewModel> groups)
            => groups?.Any() == true 
                ? groups.Concat(Expand(groups.SelectMany(i => i.Children).ToList())).ToList()
                : new List<GroupViewModel>();

        #endregion
    }
}