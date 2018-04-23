﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pyrenaction.Views
{
    /// <summary>
    /// Logique d'interaction pour ucTabBord.xaml
    /// </summary>
    public partial class ucTabBord : UserControl
    {
        public ucTabBord()
        {
            InitializeComponent();

            using (Models.pyrenactionEntities context = new Models.pyrenactionEntities())
            {

                var query = from U in context.Actions select U;
                List<Models.Action> listeActions = query.ToList();

                dataGrid.ItemsSource = listeActions;



            }

        }

    }
}