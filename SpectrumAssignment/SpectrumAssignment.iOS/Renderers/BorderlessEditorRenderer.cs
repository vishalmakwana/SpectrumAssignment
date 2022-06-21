﻿using SpectrumAssignment.Controls;
using SpectrumAssignment.iOS.Renderer;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BorderLessEditor), typeof(BorderlessEditorRenderer))]

namespace SpectrumAssignment.iOS.Renderer
{
    public class BorderlessEditorRenderer : EditorRenderer
    {
        public static void Init()
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control != null)
            {
                Control.Layer.BorderWidth = 0;
            }
        }
    }
}