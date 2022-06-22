using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpectrumAssignment.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AvatarCreatorControl : Frame
    {
        private List<Color> _randomColorList = new List<Color>()
        {
            Color.Orange,
            Color.LightBlue,
            Color.LightCoral,
            Color.LightGray
        };

        public AvatarCreatorControl()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
        propertyName: nameof(Text),
        returnType: typeof(string),
        declaringType: typeof(AvatarCreatorControl),
        defaultValue: "",
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: TextPropertyChanged);

        private static void TextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var controls = (AvatarCreatorControl)bindable;
            if (newValue != null)
            {
                controls.lblUserName.Text = ((string)newValue).Trim().Substring(0, 1).ToUpper();
            }
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set { SetValue(TextProperty, value); }
        }


        public static readonly BindableProperty IsRandomBackgroundProperty = BindableProperty.Create(
       propertyName: nameof(IsRandomBackground),
       returnType: typeof(bool),
       declaringType: typeof(AvatarCreatorControl),
       defaultValue: false,
       defaultBindingMode: BindingMode.OneWay,
       propertyChanged: IsRandomBackgroundPropertyChanged);

        private static void IsRandomBackgroundPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var controls = (AvatarCreatorControl)bindable;
            if (newValue != null && (bool)newValue)
            {
                controls.frmAvatar.Opacity = 0;
                controls.frmAvatar.FadeTo(1, 4000);
                controls.frmAvatar.BackgroundColor = controls._randomColorList[new Random().Next(controls._randomColorList.Count)];
            }
        }

        public bool IsRandomBackground
        {
            get => (bool)GetValue(IsRandomBackgroundProperty);
            set { SetValue(IsRandomBackgroundProperty, value); }
        }
    }
}