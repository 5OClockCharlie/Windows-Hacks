using System;
using WindowsAPI;
using System.Windows.Forms;

namespace WindowsHacks
{
    class VerticalMirror
    {
        private const int GWL_EXSTYLE = (-20);
        private const int WS_EX_LAYOUTRTL = (int)0x00400000L;
        private static int extendedStyle = 0;
        public static void Run()
        {
            string windowTitle = OtherFunctions.GetWindowTitle();
            IntPtr hWnd = Window.Get(windowTitle);
            FlipLeft(hWnd);
            Console.ReadLine();
            FlipRight(hWnd);
            Application.Run();
        }
        public static void FlipLeft(IntPtr hWnd)
        {
            extendedStyle = OtherFunctions.GetWindowLong(hWnd, GWL_EXSTYLE);
            OtherFunctions.SetWindowLong(hWnd, GWL_EXSTYLE, extendedStyle | WS_EX_LAYOUTRTL);
        }

        public static void FlipRight(IntPtr hWnd)
        {
            OtherFunctions.SetWindowLong(hWnd, GWL_EXSTYLE, extendedStyle);
        }
    }
}
