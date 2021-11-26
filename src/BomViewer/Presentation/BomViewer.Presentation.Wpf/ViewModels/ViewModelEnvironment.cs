using System;
using AutoMapper;
using BomViewer.Application;
using BomViewer.Presentation.Wpf.Mapping;

namespace BomViewer.Presentation.Wpf.ViewModels
{
    public class ViewModelEnvironment
    {
        #region Properties

        public IApplication Application { get; }
        public IMapper Mapper { get; }

        #endregion


        #region Constructors

        public ViewModelEnvironment(IApplication application) : this(application, MappingFactory.Init())
        {
        }

        public ViewModelEnvironment(IApplication application, IMapper mapper)
        {
            Application = application ?? throw new ArgumentNullException(nameof(application));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion
    }
}