using MyNotebook.Forms;
using System;
using System.Threading;
using System.Windows.Forms;

namespace MyNotebook
{
    static class Program
    {
        // держим в переменной, чтобы сохранить владение им до конца пробега программы
        static Mutex InstanceCheckMutex;
        static bool InstanceCheck()
        {
            bool isNew;
            InstanceCheckMutex = new Mutex(true, "myNotebook", out isNew);
            return isNew;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!InstanceCheck())
            {
                MessageBox.Show("Копия программы уже запущена", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SelectStartType());
        }
    }
}
