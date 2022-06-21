using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpectrumAssignment.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ButtonControlWithProgressBar : Frame
    {
        public ButtonControlWithProgressBar()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> Tapped;
     

        public static readonly BindableProperty IsInProgressProperty = BindableProperty.Create(
        propertyName: nameof(IsInProgress),
        returnType: typeof(bool),
        declaringType: typeof(ButtonControlWithProgressBar),
        defaultValue: false,
        defaultBindingMode: BindingMode.OneWay);


        public bool IsInProgress
        {
            get => (bool)GetValue(IsInProgressProperty);
            set { SetValue(IsInProgressProperty, value); }
        }


        public static readonly BindableProperty TextProperty = BindableProperty.Create(
        propertyName: nameof(Text),
        returnType: typeof(string),
        declaringType: typeof(ButtonControlWithProgressBar),
        defaultValue: "",
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: TextPropertyChanged);

        private static void TextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var controls = (ButtonControlWithProgressBar)bindable;
            if (newValue != null)
            {
                controls.lblText.Text = (string)newValue;
            }
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set { SetValue(TextProperty, value); }
        }

      
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        propertyName: nameof(Command),
        returnType: typeof(ICommand),
        declaringType: typeof(ButtonControlWithProgressBar),
        defaultBindingMode: BindingMode.OneWay);
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set { SetValue(CommandProperty, value); }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Tapped?.Invoke(sender, e);
        }
    }
}