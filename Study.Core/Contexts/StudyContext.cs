using Microsoft.EntityFrameworkCore;

using Study.Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Study.Core.Contexts
{
    public class StudyContext : DbContext
    {
        public static string? DbPath { get; set; }
        
        #region Db Entity 
        public DbSet<StudyPersonEntity>? StudyPersons { get; set; }
        
        #endregion

        public StudyContext()
        {
            //System.IO.Directory.GetCurrentDirectory;
            //실행 위치
            //Study.exe 실행하면 실행한 위치
            //c:\bbb> C:\aaa\Study.exe 실행하면, 현재 실행한 위치인 c:\bbb 반환

            //실행파일의 위치
            //AppDomain.CurrentDomain.BaseDirectory;
            //c:\bbb> C:\aaa\Study.exe 실행하면, 현재 실행한 위치인 c:\aaa 반환

            //            this.DbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", "study.db");

            //            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(this.DbPath));


            //크로스플랫폼 때문에
            //System.IO.Path.DirectorySeparatorChar // 윈도우에서는 \, 리눅스에서는 /
            //Environment.NewLine //윈도우에서는 \r\n, 리눅스에서는 \n
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
