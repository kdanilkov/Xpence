using System.Windows.Input;
using Xamarin.Forms;

namespace XpenceShared.Controls
{
    public class LongTapGuestureRecognizer : Element, IGestureRecognizer
    {
		public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(LongTapGuestureRecognizer), (object)null, BindingMode.OneWay, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);

		public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(LongTapGuestureRecognizer), (object)null, BindingMode.TwoWay, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)null, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);

		public ICommand Command
		{
			get => (ICommand)GetValue(CommandProperty);
		    set => SetValue(CommandProperty, (object)value);
		}

		public object CommandParameter
		{
			get => GetValue(CommandParameterProperty);
		    set => SetValue(CommandParameterProperty, value);
		}
    }
}
