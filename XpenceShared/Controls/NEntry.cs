using System;
using Xamarin.Forms;

namespace XpenceShared.Controls
{
    public class NEntry : StackLayout
    {

        public NBEntry Entry = new NBEntry();
        public Label Label = new Label();

        public NEntry()
        {
            Orientation = StackOrientation.Vertical;
            // VerticalOptions = LayoutOptions.Start;
            HeightRequest = 70;
            Entry.HeightRequest = 50;
          //  Entry = new NBEntry();
            Entry.HorizontalOptions = LayoutOptions.FillAndExpand;
            Entry.Margin = new Thickness(0);
            Entry.VerticalOptions = LayoutOptions.CenterAndExpand;
            Entry.TextChanged += InsideTextChanged; // It can be reason of memory leak in default xamarin renderer
          //  Label = new Label();
            Label.HorizontalOptions = LayoutOptions.Start;
            Label.Margin = new Thickness(20, 0, 0, 0);

            Children.Add(Label);
            Children.Add(Entry);
        }


        public static BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(NEntry), defaultValue: Color.Transparent, propertyChanged: borderColorChanged);

        private static void borderColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as NEntry;

            if (control != null && control.Entry != null && newValue != null)
            {
                control.Entry.BorderColor = (Color)newValue;
            }
        }

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }


        public static BindableProperty BorderWidthProperty = BindableProperty.Create(nameof(BorderWidth), typeof(float), typeof(NEntry), defaultValue: 0f, propertyChanged: borderWidthChanged);

        private static void borderWidthChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as NEntry;

            if (control != null && control.Entry != null && newValue != null)
            {
                control.Entry.BorderWidth = (float)newValue;
            }
        }

        public float BorderWidth
        {
            get => (float)GetValue(BorderWidthProperty);
            set => SetValue(BorderWidthProperty, value);
        }

        public static BindableProperty BorderRadiusProperty = BindableProperty.Create(nameof(BorderRadius), typeof(float), typeof(NEntry), defaultValue: 0f, propertyChanged: borderRadiusChaged);

        private static void borderRadiusChaged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as NEntry;

            if (control != null && control.Entry != null && newValue != null)
            {
                control.Entry.BorderRadius = (float)newValue;
            }
        }

        public float BorderRadius
        {
            get => (float)GetValue(BorderRadiusProperty);
            set => SetValue(BorderRadiusProperty, value);
        }



        public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(NEntry), propertyChanged: textChanged, defaultBindingMode: BindingMode.TwoWay);

        private static void textChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as NEntry;

            if(control != null && control.Entry != null && newValue != null)
            {
                control.Entry.Text = (string)newValue;
            }
        }

        private void InsideTextChanged(object obj, EventArgs args)
        {
            Text = Entry.Text;
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(NEntry), propertyChanged: placeHolderChanged);

        private static void placeHolderChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as NEntry;

            if (control != null && control.Label != null && newValue != null)
            {
                control.Label.Text = (string)newValue;
            }

        }

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public static BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(NEntry), defaultValue: Color.Transparent, propertyChanged: textColorChanged);

        private static void textColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as NEntry;

            if (control != null && control.Entry != null && newValue != null)
            {
                control.Entry.TextColor = (Color)newValue;
            }
        }

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public static BindableProperty PlaceholderColorProperty = BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(NEntry), defaultValue: Color.Transparent, propertyChanged: placeHolderColorChanged);

        private static void placeHolderColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as NEntry;

            if (control != null && control.Label != null && newValue != null)
            {
                control.Label.TextColor = (Color)newValue;
            }
        }

        public Color PlaceholderColor
        {
            get => (Color)GetValue(PlaceholderColorProperty);
            set => SetValue(PlaceholderColorProperty, value);
        }

        public static BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(NEntry), propertyChanged: fontFamilyChanged);

        private static void fontFamilyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as NEntry;

            if (control != null && control.Entry != null && newValue != null)
            {
                control.Entry.FontFamily = (string)newValue;
            }

        }

        public string FontFamily
        {
            get => (string)GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }

        public static BindableProperty PlaceholderFontFamilyProperty = BindableProperty.Create(nameof(PlacehoderFontFamily), typeof(string), typeof(NEntry), propertyChanged: placeHolderFontFamilyChanged);

        private static void placeHolderFontFamilyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as NEntry;

            if (control != null && control.Label != null && newValue != null)
            {
                control.Label.FontFamily = (string)newValue;
            }

        }

        public string PlacehoderFontFamily
        {
            get => (string)GetValue(PlaceholderFontFamilyProperty);
            set => SetValue(PlaceholderFontFamilyProperty, value);
        }

        public static BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(float), typeof(NEntry), defaultValue: 16f, propertyChanged: fontSizePropertyChanged);

        private static void fontSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as NEntry;

            if (control != null && control.Entry != null && newValue != null)
            {
                control.Entry.FontSize = (float)newValue;
            }
        }

        public float FontSize
        {
            get => (float)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public static BindableProperty PlaceholderFontSizeProperty = BindableProperty.Create(nameof(PlaceholderFontSize), typeof(float), typeof(NEntry), defaultValue: 10f, propertyChanged: placeHolderFontSizePropertyChanged);

        private static void placeHolderFontSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as NEntry;

            if (control != null && control.Label != null && newValue != null)
            {
                control.Label.FontSize = (float)newValue;
            }
        }

        public float PlaceholderFontSize
        {
            get => (float)GetValue(PlaceholderFontSizeProperty);
            set => SetValue(PlaceholderFontSizeProperty, value);
        }


        public static BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(NEntry), propertyChanged: keyboardPropertyChanged);

        private static void keyboardPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as NEntry;

            if (control != null && control.Entry != null && newValue != null)
            {
                control.Entry.Keyboard = (Keyboard)newValue;
            }
        }

        public Keyboard Keyboard
        {
            get => (Keyboard)GetValue(KeyboardProperty);
            set => SetValue(KeyboardProperty, value);
        }


        public static BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(NEntry),defaultValue: false, propertyChanged: isPasswordChagedChanged);

        private static void isPasswordChagedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as NEntry;

            if (control != null && control.Entry != null && newValue != null)
            {
                control.Entry.IsPassword = (bool)newValue;
            }
        }

        public bool IsPassword
        {
            get => (bool)GetValue(KeyboardProperty);
            set => SetValue(KeyboardProperty, value);
        }
    }
}
