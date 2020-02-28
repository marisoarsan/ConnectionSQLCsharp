using System;
using System.Data;
using System.Data.SqlClient;

namespace Aula09
{
    class Program
    {
        static void Main(string[] args)
        {
            var insertPessoa = new insetPessoa();
            insertPessoa.Execute();

            var ReadPessoa = new ReadPessoa();
            ReadPessoa.Execute();

        }  
    }
}
