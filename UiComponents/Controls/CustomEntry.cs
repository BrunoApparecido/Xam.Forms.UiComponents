using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Plugin.UiComponents.Controls
{
    public class CustomEntry : Entry
    {

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
    }
}
