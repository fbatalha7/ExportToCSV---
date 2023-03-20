using System;
using System.IO;
using System.Text;

namespace export
{
    internal class Program : Model.CL_data
    {

        public static void CreateFile(string caminho, StringBuilder dt)
        {
            string[] lines = dt.ToString().Split(Environment.NewLine.ToCharArray());
            File.WriteAllLines(caminho, lines);

        }


        static void Main(string[] args)
        {
            //caminhos dos arquivos
            string way = @"C:\Users\felip\Documents\csv";
            string arq = way + "\\" + "TesteCSV.csv";

            try
            {
                Console.WriteLine("verificando...");

                if (Directory.Exists(way))
                {
                   

                    if (Directory.Exists(arq))
                    {
                       Directory.Delete(arq, true);

                        CreateFile(arq, DataUsed);

                    }
                    else
                    {
                        CreateFile(arq, DataUsed);
                    }

                    return;



                }
                else{

                    Directory.CreateDirectory(way);
                    CreateFile(arq, DataUsed);
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("erro" + e.Message);
            }

        }





    }



}

