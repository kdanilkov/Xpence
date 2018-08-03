using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XpenceShared.Utility;

namespace XpenceShared.Controls
{

    public class EnumBindablePicker<T> : NBPicker where T : struct
    {

        private List<T> originalEnumValues = new List<T>();

        public EnumBindablePicker()
        {
            SelectedIndexChanged += OnSelectedIndexChanged;
            //Fill the Items from the enum

             
            foreach (var item in Enum.GetValues(typeof(T)))
            {
                originalEnumValues.Add((T)item);
            }

            foreach (var value in EnumHelper.ToEnumerable(typeof(T)))
            {
                Items.Add(value as string);
            }
        }

        public new static BindableProperty SelectedItemProperty = BindableProperty.Create(nameof(SelectedItem), typeof(T), typeof(EnumBindablePicker<T>), default(T), propertyChanged: OnSelectedItemChanged, defaultBindingMode: BindingMode.TwoWay);

        public new T SelectedItem
        {
            get => (T)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        private void OnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            if (SelectedIndex < 0 || SelectedIndex > Items.Count - 1)
            {
                SelectedItem = default(T);
            }
            else
            {
                // SelectedItem = (T)Enum.Parse(typeof(T), Items[SelectedIndex]);
                SelectedItem = originalEnumValues[SelectedIndex];
            }
        }

        private static void OnSelectedItemChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var picker = bindable as EnumBindablePicker<T>;
            if (newvalue != null)
            {
              //  var element = (T)Enum.Parse(typeof(T), (T) newvalue);

                if (picker != null) picker.SelectedIndex = picker.originalEnumValues.IndexOf((T)newvalue);
            }
        }
    }
}
