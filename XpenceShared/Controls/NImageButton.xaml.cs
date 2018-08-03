using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace XpenceShared.Controls
{
	public partial class NImageButton : ContentView
	{
		public NImageButton()
		{
			InitializeComponent();
		}

		public static readonly BindableProperty ImageProperty = BindableProperty.Create(nameof(Image),
																				   typeof(string),
																				   typeof(NImageButton),

																				   propertyChanged: onImageChanged
																				   );

		public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(NImageButton));

		public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(NImageButton));

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), 
                                                                                       typeof(string), typeof(NImageButton), defaultValue: string.Empty, propertyChanged: onTextChanged);

        private static void onTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (NImageButton)bindable;

            if(control != null && newValue != null ){

                control.textLabel.Text = (string)newValue;
            }

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


		public string Image
		{
			get => (string)GetValue(ImageProperty);
		    set => SetValue(ImageProperty, value);
		}


        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

		private static void onImageChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var control = (NImageButton)bindable;
			if (!string.IsNullOrEmpty(control.Image))
			{
				//control.buttonImage.Source = ImageSource.FromResource(control.Image);
				control.buttonImage.Source = ImageSource.FromFile(control.Image);
                control.buttonImage.Aspect = Aspect.AspectFit;
               // control.buttonImage.Aspect = Aspect.AspectFit;
			}
		}

		void OnTapped(object sender, EventArgs args)
		{

			if (Command != null && Command.CanExecute(CommandParameter))
			{
				Command.Execute(CommandParameter);
			}
		}

	}

}
