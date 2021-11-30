
using Microsoft.Data.SqlClient;

using System.Data;

namespace Study.DatabaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=nas.hyunmo.net;Database=Test;User Id=test;Password=test1234;TrustServerCertificate=True";

            string searchText = "test";


            //1. ADO.NET 을 통한 Database 접근
            DataTable dt = new DataTable();

            //ConnectionPool 최소한으로 유지되므로 실제로 반복한다 하더라도 커넥션은 1개만 연결되어있음
            //for (int i = 0; i < 100; i++)
            //{
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); //연결 됐다

                SqlCommand command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = @$"
SELECT
	Col1
    ,Col2
FROM
	tblSample
WHERE
    Col2 LIKE '%' + @searchText + '%'
";
                command.Parameters.AddWithValue("@searchText", searchText);

                //SELECT
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                /*
                //INSERT UPDATE DELETE
                command.CommandText = @$"
UPDATE tblSample
SET
    Col2 = 'Test222'
WHERE
    Col1  = 1
";
                int r = command.ExecuteNonQuery();

                Console.WriteLine($"UPDATE가 적용된 행의 수: {r}");
                */
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

            //SP - Stored Procedure - 저장프로시저

            //2.Dapper -- Micro ORM
            //Connection 객체만
            //Parameter / Select 를 class 가지고 일부만 ORM 기능을 활용하겠다 라는 목적
            //Query 익숙한 세대에게 편함

            //3.EF - EF Core -- ORM  Code / DB First
            //DB 명령없이 C# 객체만 가지고 DB 를 활용할수 있도록
            //Query 사용하지 않음 --> 하지만 불필요한 쿼리가 생성될 수 있음
        }
    }
}