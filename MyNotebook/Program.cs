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
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;
            Application.Run(new FormSelectStartType());
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            string text = $"Во время выполнения программы возникла ошибка, пожалуйста сообщите об этом разработчику.\n\n{e.Exception.Message}\n\nStackTrace:\n{e.Exception.StackTrace}";
            MessageBox.Show(text, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }
    }
}
