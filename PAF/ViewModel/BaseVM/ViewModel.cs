using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PAF.ViewModel
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        /// <summary>Устанавливает новое значение свойства если оно отличается от текущего</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filed">Текущее значение</param>
        /// <param name="value">Новое значение</param>
        /// <returns>true новое значение было внесено</returns>
        protected virtual bool Set<T>(ref T filed, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(filed, value)) return false;
            filed = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
    }
}