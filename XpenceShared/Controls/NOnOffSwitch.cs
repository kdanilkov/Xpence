using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace XpenceShared.Controls
{
    


    public class NOnOffSwitch : ContentView
    {

        public static readonly BindableProperty OnColorProperty = BindableProperty.Create(
           nameof(OnColor), typeof(Color), typeof(NOnOffSwitch), defaultValue: Color.Gray, propertyChanged: onColorPropertyChanged);

       

        public static readonly BindableProperty OffColorProperty = BindableProperty.Create(
            nameof(OffColor), typeof(Color), typeof(NOnOffSwitch), defaultValue: Color.Black, propertyChanged: offColorPropertyChanged);

      

        public static readonly BindableProperty OutlineColorProperty = BindableProperty.Create(
            nameof(OutlineColor), typeof(Color), typeof(NOnOffSwitch), defaultValue: Color.Black, propertyChanged: outlineColorPropertyChanged);

     

        public static readonly BindableProperty RadiusProperty = BindableProperty.Create(
            nameof(Radius), typeof(double), typeof(NOnOffSwitch), defaultValue: (double)50, propertyChanged: radiusPropertyChanged);

       

        public static readonly BindableProperty ToggledProperty = BindableProperty.Create(
            nameof(Toggled), typeof(bool), typeof(NOnOffSwitch), defaultValue: false, propertyChanged: toggledPropertyChanged, defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(NOnOffSwitch));
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(NOnOffSwitch));

        public Frame frame;
       
        public NOnOffSwitch()
        {
            Margin = new Thickness(0);
            Padding = new Thickness(0);
           


            frame = new Frame
            {
                HasShadow = false,
            //    IsClippedToBounds= true,

            };

            var tappedRecognizer = new TapGestureRecognizer();
            tappedRecognizer.Tapped += onTapped;
            frame.GestureRecognizers.Add(tappedRecognizer);

            //if(Device.RuntimePlatform == TargetPlatform.iOS.ToString("G"))
            //{
            //    frame.HasShadow = false;
            //    frame.Padding = new Thickness(1);
            //}
            Content = frame;

            frame.HorizontalOptions = LayoutOptions.Center;
            frame.VerticalOptions = LayoutOptions.Center;
            HorizontalOptions = LayoutOptions.Center;
            VerticalOptions = LayoutOptions.Center;
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

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }



        private static void onColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as NOnOffSwitch;

            if(control != null)
            {
                control.OnColor = (Color)newValue;
                setColor(control);
            }
        }

        private static void offColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as NOnOffSwitch;

            if (control != null)
            {
                control.OffColor = (Color)newValue;
                setColor(control);
            }
        }

        private static void outlineColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is NOnOffSwitch control)
            {
                control.frame.BorderColor = (Color)newValue;
            }
        }

        private static void radiusPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is NOnOffSwitch control)
            {
                var size = (double)newValue;
                control.HeightRequest = control.frame.HeightRequest = size * 2;
                control.WidthRequest =  control.frame.WidthRequest = size * 2;
                control.frame.CornerRadius = (float)size;
         
            }
        }

        private static void toggledPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is NOnOffSwitch control)
            {
                setColor(control);

                if (control.Command != null && control.Command.CanExecute(control.CommandParameter))
                {
                    control.Command.Execute(control.CommandParameter);
                }
            }
        }

        private static void setColor(NOnOffSwitch control)
        {
            control.frame.BackgroundColor = control.Toggled ? control.OnColor : control.OffColor;
            if (Device.RuntimePlatform ==  Device.iOS)
            {
                control.frame.BorderColor = control.OutlineColor;
            }
        }
    }
}
