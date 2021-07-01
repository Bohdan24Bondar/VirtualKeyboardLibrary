using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualKeyboardLibrary
{
    public class KeyData
    {
        public ushort KeyCode { get; set; }

        public double WidthFactor { get; set; }

        public int RowNumber { get; set; }
    }
}
