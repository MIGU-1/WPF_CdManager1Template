using CdManager.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CdManager.Wpf
{
    /// <summary>
    /// Interaction logic for AddCdWindow.xaml
    /// </summary>
    public partial class AddCdWindow : Window
    {
        private Cd _cd;
        public AddCdWindow(Cd selectedCd)
        {
            InitializeComponent();
            Loaded += AddCdWindow_Loaded;
            _cd = selectedCd;
        }

        private void AddCdWindow_Loaded(object sender, RoutedEventArgs e)
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;

            if (_cd == null)
            {
                DataContext = new Cd()
                {
                    AlbumTitle = "Bitte Titel eingeben",
                    Artist = "Bitte Artist eingeben"
                };
            }
            else
            {
                DataContext = _cd;
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_cd == null)
            {
                Repository.GetInstance().AddCd(DataContext as Cd);
            }

            Close();
        }
    }
}
