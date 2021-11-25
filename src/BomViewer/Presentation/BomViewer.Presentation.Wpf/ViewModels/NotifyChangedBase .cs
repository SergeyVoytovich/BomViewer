using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BomViewer.Presentation.Wpf.ViewModels
{
    /// <summary>
    /// Base notify changed object
    /// </summary>
    public abstract class NotifyChangedBase : INotifyPropertyChanged
    {
        #region Fields

        private readonly ConcurrentDictionary<string, object> _properties;

        #endregion


        #region Constructors

        /// <summary>
        /// Initialized new instance
        /// </summary>
        protected NotifyChangedBase() : this(new ConcurrentDictionary<string, object>())
        {
        }

        /// <summary>
        /// Initialized new instance
        /// </summary>
        protected NotifyChangedBase(ConcurrentDictionary<string, object> properties)
        {
            _properties = properties ?? throw new ArgumentNullException(nameof(properties));
        }

        #endregion


        #region Events

        /// <summary>
        /// Property changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Property changed invoker
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


        #region Methods

        /// <summary>
        /// Get property value
        /// </summary>
        /// <typeparam name="T">Expected type of property</typeparam>
        /// <param name="propertyName">Property name</param>
        /// <returns>Property value</returns>
        protected internal virtual T Get<T>([CallerMemberName] string propertyName = null)
            => string.IsNullOrWhiteSpace(propertyName) ? default : (T)_properties.GetOrAdd(propertyName, default(T));

        /// <summary>
        /// Set property value
        /// </summary>
        /// <typeparam name="T">Property value type</typeparam>
        /// <param name="value">Value</param>
        /// <param name="propertyName">Property name</param>
        protected internal virtual void Set<T>(T value, [CallerMemberName] string propertyName = null)
        {
            var notify = false;
            _properties.AddOrUpdate(propertyName,
                _ =>
                {
                    notify = true;
                    return value;
                },
                (_, old) =>
                {
                    if (Equals(old, value))
                    {
                        return old;
                    }

                    notify = true;
                    return value;
                });

            if (notify)
            {
                OnPropertyChanged(propertyName);
            }
        }


        #endregion
    }
}