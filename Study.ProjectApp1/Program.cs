using Microsoft.Extensions.DependencyInjection;

using Study.Core;
using Study.Core.Contexts;

namespace Study.ProjectApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            StudyContext.DbPath = CommonHelper.GetDbPath();

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}