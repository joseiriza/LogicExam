using System;
using System.Collections.Generic;
using System.Collections;

namespace LogicExam
{
    class Program
    {
        static void Main(string[] args)
        {
            //--------------------------------------INPUTS---------------------------------------------------------------
            string inputMessage1 = "we the people of the united states in order to form a more perfect union etc";
            string inputMessage2 = "cheating is not allowed";
            string inputMessage3 = "the rocks";
            //----------------------------------------------------------------------------------------------------------
            encodeMessage(inputMessage1);
            encodeMessage(inputMessage2);
            encodeMessage(inputMessage3);
        }

        static void encodeMessage(string inputMessage)
        {
            string inputCharacterNoSpaces = inputMessage.Replace(" ", ""); // removing spaces
            int L = inputCharacterNoSpaces.Length; // computing L
            double sqrtL = Math.Sqrt(L); // sqrt(L) to fullfil main requirement
            int columns = Convert.ToInt32(Math.Ceiling(sqrtL));
            int rows = Convert.ToInt32(Math.Floor(sqrtL)); // since row can not be greater than column: floor value is assigned, then it might change
            if (columns * rows < L) // taking smallest area condition is checked
            {
                rows += 1;
            }
            List<List<string>> table = buildTable(columns, rows, L, inputCharacterNoSpaces);
            string message = buildMessageFromTable(columns, rows, L, table);
            printTable(table);
            Console.WriteLine(message);
            Console.WriteLine();
        }

        static List<List<string>> buildTable(int columns, int rows, int L, string inputCharacterNoSpaces)
        {
            int columnToWrite = 0;
            int rowToWrite = 1; // starting to count from 1
            List<string> rowToInsert = new List<string>();
            List<List<string>> table = new List<List<string>>(); //a table con be show as a list of list, other data structures might be considered
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

        static void printTable(List<List<string>> table)
        {
            string rowToPrint = "";
            foreach (List<string> row in table)
            {
                foreach (string c in row)
                {
                    rowToPrint = rowToPrint.Insert(rowToPrint.Length, c);
                }
                Console.WriteLine(rowToPrint);
                rowToPrint = "";
            }
            Console.WriteLine();
        }
    }
}
