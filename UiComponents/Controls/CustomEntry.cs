using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Plugin.UiComponents.Controls
{
    public class CustomEntry : Entry
    {
        private object _oldUnfocuseColor;

        public CustomEntry()
        {
            this.Focused += ApplyColorFocused;
            this.Unfocused += ApplyColorUnFocused;
        }

        private void ApplyColorFocused(object a, FocusEventArgs e)
        {
            if (BorderColorFocused != BorderColor)
            {
                _oldUnfocuseColor = BorderColor;
                BorderColor = BorderColorFocused;
            }
        }

        private void ApplyColorUnFocused(object sender, FocusEventArgs e)
        {
            if (_oldUnfocuseColor != null)
            {
                BorderColor = (Color) _oldUnfocuseColor;
                _oldUnfocuseColor = null;
            }
        }


        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create("BorderColor",
                typeof(Color),
                typeof(object),
                Color.Black);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty BorderColorFocusedProperty =
            BindableProperty.Create("BorderColorFocused",
                typeof(Color),
                typeof(object),
                Color.Black);

        public Color BorderColorFocused
        {
            get { return (Color)GetValue(BorderColorFocusedProperty); }
            set { SetValue(BorderColorFocusedProperty, value); }
        }


        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create("CornerRadius",
                typeof(float),
                typeof(object),
                default(float));

        public float CornerRadius
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty IconLeftProperty =
            BindableProperty.Create("IconLeft",
                typeof(string),
                typeof(object),
                null);

        public string IconLeft
        {
            get { return (string)GetValue(IconLeftProperty); }
            set { SetValue(IconLeftProperty, value); }
        }

        public static readonly BindableProperty IconRightProperty =
            BindableProperty.Create("IconRight",
                typeof(string),
                typeof(object),
                null);

        public string IconRight
        {
            get { return (string)GetValue(IconRightProperty); }
            set { SetValue(IconRightProperty, value); }
        }

    }
}
