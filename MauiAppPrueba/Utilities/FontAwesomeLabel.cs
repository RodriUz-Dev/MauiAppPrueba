﻿
namespace MauiAppPrueba.Utilities
{
    public class FontAwesomeLabel : Label
    {
        public FontAwesomeLabel()
        {
            Populate();
        }

        public bool UseSolidFont
        {
            get { return (bool)GetValue(UseSolidFontProperty); }
            set { SetValue(UseSolidFontProperty, value); }
        }

        public static readonly BindableProperty UseSolidFontProperty =
            BindableProperty.Create(nameof(UseSolidFont), typeof(bool), typeof(FontAwesomeLabel),
                defaultValue: false,
                propertyChanged: (bindable, oldValue, newValue) =>
                {

                    ((FontAwesomeLabel)bindable).Populate();
                });

        private void Populate()
        {

            this.FontFamily = UseSolidFont ? "SolidFont" : "LightFont";

        }
    }
}
