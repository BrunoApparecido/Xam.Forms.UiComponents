﻿using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Plugin.UiComponents.Controls;
using Plugin.UiComponents.Platforms.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace Plugin.UiComponents.Platforms.Android
{
    public class CustomEntryRenderer : EntryRenderer
    {
        private GradientDrawable _gradientDrawable;

        public CustomEntryRenderer(Context context) : base(context)
        {
            _gradientDrawable = new GradientDrawable();
            _gradientDrawable.SetShape(ShapeType.Rectangle);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            Control.SetPadding(PaddingLeft + 30, PaddingTop + 30, PaddingRight + 30, PaddingBottom + 30);            

            UpdateBorderColor();
            UpdateCornerRadius();
            UpdateBackground();
            UpdateIcon();           
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == CustomEntry.BorderColorProperty.PropertyName)
                UpdateBorderColor();
            else if (e.PropertyName == CustomEntry.CornerRadiusProperty.PropertyName)
                UpdateCornerRadius();
            else if (e.PropertyName == CustomEntry.IconLeftProperty.PropertyName || e.PropertyName ==  CustomEntry.IconRightProperty.PropertyName)
                UpdateIcon();

            UpdateBackground();
        }

        protected override void UpdateBackgroundColor()
        {
           // base.UpdateBackgroundColor();

            _gradientDrawable.SetColor(Element.BackgroundColor.ToAndroid());
        }

        private void UpdateBorderColor()
        {
            _gradientDrawable.SetStroke(3, ((CustomEntry)Element).BorderColor.ToAndroid());
        }

        private void UpdateCornerRadius()
        {
            _gradientDrawable.SetCornerRadius(((CustomEntry)Element).CornerRadius);
        }

        private void UpdateBackground()
        {
            Control.SetBackground(_gradientDrawable);
        }        

        private void UpdateIcon()
        {
            var drawLeft = Context.GetDrawable(((CustomEntry)Element).IconLeft);
            var drawRight = Context.GetDrawable(((CustomEntry)Element).IconRight);

            drawLeft?.Bounds.Offset(-20, 0);
            drawLeft?.SetBounds(0, 0, drawLeft.IntrinsicWidth, drawLeft.IntrinsicHeight);

            drawRight?.Bounds.Offset(15, 0);
            drawRight?.SetBounds(0, 0, drawRight.IntrinsicWidth, drawRight.IntrinsicHeight);


            Control.SetCompoundDrawables(
                drawLeft,
                null,
                drawRight, 
                null
            );
        }





    }
}
