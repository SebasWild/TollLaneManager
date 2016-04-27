using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderName = @"c:\Temp";
            string pathString = System.IO.Path.Combine(folderName, "SubFolder");
         

            String fileName = "test2.txt";  //TODO add transaction number here
            System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\TEMP\\" + fileName, true);
            file.WriteLine("Plate Number");
            file.WriteLine("Transaction Number: "); //TODO add transaction number here
            file.WriteLine("Toll Amount: ");
            file.Close();
        }
    }
}
