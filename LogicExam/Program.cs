using System;
using System.Collections.Generic;
using System.Collections;

namespace LogicExam
{
    class Program
    {
        static void Main(string[] args)
        {
            //--------------------------------------INPUT---------------------------------------------------------------
            string inputCharacter1 = "we the people of the united states in order to form a more perfect union etc";
            string inputCharacter2 = "cheating is not allowed";
            string inputCharacter3 = "the rocks";

            //----------------------------------------------------------------------------------------------------------
            encodeMessage(inputCharacter1);
            encodeMessage(inputCharacter2);
            encodeMessage(inputCharacter3);
        }

        static void encodeMessage(string inputMessage) {
            string inputCharacterNoSpaces = inputMessage.Replace(" ", ""); // removing spaces
            int L = inputCharacterNoSpaces.Length; // computing L
            double sqrtL = Math.Sqrt(L); // sqrt(L) to fullfil main requirement
            int columns = Convert.ToInt32(Math.Ceiling(sqrtL));
            int rows = Convert.ToInt32(Math.Floor(sqrtL)); // since row can not be greated than column floor value is assigned, then it might change when building table
            if (columns * rows < L)
            {
                rows += 1;
            }
            List<List<string>> table = buildTable(columns, rows, L, inputCharacterNoSpaces);
            string message = buildMessageFromTable(columns, rows, L, table);
            Console.WriteLine(message);
        }

        static List<List<string>> buildTable(int columns, int rows, int L, string inputCharacterNoSpaces)
        {
            int columnToWrite = 0;
            int rowToWrite = 1; // starting to count from 1
            List<string> rowToInsert = new List<string>();
            List<List<string>> table = new List<List<string>>();
            foreach (char c in inputCharacterNoSpaces)
            {
                rowToInsert.Add(c.ToString());
                columnToWrite += 1;
                if (columnToWrite == columns || ((columnToWrite == columns - columns * rows + L)) && rowToWrite == rows)
                {
                    table.Add(new List<string>(rowToInsert));
                    rowToInsert.Clear();
                    columnToWrite = 0;
                    rowToWrite += 1;
                }
            }
            return table;
        }
        static string buildMessageFromTable(int columns, int rows, int L, List<List<string>> table)
        {
            string message = "";

            for (int j = 0; j < columns; j++) //iteration throuhg table columns
            {
                if (j != 0)
                { // inserts white space when needed
                    message = message.Insert(message.Length, " ");
                }

                for (int i = 0; i < rows; i++)  //iteration through table rows
                {
                    if ((j + 1 > columns - columns * rows + L) && i + 1 == rows) // break loop before exception
                    {
                        break;
                    }
                    message = message.Insert(message.Length, table[i][j]);
                }
            }
            return message;
        }
    }

}
