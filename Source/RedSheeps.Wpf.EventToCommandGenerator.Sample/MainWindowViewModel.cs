using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RedSheeps.Input;
using RedSheeps.Wpf.EventToCommandGenerator.Sample.Annotations;

namespace RedSheeps.Wpf.EventToCommandGenerator.Sample
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _message;
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand LoadedCommand => new Command(() => Message = "Hello, EventToCommand Generator!");

        public string Message
        {
            get => _message;
            set
            {
                if (value == _message) return;
                _message = value;
                OnPropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}