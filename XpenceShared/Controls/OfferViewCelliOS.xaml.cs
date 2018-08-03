using Xamarin.Forms.Xaml;

namespace XpenceShared.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OfferViewCelliOs
	{
		public OfferViewCelliOs ()
		{
			InitializeComponent ();
		}

        //protected override void OnBindingContextChanged()
        //{
        //    base.OnBindingContextChanged();


        //    if (BindingContext is BankOffer data)
        //    {

        //        var frame = new NFrame()
        //        {
        //            VerticalOptions = LayoutOptions.StartAndExpand
        //        };

        //        var layout = new Grid()
        //        {
        //            ColumnDefinitions = new ColumnDefinitionCollection()
        //            {
        //                new ColumnDefinition() {Width = GridLength.Star},
        //                new ColumnDefinition() {Width = GridLength.Star},
        //                new ColumnDefinition() {Width = GridLength.Star}
        //            },

        //            RowDefinitions = new RowDefinitionCollection()
        //            {
        //                new RowDefinition(){Height =Device.GetNamedSize(NamedSize.Large, typeof(NLabel))},
        //                new RowDefinition(){Height =GridLength.Auto},
        //                new RowDefinition(){Height = Device.GetNamedSize(NamedSize.Small, typeof(NLabel)) * 1.5},
        //                new RowDefinition(){Height = Device.GetNamedSize(NamedSize.Small, typeof(NLabel)) * 1.5}
                       
        //            },
        //            ColumnSpacing = 0,
        //            RowSpacing = 0,
        //            Padding = new Thickness(0),
        //            Margin = 0,
        //            VerticalOptions = LayoutOptions.FillAndExpand,
        //            HorizontalOptions = LayoutOptions.FillAndExpand
        //        };




        //        layout.Children.Add(new NLabel()
        //        {
        //            Text = string.Format("{0}", data.Name),
        //            Style = (Style)Application.Current.Resources["BlueTitle"]
        //        }
        //            ,
        //            0, 3, 0, 1

        //            );
        //        layout.Children.Add(
        //            new NLabel()
        //            {
        //                Text = string.Format("{0}", data.Text),
        //                Style = (Style)Application.Current.Resources["SubTitle"],
        //                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(NLabel)),
        //                HorizontalOptions = LayoutOptions.StartAndExpand,
        //                VerticalOptions = LayoutOptions.StartAndExpand
        //            },
        //            0, 3, 1, 2
        //        );


               

        //        layout.Children.Add(
        //            new NLabel()
        //            {
        //                Text = string.Format("{0}", data.Discount),
        //                Style = (Style)Application.Current.Resources["Title"],
        //                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(NLabel)),
        //                HorizontalTextAlignment = TextAlignment.Start
        //            },
        //            0, 2, 2, 3
        //        );

        //        layout.Children.Add(
        //            new NLabel()
        //            {
        //                Text = string.Format("{0:F2}", data.Distance),
        //                Style = (Style)Application.Current.Resources["Title"],
        //                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(NLabel)),
        //                HorizontalTextAlignment = TextAlignment.End,
        //                VerticalTextAlignment = TextAlignment.End,
        //                VerticalOptions = LayoutOptions.End
        //            },
        //            2, 3, 2, 3
        //        );

        //        layout.Children.Add(
        //            new NLabel()
        //            {
        //                Text = string.Format("{0}", data.CategoryText),
        //                Style = (Style)Application.Current.Resources["Title"],
        //                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(NLabel)),
        //                HorizontalTextAlignment = TextAlignment.End,
        //                VerticalTextAlignment = TextAlignment.Start,
        //                VerticalOptions = LayoutOptions.Start
        //            },
        //            2, 3, 3, 4
        //        );
               
               




        //        try
        //        {
        //            frame.Content = layout;
        //        }
        //        catch (Exception e)
        //        {
        //            Debug.WriteLine(e);

        //        }



        //        View = frame;

        //        ForceUpdateSize();
        //    }



        //}
    }
}