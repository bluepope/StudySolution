using Microsoft.Extensions.DependencyInjection;

using Study.Core.Contexts;
using Study.ProjectApp1.Commons;

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