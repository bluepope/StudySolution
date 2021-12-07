using Microsoft.Data.SqlClient;

using Study.DatabaseTest.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.DatabaseTest.DbClass
{
    internal class DapperTest
    {
        public void Test(string connectionString, string searchText)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); //연결 됐다
                string sql = @$"
SELECT
	Col1
    ,Col2
FROM
	tblSample WITH(NOLOCK)
WHERE
    Col2 LIKE '%' + @searchText + '%'
";
                //DynamicParameters dynamicParameters = new DynamicParameters(); 
                //dynamicParameters.Add("", "test", DbType.String, ParameterDirection.)

                var list = Dapper.SqlMapper.Query<SampleModel>(connection, sql, new
                {
                    searchText = "테스트"
                });

                foreach (var item in list)
                {
                    Console.WriteLine($"{item.Col1} - {item.Col2}");
                }

                //Dapper를 통한 Update
                sql = @$"
        UPDATE tblSample
        SET
            Col2 = @Col2
        WHERE
            Col1  = @Col1
        ";

                var item1 = list.FirstOrDefault();
                if (item1 != null)
                {
                    item1.Col2 = "Dapper로 변경";

                    int r = Dapper.SqlMapper.Execute(connection, sql, item1);
                }
            }

        }
    }
}
