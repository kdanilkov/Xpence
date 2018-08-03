using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Prism.Navigation;
using Xamarin.Forms;

namespace Registration.ViewModels
{
    public class ViewAViewModel : BindableBase, INavigatedAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewAViewModel()
        {
            Title = "View A";
        }


        public void OnNavigatedFrom(NavigationParameters parameters)
        {
           
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            var parameterName = "Par";
            if (parameters.ContainsKey(parameterName))
            {
                Title = Title + (string) parameters[parameterName];
            }
        }
    }
}
