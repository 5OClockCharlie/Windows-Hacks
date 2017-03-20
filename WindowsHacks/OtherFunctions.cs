using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsAPI;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace WindowsHacks
{
    class OtherFunctions
    {


        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hwnd, int index);
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hwnd, int index, int newstyle);
        public static void ShakeMouse()
        {
            Random r = new Random();
            int offset = 20;

            while (true)
            {
                int currentX = Cursor.Position.X;
                int currentY = Cursor.Position.Y;
                int x = r.Next(currentX - offset, currentX + offset + 1);
                int y = r.Next(currentY - offset, currentY + offset + 1);
                Mouse.Move(x, y);
                System.Threading.Thread.Sleep(10);
            }

        }

        public static void WindowShaker()
        {
            IntPtr hWnd = GetWindowHandlePtr();
            Random r = new Random();
            for (int i = 0; i < 1000; i++)
            {
                int offset = 2;
                int currentX = Window.GetLocation(hWnd).X;
                int currentY = Window.GetLocation(hWnd).Y;
                int x = r.Next(currentX - offset, currentX + offset + 1);
                int y = r.Next(currentY - offset, currentY + offset + 1);
                Window.Move(hWnd, x, y);
                System.Threading.Thread.Sleep(10);
            }
        }

        public static void WindowShakerExtreme()
        {
            IntPtr hWnd = GetWindowHandlePtr();
            Random r = new Random();
            for (int i = 0; i < 1000; i++)
            {
                int x = r.Next(0, Desktop.GetWidth());
                int y = r.Next(0, Desktop.GetHeight());
                Window.Move(hWnd, x, y);
                System.Threading.Thread.Sleep(10);
            }
        }
        public static void SetTitle()
        {
            IntPtr hWnd = GetWindowHandlePtr();
            Console.Write("New Title: ");
            Window.SetTitle(hWnd, Console.ReadLine());
        }

        public static void ResizeBorders()
        {
            IntPtr hWnd = GetWindowHandlePtr();

            Console.Write("New Width: ");
            int width = 0;
            bool inputIsInt = int.TryParse(Console.ReadLine(), out width);
            if (!inputIsInt || width < 0)
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            Console.Write("New Height: ");
            int height = 0;
            inputIsInt = int.TryParse(Console.ReadLine(), out height);
            if (!inputIsInt || height < 0)
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            Window.Resize(hWnd, width, height);
        }

        public static void MouseTransparency()
        {
            IntPtr hWnd = GetWindowHandlePtr();
            Window.EnableMouseTransparency(hWnd);
        }

        public static void Hide()
        {
            IntPtr hWnd = GetWindowHandlePtr();
            Window.Hide(hWnd);
        }

        public static void Show()
        {
            IntPtr hWnd = GetWindowHandlePtr();
            Window.Show(hWnd);
        }

        public static void RemoveMenu()
        {
            IntPtr hWnd = GetWindowHandlePtr();
            Window.RemoveMenu(hWnd);
        }

        public static void DisableClose()
        {
            IntPtr hWnd = GetWindowHandlePtr();
            Window.DisableCloseButton(hWnd);
        }

        public static void DisableMaximize()
        {
            IntPtr hWnd = GetWindowHandlePtr();
            Window.DisableMaximizeButton(hWnd);
        }

        public static void DisableMinimize()
        {
            IntPtr hWnd = GetWindowHandlePtr();
            Window.DisableMinimizeButton(hWnd);
        }

        public static IntPtr GetWindowHandlePtr()
        {
            Console.WriteLine("Select a window within 2 seconds:");
            System.Threading.Thread.Sleep(2000);
            var ptr = Window.GetFocused();
            var windowName = Window.GetTitle(ptr);
            Console.WriteLine($"You've selected '{windowName}'");
            Console.WriteLine($"Type 'Y' to proceed or 'N' to retry, default is 'Y':");

            var response = Console.ReadLine();
            if (response.ToLower().Contains("n"))
                ptr = GetWindowHandlePtr();

            return ptr;
        }

    }
}
