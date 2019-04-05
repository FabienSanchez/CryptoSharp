using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
using MaterialDesignThemes.Wpf;

namespace CryptoAES
{
    public partial class MainWindow : Window
    {
        private MainForm form = new MainForm();
        private PaletteHelper Palette = new PaletteHelper();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = form;
        }

        private void Decrypt(object sender, RoutedEventArgs e)
        {
            form.Decrypt();
        }

        private void Encrypt(object sender, RoutedEventArgs e)
        {
            form.Encrypt();
        }

        public bool IsDarkMode { get; set; } = true;

        private void Copy(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(form.Output))
            {
                Clipboard.SetText(form.Output);
            }
        }

        private void ToggleDarkMode(object sender, RoutedEventArgs e)
        {
            IsDarkMode = !IsDarkMode;
            Palette.SetLightDark(IsDarkMode);
        }
    }
}