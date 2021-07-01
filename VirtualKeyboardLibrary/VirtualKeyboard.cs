using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static VirtualKeyboardLibrary.NativeWin32;

namespace VirtualKeyboardLibrary
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:VirtualKeyboardLibrary"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:VirtualKeyboardLibrary;assembly=VirtualKeyboardLibrary"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    public class VirtualKeyboard : Control
    {
        private ItemsControl _itemsControl;

        static VirtualKeyboard()
        {

            DefaultStyleKeyProperty.OverrideMetadata(typeof(VirtualKeyboard), new FrameworkPropertyMetadata(typeof(VirtualKeyboard)));
        }

        public KeyboardLayout Type
        {
            get { return (KeyboardLayout)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register(nameof(Type), typeof(KeyboardLayout), typeof(VirtualKeyboard));

        public bool IsShift { get; set; }

        public void AddAllButtons()
        {
            _itemsControl = GetTemplateChild("PART_itemsControl") as ItemsControl;

            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.q, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.w, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.e, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.r, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.t, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.y, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.u, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.i, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.o, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.p, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "[" }, 1, VKeyCode.OEM4, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "]" }, 1, VKeyCode.OEM6, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "back" }, 1, VKeyCode.Back, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "7" }, 1, VKeyCode.Numpad7, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "8" }, 1, VKeyCode.Numpad8, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "9" }, 1, VKeyCode.Numpad9, 0));

            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "tab" }, 1, VKeyCode.Tab, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.a, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.s, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.d, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.f, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.g, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.h, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.j, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.k, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.l, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = ";" }, 1, VKeyCode.OEM1, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "," }, 1, VKeyCode.OEM7, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "enter" }, 1, VKeyCode.Return, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "4" }, 1, VKeyCode.Numpad4, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "5" }, 1, VKeyCode.Numpad5, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "6" }, 1, VKeyCode.Numpad6, 1));

            _itemsControl.Items.Add(GetKeyInfo(new Button() { Content = "shift" }, 2, VKeyCode.Shift, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.z, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.x, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.c, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.v, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.b, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.n, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.m, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "," }, 1, VKeyCode.OEMComma, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "." }, 1, VKeyCode.OEMPeriod, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "/" }, 1, VKeyCode.OEM2, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "\\" }, 1, VKeyCode.OEM5, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "1" }, 1, VKeyCode.Numpad1, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "2" }, 1, VKeyCode.Numpad2, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "3" }, 1, VKeyCode.Numpad3, 2));

            _itemsControl.Items.Add(GetKeyInfo(new Button() { Content = "&123" }, 1, VKeyCode.Delete, 3));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "space" }, 9, VKeyCode.Space, 3));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "<" }, 1, VKeyCode.Left, 3));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = ">" }, 1, VKeyCode.Right, 3));

            ComboBox box = new ComboBox();
            box.ItemsSource = GetLanguage();

            _itemsControl.Items.Add(GetKeyInfo(box, 1, VKeyCode.OEM5, 3));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "0" }, 2, VKeyCode.Numpad0, 3));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "." }, 1, VKeyCode.Decimal, 3));

            AddButtonsInfo();
        }

        public void AddNumpadButtons()
        {
            _itemsControl = GetTemplateChild("PART_itemsControl") as ItemsControl;

            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "7" }, 1, VKeyCode.Numpad7, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "8" }, 1, VKeyCode.Numpad8, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "9" }, 1, VKeyCode.Numpad9, 0));

            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "4" }, 1, VKeyCode.Numpad4, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "5" }, 1, VKeyCode.Numpad5, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "6" }, 1, VKeyCode.Numpad6, 1));

            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "1" }, 1, VKeyCode.Numpad1, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "2" }, 1, VKeyCode.Numpad2, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "3" }, 1, VKeyCode.Numpad3, 2));

            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "0" }, 1, VKeyCode.Numpad0, 3));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "." }, 1, VKeyCode.Decimal, 3));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "back" }, 1, VKeyCode.Back, 3));


            AddButtonsInfo();
        }

        public void AddAlfabetButtons()
        {
            _itemsControl = GetTemplateChild("PART_itemsControl") as ItemsControl;

            _itemsControl.Items.Clear();

            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.q, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.w, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.e, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.r, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.t, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.y, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.u, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.i, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.o, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.p, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "[" }, 1, VKeyCode.OEM4, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "]" }, 1, VKeyCode.OEM6, 0));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "back" }, 1, VKeyCode.Back, 0));

            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "tab" }, 1, VKeyCode.Tab, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.a, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.s, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.d, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.f, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.g, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.h, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.j, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.k, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.l, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = ";" }, 1, VKeyCode.OEM1, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "," }, 1, VKeyCode.OEM7, 1));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "enter" }, 1, VKeyCode.Return, 1));

            _itemsControl.Items.Add(GetKeyInfo(new Button() { Content = "shift" }, 2, VKeyCode.Shift, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.z, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.x, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.c, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.v, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.b, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.n, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton(), 1, VKeyCode.m, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "," }, 1, VKeyCode.OEMComma, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "." }, 1, VKeyCode.OEMPeriod, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "/" }, 1, VKeyCode.OEM2, 2));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "\\" }, 1, VKeyCode.OEM5, 2));

            _itemsControl.Items.Add(GetKeyInfo(new Button() { Content = "&123" }, 1, VKeyCode.Delete, 3));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "space" }, 9, VKeyCode.Space, 3));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = "<" }, 1, VKeyCode.Left, 3));
            _itemsControl.Items.Add(GetKeyInfo(new RepeatButton() { Content = ">" }, 1, VKeyCode.Right, 3));

            ComboBox box = new ComboBox();
            box.ItemsSource = GetLanguage();

            _itemsControl.Items.Add(GetKeyInfo(box, 1, VKeyCode.OEM5, 3));

            AddButtonsInfo();
        }

        public override void OnApplyTemplate()
        {
            switch (Type)
            {
                case KeyboardLayout.Full:
                    AddAllButtons();
                    break;
                case KeyboardLayout.Alfbet:
                    AddAlfabetButtons();
                    break;
                case KeyboardLayout.Numpad:
                    AddNumpadButtons();
                    break;
                default:
                    break;
            }

            base.OnApplyTemplate();
        }

        protected void AddButtonsInfo()
        {
            foreach (var item in _itemsControl.Items)
            {
                if (item is ButtonBase)
                {
                    ButtonBase key = item as ButtonBase;
                    key.Click += OnKeyClick;
                    key.FontSize = 14;
                    key.FontWeight = FontWeights.Bold;
                    key.Margin = new Thickness(3);
                    key.Foreground = Brushes.Black;
                    key.Background = Brushes.Gray;
                    key.BorderThickness = new Thickness(3);

                    if (key.Content == null)
                    {
                        key.Content = ((char)GetKey(key).KeyCode).ToString().ToLower();
                    }

                }
                else
                {
                    ComboBox languageBox = item as ComboBox;
                    languageBox.Margin = new Thickness(3);
                    languageBox.Foreground = Brushes.Black;
                    languageBox.FontSize = 11;
                    languageBox.HorizontalContentAlignment = HorizontalAlignment.Center;
                    languageBox.VerticalContentAlignment = VerticalAlignment.Center;
                    languageBox.FontWeight = FontWeight = FontWeights.Bold;
                    languageBox.SelectionChanged += OnLanguageSelectionChanged;
                }
            }
        }

        protected void OnLanguageSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var languageBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)languageBox.SelectedItem;

            LanguageData info = (LanguageData)selectedItem.Content;

            CultureInfo languageInfo = new CultureInfo(info.Number);

            ActivateKeyboardLayout((IntPtr)languageInfo.KeyboardLayoutId, KLF_SETFORPROCESS);

            foreach (var item in _itemsControl.Items)
            {
                if (item is ButtonBase)
                {
                    ButtonBase key = item as ButtonBase;
                    SetContent(key);
                }
            }
        }

        private string GetSpecificKeyName(string content)
        {
            if (IsShift)
            {
                content = content.ToUpper();
            }

            return content;
        }

        private void SetContent(ButtonBase key)
        {
            VKeyCode symbol = (VKeyCode)GetKey(key).KeyCode;

            switch (symbol)
            {
                case VKeyCode.Back:
                    key.Content = GetSpecificKeyName("back");
                    break;
                case VKeyCode.Tab:
                    key.Content = GetSpecificKeyName("tab");
                    break;
                case VKeyCode.Return:
                    key.Content = GetSpecificKeyName("enter");
                    break;
                case VKeyCode.Shift:
                    key.Content = GetSpecificKeyName("shift");
                    break;
                case VKeyCode.Left:
                    key.Content = "<";
                    break;
                case VKeyCode.Right:
                    key.Content = ">";
                    break;
                case VKeyCode.Space:
                    key.Content = key.Content = GetSpecificKeyName("space");
                    break;
                case VKeyCode.Delete:
                    key.Content = "&123";
                    break;
                case VKeyCode.Numpad0:
                    key.Content = "0";
                    break;
                case VKeyCode.Numpad1:
                    key.Content = "1";
                    break;
                case VKeyCode.Numpad2:
                    key.Content = "2";
                    break;
                case VKeyCode.Numpad3:
                    key.Content = "3";
                    break;
                case VKeyCode.Numpad4:
                    key.Content = "4";
                    break;
                case VKeyCode.Numpad5:
                    key.Content = "5";
                    break;
                case VKeyCode.Numpad6:
                    key.Content = "6";
                    break;
                case VKeyCode.Numpad7:
                    key.Content = "7";
                    break;
                case VKeyCode.Numpad8:
                    key.Content = "8";
                    break;
                case VKeyCode.Numpad9:
                    key.Content = "9";
                    break;
                case VKeyCode.Control:
                    key.Content = "&123";
                    break;
                default:
                    key.Content = GetSymbolForKey(symbol, IsShift, false);
                    break;
            }
        }

        public void SendKeyInfo(ushort scan)
        {
            INPUT[] Inputs = new INPUT[1];
            INPUT Input = new INPUT();
            Input.type = 1;
            Input.U.ki.wScan = scan;
            Input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
            Inputs[0] = Input;
            uint result = SendInput(1, Inputs, INPUT.Size);
        }

        protected void OnKeyClick(object sender, RoutedEventArgs e)
        {
            var button = (ButtonBase)sender;

            uint tag = GetKey(button).KeyCode;
            int scanCode;

            scanCode = MapVirtualKey(tag, MAPVK_VK_TO_VSC);

            if ((VKeyCode)tag == VKeyCode.Shift)
            {
                ClickShift((VKeyCode)tag);
            }
            else
            {
                ClickButton((VKeyCode)tag);

            }
        }

        private void ClickShift(VKeyCode tag)
        {
            IsShift = !IsShift;
            ChangeSymbols();
            INPUT[] Inputs = new INPUT[2];
            Inputs[0] = new INPUT();
            Inputs[0].type = 1;
            Inputs[0].U.ki.wVk = tag;
            if (IsShift)
            {
                Inputs[0].U.ki.dwFlags = KEYEVENTF.KEYDOWN;

            }
            else
            {
                Inputs[0].U.ki.dwFlags = KEYEVENTF.KEYUP;
            }

            Inputs[1] = new INPUT();
            Inputs[1].type = 1;
            Inputs[1].U.ki.dwFlags = KEYEVENTF.KEYUP;

            uint result = SendInput(2, Inputs, INPUT.Size);
        }

        private void ChangeSymbols()
        {
            foreach (var item in _itemsControl.Items)
            {
                if (item is ButtonBase)
                {
                    var key = item as ButtonBase;

                    SetContent(key);
                }
            }
        }

        private void ClickButton(VKeyCode tag)
        {
            INPUT[] Inputs = new INPUT[1];
            INPUT Input = new INPUT();
            Input.type = 1;
            Input.U.ki.wVk = (VKeyCode)tag;
            Input.U.ki.dwFlags = KEYEVENTF.KEYDOWN;
            Inputs[0] = Input;
            uint result = SendInput(1, Inputs, INPUT.Size);
        }

        public static KeyData GetKey(DependencyObject obj)
        {
            return (KeyData)obj.GetValue(KeyProperty);
        }

        public static void SetKey(DependencyObject obj, KeyData value)
        {
            obj.SetValue(KeyProperty, value);
        }

        public static readonly DependencyProperty KeyProperty =
            DependencyProperty.RegisterAttached("Key", typeof(KeyData), typeof(VirtualKeyboard));


        public UIElement GetKeyInfo(UIElement buttonKey, double widthFactor, VKeyCode keyName, int rowNumber)
        {
            buttonKey.Focusable = false;
            InputKeyInfo(buttonKey, widthFactor, keyName, rowNumber);

            return buttonKey;
        }

        protected void InputKeyInfo(UIElement buttonKey, double widthFactor, VKeyCode keyName, int rowNumber)
        {
            KeyData keyInfo = new KeyData();

            keyInfo.WidthFactor = widthFactor;
            keyInfo.KeyCode = (ushort)keyName;
            keyInfo.RowNumber = rowNumber;

            SetKey(buttonKey, keyInfo);
        }

        public string GetSymbolForKey(VKeyCode keys, bool isShift, bool isAltGr)
        {
            StringBuilder buf = new StringBuilder(256);
            byte[] keyboardState = new byte[256];
            if (isShift)
            {
                keyboardState[(int)VKeyCode.Shift] = 0xff;
            }

            if (isAltGr)
            {
                keyboardState[(int)VKeyCode.Control] = 0xff;
                keyboardState[(int)VKeyCode.Menu] = 0xff;
            }

            ushort lang = GetKeyboardLayout(GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero));
            CultureInfo languageInfo = new CultureInfo(lang);

            ToUnicodeEx((uint)keys, 0, keyboardState, buf, 256, 0, (IntPtr)languageInfo.KeyboardLayoutId);
            return buf.ToString();
        }

        public List<ComboBoxItem> GetLanguage()
        {
            List<ComboBoxItem> keyboardLanguages = new List<ComboBoxItem>();

            uint nElements = GetKeyboardLayoutList(0, null);
            IntPtr[] keyboardsIds = new IntPtr[nElements];
            GetKeyboardLayoutList(keyboardsIds.Length, keyboardsIds);

            foreach (var keyboardId in keyboardsIds)
            {
                var languageId = (ushort)((uint)keyboardId & 0xFFFF);

                CultureInfo languageInfo = new CultureInfo(languageId, false);

                ComboBoxItem comboBoxItem = new ComboBoxItem();
                LanguageData data = new LanguageData();
                data.Name = languageInfo.ThreeLetterWindowsLanguageName;
                data.Number = languageId; ;
                comboBoxItem.Content = data;

                keyboardLanguages.Add(comboBoxItem);
            }

            return keyboardLanguages;
        }
    }
}
