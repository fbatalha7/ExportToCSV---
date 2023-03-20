using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace export.Model
{
    public class CL_data
    {
        public static DataTable dtalunos()
        {
            var dtb_Alunos = new DataTable();
            dtb_Alunos.Columns.Add("AlunoId", typeof(int));
            dtb_Alunos.Columns.Add("Nome", typeof(string));
            dtb_Alunos.Columns.Add("Email", typeof(string));
            dtb_Alunos.Columns.Add("Telefone", typeof(string));
            dtb_Alunos.Columns.Add("Idade", typeof(int));

            dtb_Alunos.Rows.Add(1, "Teste", "teste@yahoo.com", "44669922", 45);
            dtb_Alunos.Rows.Add(2, "Jefferson", "jeff@bol.com.br", "88669977", 23);
            dtb_Alunos.Rows.Add(3, "Janice", "janjan@uol.com.br", "96885522", 20);
            dtb_Alunos.Rows.Add(4, "Jessica", "jessicalang@uol.com.br", "96885522", 25);
            dtb_Alunos.Rows.Add(5, "Miriam", "mimi@uol.com.br", "96885522", 48);

            dtb_Alunos.Rows.Add(11, "Marcio", "marcio@yahoo.com", "54669922", 35);
            dtb_Alunos.Rows.Add(12, "Joao", "joao@bol.com.br", "58669977", 21);
            dtb_Alunos.Rows.Add(13, "Janio", "janio@uol.com.br", "36885522", 30);
            dtb_Alunos.Rows.Add(14, "Jessi", "jessi@uol.com.br", "16885522", 24);
            dtb_Alunos.Rows.Add(15, "Maria", "maria@uol.com.br", "16885522", 58);

            return dtb_Alunos;
        }

        public static StringBuilder DataUsed { get => ConvertDataTableToCsvFile(dtalunos()); }
        public static StringBuilder ConvertDataTableToCsvFile(DataTable dtData)
        {
            try
            {
                StringBuilder data = new StringBuilder();

                //Obter Nome das Colunas
                for (int column = 0; column < dtData.Columns.Count; column++)
                {
                    //Fazer com que no final da linha nao tennha o delimitador ;
                    if (column == dtData.Columns.Count - 1)
                        data.Append(dtData.Columns[column].ColumnName.ToString().Replace(";", ","));
                    else
                        data.Append(dtData.Columns[column].ColumnName.ToString().Replace(";", ",") + ';');
                }

                data.Append(Environment.NewLine);

                for (int row = 0; row < dtData.Rows.Count; row++)
                {
                    for (int column = 0; column < dtData.Columns.Count; column++)
                    {
                        ////Fazer com que no final da linha nao tennha o delimitador ; e tambem chega de no valor do campo contem ";" substituindo por ","
                        if (column == dtData.Columns.Count - 1)
                            data.Append(dtData.Rows[row][column].ToString().Replace(";", ","));
                        else
                            data.Append(dtData.Rows[row][column].ToString().Replace(";", ",") + ';');
                    }

                    // Fazer com que no final do dos dados nao crie uma nova linha.
                    if (row != dtData.Rows.Count - 1)
                        data.Append(Environment.NewLine);
                }
                return data;
            }
            catch (Exception e)
            {
                throw new Exception("ConvertDataTableToCsvFile: " + e.Message);
            }
        }
    }
}
