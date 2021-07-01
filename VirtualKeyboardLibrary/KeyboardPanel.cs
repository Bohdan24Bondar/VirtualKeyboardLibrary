using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace VirtualKeyboardLibrary
{
    public class KeyboardPanel : Panel
    {
        #region Consts

        public const int KEYS_ROWS_COUNT = 4;

        #endregion

        static KeyboardPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(KeyboardPanel), new FrameworkPropertyMetadata(typeof(KeyboardPanel)));
        }

        public double KeyHeight
        {
            get { return (double)GetValue(KeyHeightProperty); }
            set { SetValue(KeyHeightProperty, value); }
        }

        public static readonly DependencyProperty KeyHeightProperty =
            DependencyProperty.Register(nameof(KeyHeight), typeof(double), typeof(KeyboardPanel));

        public double KeyWidth
        {
            get { return (double)GetValue(KeyWidthProperty); }
            set { SetValue(KeyWidthProperty, value); }
        }

        public static readonly DependencyProperty KeyWidthProperty =
            DependencyProperty.Register(nameof(KeyWidth), typeof(double), typeof(KeyboardPanel));

        public Thickness KeyMargin
        {
            get { return (Thickness)GetValue(KeyMarginProperty); }
            set { SetValue(KeyMarginProperty, value); }
        }

        public static readonly DependencyProperty KeyMarginProperty =
            DependencyProperty.Register("KeyMargin", typeof(Thickness), typeof(KeyboardPanel));


        private int CalculateTheWidestRow()
        {
            int theWidestRow = 0;
            int width = 0;
            int currentRow = 0;

            foreach (UIElement child in InternalChildren)
            {
                int keyRow = VirtualKeyboard.GetKey(child).RowNumber;

                if (currentRow < keyRow)
                {
                    if (theWidestRow < width)
                    {
                        theWidestRow = width;
                    }

                    width = 0;
                    currentRow = keyRow;
                }
                width++;
            }

            return theWidestRow;
        }


        protected override Size MeasureOverride(Size constraint)
        {
            int countInRow = CalculateTheWidestRow();
            KeyWidth = (constraint.Width - KeyMargin.Left * (countInRow + 1)) / countInRow;
            KeyHeight = (constraint.Height - KeyMargin.Top * (KEYS_ROWS_COUNT + 1)) / KEYS_ROWS_COUNT;

            foreach (UIElement child in InternalChildren)
            {
                if (child is ButtonBase)
                {
                    double widthFactor = VirtualKeyboard.GetKey(child).WidthFactor;
                    double keyWidth = (widthFactor * KeyWidth) + (widthFactor * KeyMargin.Left) - (1 * KeyMargin.Left);

                    Size childSize = new Size(keyWidth, KeyHeight);
                    child.Measure(childSize);
                }

            }
            return base.MeasureOverride(constraint);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            double x = KeyMargin.Left;
            double y = KeyMargin.Top;

            int index = 0;

            foreach (UIElement child in InternalChildren)
            {
                int row = VirtualKeyboard.GetKey(child).RowNumber;

                if (index < row)
                {
                    x = KeyMargin.Left;
                    y += KeyHeight + KeyMargin.Top;
                    index = row;
                }

                double widthFactor = VirtualKeyboard.GetKey(child).WidthFactor;
                double keyWidth = (widthFactor * KeyWidth) + (widthFactor * KeyMargin.Left) - (1 * KeyMargin.Left);
                child.Arrange(new Rect(x, y, keyWidth, KeyHeight));
                x += KeyWidth * widthFactor + KeyMargin.Left + (widthFactor * KeyMargin.Left) - (1 * KeyMargin.Left);

            }

            return base.ArrangeOverride(finalSize);
        }
    }
}
