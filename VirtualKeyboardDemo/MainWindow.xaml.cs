using System;
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

namespace VirtualKeyboardDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _keyboardFull.Visibility = Visibility.Hidden;
            _keyboardAlf.Visibility = Visibility.Hidden;
            _keyboardNum.Visibility = Visibility.Hidden;
        }

        private void TextBox_IsKeyboardFocusedChangedFull(object sender, DependencyPropertyChangedEventArgs e)
        {
            _keyboardFull.Visibility = Visibility.Visible;
            _keyboardAlf.Visibility = Visibility.Hidden;
            _keyboardNum.Visibility = Visibility.Hidden;
        }

        private void TextBox_IsKeyboardFocusedChangedAlf(object sender, DependencyPropertyChangedEventArgs e)
        {

            _keyboardFull.Visibility = Visibility.Hidden;
            _keyboardAlf.Visibility = Visibility.Visible;
            _keyboardNum.Visibility = Visibility.Hidden;
        }

        private void TextBox_IsKeyboardFocusedChangedNum(object sender, DependencyPropertyChangedEventArgs e)
        {
            _keyboardFull.Visibility = Visibility.Hidden;
            _keyboardAlf.Visibility = Visibility.Hidden;
            _keyboardNum.Visibility = Visibility.Visible;
        }

        private void _mainGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _keyboardFull.Visibility = Visibility.Hidden;
            _keyboardAlf.Visibility = Visibility.Hidden;
            _keyboardNum.Visibility = Visibility.Hidden;
        }
    }
}
