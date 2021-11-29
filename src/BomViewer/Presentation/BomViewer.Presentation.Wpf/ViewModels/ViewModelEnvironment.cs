using System;
using AutoMapper;
using BomViewer.Application;
using BomViewer.Presentation.Wpf.Mapping;

namespace BomViewer.Presentation.Wpf.ViewModels
{
    /// <summary>
    /// Environment for view models
    /// </summary>
    public class ViewModelEnvironment
    {
        #region Properties

        /// <summary>
        /// Application
        /// </summary>
        public IApplication Application { get; }

        /// <summary>
        /// Mapper
        /// </summary>
        public IMapper Mapper { get; }

        #endregion


        #region Constructors

        /// <summary>
        /// Init new instance
        /// </summary>
        /// <param name="application"></param>
        public ViewModelEnvironment(IApplication application) : this(application, MappingFactory.Init())
        {
        }

        /// <summary>
        /// Init new instance
        /// </summary>
        /// <param name="application"></param>
        /// <param name="mapper"></param>
        public ViewModelEnvironment(IApplication application, IMapper mapper)
        {
            Application = application ?? throw new ArgumentNullException(nameof(application));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion
    }
}