using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XpenceShared.Controls
{
    public partial class NPicker : Grid
    {
        private NBPicker _mainPicker = new NBPicker();
        private Label _pickerLabel = new Label();
        private Frame _borderFrame = new Frame();
        private Frame _contentFrame = new Frame();

        public static BindableProperty ItemsListProperty = BindableProperty.Create(nameof(ItemsList), typeof(List<string>), typeof(NPicker), propertyChanged: ItemsListChanged, defaultBindingMode: BindingMode.TwoWay);

        public static BindableProperty SelectedItemProperty = BindableProperty.Create(nameof(SelectedItem), typeof(string), typeof(NPicker), propertyChanged: SelectedItemChanged, defaultBindingMode: BindingMode.TwoWay);

        public static BindableProperty PickerTitleProperty = BindableProperty.Create(nameof(PickerTitle), typeof(string), typeof(NPicker), propertyChanged: PickerTitleChanged);

        public static BindableProperty LabelTextProperty = BindableProperty.Create(nameof(LabelText), typeof(string), typeof(NPicker), propertyChanged: LabelTextChanged);

        public static BindableProperty LabelFontFamilyProperty = BindableProperty.Create(nameof(LabelFontFamily), typeof(string), typeof(NPicker), propertyChanged: LabelFontFamilyChanged);

        public static BindableProperty LabelTextColorProperty = BindableProperty.Create(nameof(LabelTextColor), typeof(Color), typeof(NPicker), defaultValue: Color.Azure, propertyChanged: LabelTextColorChanged);

        public static BindableProperty LabelTextSizeProperty = BindableProperty.Create(nameof(LabelTextSize), typeof(float), typeof(NPicker), defaultValue: 10f, propertyChanged: LabelTextSizeChanged);

        public static BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(NPicker), defaultValue: Color.Transparent, propertyChanged: BorderColorChanged);

        public static BindableProperty PickerBackgroundProperty = BindableProperty.Create(nameof(PickerBackground), typeof(Color), typeof(NPicker), defaultValue: Color.Transparent, propertyChanged: PickerBackgroundChanged);

        public NPicker()
        {
            InitializeComponent();

            HeightRequest = 75;
            _mainPicker.HeightRequest = 50;
            _mainPicker.Margin = new Thickness(0);
            _pickerLabel.Margin = new Thickness(20, 0, 0, 0);

            _mainPicker.SelectedIndexChanged += OnIndexChanged;

            SetBorderFrame();
            SetContentFrame();


            _mainPicker.HorizontalOptions = LayoutOptions.FillAndExpand;
            _mainPicker.VerticalOptions = LayoutOptions.FillAndExpand;

            Children.Add(_pickerLabel);
            Children.Add(_borderFrame);

            ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });
            RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) });
            RowDefinitions.Add(new RowDefinition() { Height = new GridLength(5, GridUnitType.Star) });

            SetRow(_pickerLabel, 0);
            SetRow(_borderFrame, 1);
        }

        private void SetContentFrame()
        {
            _contentFrame.HasShadow = false;
            _contentFrame.CornerRadius = 25;
            _contentFrame.Padding = new Thickness(0);
            _contentFrame.HorizontalOptions = LayoutOptions.FillAndExpand;
            _contentFrame.VerticalOptions = LayoutOptions.FillAndExpand;
            _contentFrame.Content = _mainPicker;
        }

        private void SetBorderFrame()
        {
            _borderFrame.HasShadow = false;
            _borderFrame.CornerRadius = 25;
            _borderFrame.Padding = new Thickness(1);
            _borderFrame.HorizontalOptions = LayoutOptions.FillAndExpand;
            _borderFrame.VerticalOptions = LayoutOptions.FillAndExpand;
            _borderFrame.Content = _contentFrame;
        }

        private void OnIndexChanged(object obj, EventArgs args)
        {
            SelectedItem = (string)_mainPicker.SelectedItem;
        }

        private static void ItemsListChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as NPicker;

            if (control != null && control._mainPicker != null && newValue != null)
            {
                control._mainPicker.ItemsSource = (List<string>)newValue;
            }
        }

        public List<string> ItemsList
        {
            get => (List<string>)GetValue(ItemsListProperty);
            set => SetValue(ItemsListProperty, value);
        }

        private static void SelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as NPicker;

            if (control != null && control._mainPicker != null && newValue != null)
            {
                control._mainPicker.SelectedItem = (string)newValue;
            }
        }

        public string SelectedItem
        {
            get => (string)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        private static void PickerTitleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as NPicker;

            if (control != null && control._mainPicker != null && newValue != null)
            {
                control._mainPicker.Title = (string)newValue;
            }
        }

        public string PickerTitle
        {
            get => (string)GetValue(PickerTitleProperty);
            set => SetValue(PickerTitleProperty, value);
        }

        private static void LabelTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is NPicker control && control._pickerLabel != null && newValue != null)
            {
                control._pickerLabel.Text = (string)newValue;
            }
        }

        public string LabelText
        {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        private static void LabelFontFamilyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is NPicker control && control._pickerLabel != null && newValue != null)
            {
                control._pickerLabel.FontFamily = (string)newValue;
            }
        }

        public string LabelFontFamily
        {
            get => (string)GetValue(LabelFontFamilyProperty);
            set => SetValue(LabelFontFamilyProperty, value);
        }

        private static void LabelTextColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is NPicker control && control._pickerLabel != null && newValue != null)
            {
                control._pickerLabel.TextColor = (Color)newValue;
            }
        }

        public Color LabelTextColor
        {
            get => (Color)GetValue(LabelTextColorProperty);
            set => SetValue(LabelTextColorProperty, value);
        }

        private static void LabelTextSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is NPicker control && control._pickerLabel != null && newValue != null)
            {
                control._pickerLabel.FontSize = (float)newValue;
            }
        }

        public float LabelTextSize
        {
            get => (int)GetValue(LabelTextSizeProperty);
            set => SetValue(LabelTextSizeProperty, value);
        }

        private static void BorderColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is NPicker control && control._borderFrame != null && newValue != null)
            {
                control._borderFrame.BackgroundColor = (Color)newValue;
            }
        }

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        private static void PickerBackgroundChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is NPicker control && control._contentFrame != null && newValue != null)
            {
                control._contentFrame.BackgroundColor = (Color)newValue;
            }
        }

        public Color PickerBackground
        {
            get => (Color)GetValue(PickerBackgroundProperty);
            set => SetValue(PickerBackgroundProperty, value);
        }

    }
}
