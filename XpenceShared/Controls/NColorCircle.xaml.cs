using Xamarin.Forms;

namespace XpenceShared.Controls
{
    public partial class NColorCircle : ContentView
    {

        public NColorCircle()
        {
            InitializeComponent();
            frameCircle.Margin = new Thickness(0);
            frameCircle.Padding = new Thickness(0);
            frameCircle.HasShadow = false;
            frameCircle.BackgroundColor = Color.Transparent;
            frameCircle.HorizontalOptions = LayoutOptions.Center;
            frameCircle.VerticalOptions = LayoutOptions.Center;
            labelCircle.BackgroundColor = Color.Transparent;
			labelCircle.HorizontalOptions = LayoutOptions.Center;
			labelCircle.VerticalOptions = LayoutOptions.Center;
            labelCircle.HorizontalTextAlignment = TextAlignment.Center;
            labelCircle.VerticalTextAlignment = TextAlignment.Center;
            labelCircle.Margin = new Thickness(0);
		}

        public static readonly BindableProperty CircleColorProperty = BindableProperty.Create(
            nameof(CircleColor), typeof(Color), typeof(NColorCircle),defaultValue: Color.Gray, propertyChanged: colorPropertyChanged);


		public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
            nameof(BorderColor), typeof(Color), typeof(NColorCircle), defaultValue: Color.Transparent, propertyChanged: borderColorPropertyChanged);

      

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            nameof(TextColor), typeof(Color), typeof(NColorCircle), defaultValue: Color.Black, propertyChanged: textColorPropertyChanged);


        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            nameof(FontSize), typeof(double), typeof(NColorCircle),defaultValue: (double) 10,  propertyChanged: fontSizePropertyChanged);

		public static readonly BindableProperty RadiusProperty = BindableProperty.Create(
            nameof(Radius), typeof(double), typeof(NColorCircle), defaultValue: (double) 50, propertyChanged: radiusPropertyChanged);

		public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
	    	nameof(FontFamily), typeof(string), typeof(NColorCircle), propertyChanged: fontFamilyPropertyChanged);

		public static readonly BindableProperty TextProperty = BindableProperty.Create(
	        nameof(Text), typeof(string), typeof(NColorCircle), propertyChanged: textPropertyChanged);



        public Color CircleColor{
            get => (Color)GetValue(CircleColorProperty);
            set => SetValue(CircleColorProperty,value);
        }

        public Color BorderColor
		{
			get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

		public Color TextColor
		{
			get => (Color)GetValue(TextColorProperty);
		    set => SetValue(TextColorProperty, value);
		}

        public double FontSize
		{
			get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }


		public double Radius
		{
			get => (double)GetValue(RadiusProperty);
		    set => SetValue(RadiusProperty, value);
		}

		public string FontFamily
		{
			get => (string)GetValue(FontFamilyProperty);
		    set => SetValue(FontFamilyProperty, value);
		}

		public string Text
		{
			get => (string)GetValue(TextProperty);
		    set => SetValue(TextProperty, value);
		}

		private static void colorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
            var control = (NColorCircle)bindable;

            var color = (Color)newValue;
            control.frameCircle.BackgroundColor = color;

		}

		private static void textColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var control = (NColorCircle)bindable;

			var color = (Color)newValue;
            control.labelCircle.TextColor = color;
		}

		private static void fontSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var control = (NColorCircle)bindable;

            var size = (double)newValue;
            control.labelCircle.FontSize = size;
		}

		private static void radiusPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var control = (NColorCircle)bindable;

			var size = (double)newValue;
            control.frameCircle.HeightRequest = size * 2;
            control.frameCircle.WidthRequest = size * 2;
            control.frameCircle.CornerRadius = (float)size;
		}

		private static void fontFamilyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
            var control = (NColorCircle)bindable;
			var fontFamily = (string)newValue;
            if(string.IsNullOrEmpty(fontFamily)){
                return;
            }
            control.labelCircle.FontFamily = fontFamily;
		}

		private static void textPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var control = (NColorCircle)bindable;
			var text = (string)newValue;

            if (string.IsNullOrEmpty(text))
                return;
          
            control.labelCircle.Text = text;
		}

		private static void borderColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var control = (NColorCircle)bindable;

			var color = (Color)newValue;
            control.frameCircle.BackgroundColor = color;
		}

	}
}
