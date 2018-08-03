using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace XpenceShared.Controls
{
    public partial class NNSwitch : ContentView
    {

		public static readonly BindableProperty OnColorProperty = BindableProperty.Create(
   nameof(OnColor), typeof(Color), typeof(NNSwitch), defaultValue: Color.Gray, propertyChanged: onColorPropertyChanged);



		public static readonly BindableProperty OffColorProperty = BindableProperty.Create(
			nameof(OffColor), typeof(Color), typeof(NNSwitch), defaultValue: Color.Black, propertyChanged: offColorPropertyChanged);



		public static readonly BindableProperty OutlineColorProperty = BindableProperty.Create(
			nameof(OutlineColor), typeof(Color), typeof(NNSwitch), defaultValue: Color.Black, propertyChanged: outlineColorPropertyChanged);



		public static readonly BindableProperty RadiusProperty = BindableProperty.Create(
			nameof(Radius), typeof(double), typeof(NNSwitch), defaultValue: (double)50, propertyChanged: radiusPropertyChanged);



		public static readonly BindableProperty ToggledProperty = BindableProperty.Create(
		 nameof(Radius), typeof(bool), typeof(NNSwitch), defaultValue: false, defaultBindingMode: BindingMode.TwoWay, propertyChanged: toggledPropertyChanged);

		public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(NNSwitch));



		public NNSwitch()
        {
            InitializeComponent();

            Margin = 0;
            Padding = 0;

			var tappedRecognizer = new TapGestureRecognizer();
			tappedRecognizer.Tapped += onTapped;
            innerFrame.GestureRecognizers.Add(tappedRecognizer);

            HorizontalOptions =  innerFrame.HorizontalOptions = outerFrame.HorizontalOptions = LayoutOptions.Center;
            VerticalOptions = innerFrame.VerticalOptions = outerFrame.VerticalOptions = LayoutOptions.Center;
			

        }



		private void onTapped(object sender, EventArgs e)
		{
			Toggled = !Toggled;
		}



		public Color OnColor
		{
			get => (Color)GetValue(OnColorProperty);
		    set => SetValue(OnColorProperty, value);
		}

		public Color OffColor
		{
			get => (Color)GetValue(OffColorProperty);
		    set => SetValue(OffColorProperty, value);
		}


		public Color OutlineColor
		{
			get => (Color)GetValue(OutlineColorProperty);
		    set => SetValue(OutlineColorProperty, value);
		}

		public double Radius
		{
			get => (double)GetValue(RadiusProperty);
		    set => SetValue(RadiusProperty, value);
		}


		public bool Toggled
		{
			get => (bool)GetValue(ToggledProperty);
		    set => SetValue(ToggledProperty, value);
		}

		public ICommand Command
		{
			get => (ICommand)GetValue(CommandProperty);
		    set => SetValue(CommandProperty, value);
		}

		private static void onColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var control = bindable as NNSwitch;

			if (control != null)
			{
				
				setColor(control);
			}
		}

		private static void offColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var control = bindable as NNSwitch;

			if (control != null)
			{
				
				setColor(control);
			}
		}

		private static void outlineColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var control = bindable as NNSwitch;

			if (control != null)
			{
                control.outerFrame.BackgroundColor = (Color)newValue;
			}
		}

		private static void radiusPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var control = bindable as NNSwitch;

			if (control != null)
			{
				var size = (double)newValue;
                control.HeightRequest = control.outerFrame.HeightRequest = size * 2;
                control.WidthRequest = control.outerFrame.WidthRequest = size * 2;
                control.innerFrame.HeightRequest = control.outerFrame.HeightRequest - 2;
                control.innerFrame.WidthRequest = control.outerFrame.WidthRequest - 2;
                control.innerFrame.CornerRadius = (float)size - 1;
                control.outerFrame.CornerRadius = (float)size;

			}
		}

		private static void toggledPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var control = bindable as NNSwitch;



			if (control != null)
			{
				setColor(control);

				if (control.Command != null && control.Command.CanExecute(control.Toggled))
				{
					control.Command.Execute(control.Toggled);
				}
			}
		}

		private static void setColor(NNSwitch control)
		{
            control.innerFrame.BackgroundColor = control.Toggled ? control.OnColor : control.OffColor;
            control.outerFrame.BackgroundColor = control.OutlineColor;
		}

	}
}
