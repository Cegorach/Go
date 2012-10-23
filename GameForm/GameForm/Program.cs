using System;
using System.Windows.Forms;

namespace GameForm
{
    static class Program
    {
        private static xWindow _xW;

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _xW = new xWindow();
            _xW.Show();

            _xW._x2D.Run();
        }
    }
}

