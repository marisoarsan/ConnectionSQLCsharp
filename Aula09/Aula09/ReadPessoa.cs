using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Aula09
{
    class ReadPessoa
    {
        public void Execute()
        {
            Console.WriteLine();
            Console.WriteLine("=======================");
            Console.WriteLine("Dados da Tabela Pessoa");

            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mariana.dsantos\source\repos\Aula09\Aula09\data.mdf;Integrated Security=True;Connect Timeout=30";

            var cmdText = @"SELECT Nome, ID FROM Pessoa";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection))
            {
                sqlCommand.CommandType = System.Data.CommandType.Text;

                sqlConnection.Open();

                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        var idColumnIndex = reader.GetOrdinal("ID");
                        var nomeColumnIndex = reader.GetOrdinal("Nome");

                        while (reader.Read())
                        {
                            var id = reader.GetFieldValue<int>(idColumnIndex);
                            var nome = reader.GetFieldValue<String>(nomeColumnIndex);

                            Console.WriteLine($"ID: {id}, Nome {nome}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Rows!");
                    }
                }
            }
        }
    }
}
