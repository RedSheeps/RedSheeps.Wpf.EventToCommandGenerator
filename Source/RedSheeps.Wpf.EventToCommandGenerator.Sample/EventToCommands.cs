using System.Windows;
using System.Windows.Input;
namespace RedSheeps.Wpf.EventToCommandGenerator.Sample.EventToCommand {

	#region System.Windows.Window
	public static partial class WindowBehavior {

        public static readonly DependencyProperty LoadedProperty =
            DependencyProperty.RegisterAttached("Loaded", typeof(ICommand), typeof(WindowBehavior), new FrameworkPropertyMetadata(OnLoadedChanged));
        
        public static ICommand GetLoaded(DependencyObject target)
        {
            return (ICommand)target.GetValue(LoadedProperty);
        }
        
        public static void SetLoaded(DependencyObject target, ICommand value)
        {
            target.SetValue(LoadedProperty, value);
        }
        
        private static void OnLoadedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is System.Windows.Window target)
            {
                if (e.OldValue != null)
                {
                    target.Loaded -= OnLoaded;
                }
                if (e.NewValue != null)
                {
                    target.Loaded += OnLoaded;
                }
            }
        }
        
        private static void OnLoaded(object o, System.Windows.RoutedEventArgs eventArgs)
        {
			var commandParameter = eventArgs;
            var command = GetLoaded((DependencyObject)o);
            if (command.CanExecute(commandParameter))
                command.Execute(commandParameter);
        }
	}
	#endregion
}

