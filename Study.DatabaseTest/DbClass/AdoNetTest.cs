using Microsoft.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.DatabaseTest.DbClass
{
    internal class AdoNetTest
    {
        public void Test(string connectionString, string searchText)
        {
            //1. ADO.NET 을 통한 Database 접근
            DataTable dt = new DataTable();

            //ConnectionPool 최소한으로 유지되므로 실제로 반복한다 하더라도 커넥션은 1개만 연결되어있음
            //for (int i = 0; i < 100; i++)
            //{
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); //연결 됐다

                using (SqlTransaction tran = connection.BeginTransaction())
                {
                    try
                    {
                        SqlCommand command = connection.CreateCommand();
                        
                        //순수 쿼리
                        command.CommandType = CommandType.Text;
                        //SP - Stored Procedure - 저장프로시저
                        //command.CommandType = CommandType.StoredProcedure;

                        command.Transaction = tran;

                        command.CommandText = @$"
SELECT
	Col1
    ,Col2
FROM
	tblSample WITH(NOLOCK)
WHERE
    Col2 LIKE '%' + @searchText + '%'
";
                        command.Parameters.AddWithValue("@searchText", searchText);

                        //SELECT
                        SqlDataReader reader = command.ExecuteReader();
                        dt.Load(reader);

                        //INSERT UPDATE DELETE
                        command.CommandText = @$"
        UPDATE tblSample
        SET
            Col2 = @Col2
        WHERE
            Col1  = @Col1
        ";
                        command.Parameters.Clear();

                        dt.Rows[0]["Col2"] = "Datatable 변경";

                        command.Parameters.AddWithValue("Col1", dt.Rows[0]["Col1"]);
                        command.Parameters.AddWithValue("Col2", dt.Rows[0]["Col2"]);

                        int r = command.ExecuteNonQuery();

                        Console.WriteLine($"UPDATE가 적용된 행의 수: {r}");

                        tran.Commit();
                    }
                    catch// (Exception ex)
                    {
                        tran.Rollback();

                        throw;
                    }

                }

            }
            //}

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"{ row["Col1"]} - {row["Col2"]}");
            }


            //DataSet 은 DataTable 의 묶음
            /*
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            sqlDataAdapter.Fill(ds);

            Console.WriteLine(ds.Tables[0].Rows.Count);
            */
        }
    }
}
