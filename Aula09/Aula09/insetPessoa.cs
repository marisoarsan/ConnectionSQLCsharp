using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Aula09
{
    public class insetPessoa
    {
        public void Execute()
        {
            Console.WriteLine("Entre com o nome: ");
            var input = Console.ReadLine();

            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mariana.dsantos\source\repos\Aula09\Aula09\data.mdf;Integrated Security=True;Connect Timeout=30";

            var cmdText = @"INSERT INTO Pessoa
			                            (Nome)
                            VALUES (@pessoaNome);";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection))
            {
                sqlCommand.CommandType = System.Data.CommandType.Text;

                sqlCommand.Parameters.Add(@"pessoaNome", System.Data.SqlDbType.VarChar).Value = input;

                sqlConnection.Open();

                var resultScalar = sqlCommand.ExecuteScalar();

            }
        }
    }
  
}
