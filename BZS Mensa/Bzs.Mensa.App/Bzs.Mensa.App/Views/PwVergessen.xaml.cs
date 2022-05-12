﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bzs.Mensa.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PwVergessen : ContentPage
    {
        public PwVergessen()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new NeuesPw());
        }
    }
}