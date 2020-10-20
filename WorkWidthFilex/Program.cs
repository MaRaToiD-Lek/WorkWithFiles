using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tИзначальная форма");

            string path = @"D:\Task\text.txt";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            string pathOriginalFile = @"D:\Task\text.txt";
            string pathNewFile = @"D:\Task\textNew.txt";
            string newString = string.Empty;
            List<Client> models = new List<Client>();
            using (StreamReader sr = new StreamReader(pathOriginalFile, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // разделение по опредеоенному символу
                    var splitLines = line.Split(';');
                    // создание модели клиент из текстового файла
                    models.Add(new Client() { ID = splitLines[0], PassportNumber = splitLines[1], Payment = splitLines[2] });
                }
            }
            using (StreamWriter fstream = new StreamWriter(pathNewFile)) // создание нового файла и запись в него
            {
                //"\r\n" это переход на новую строку
                for (int i = 0; i < models.Count; i++)
                {
                    models[i].ID = i.ToString();// изменение первоначальных данных                    
                    //models[i].PassportNumber = "AZE75320115"; // изменение первоначальных данных
                    models[i].Payment = ((i + 1) * 12).ToString();// изменение первоначальных данных
                    newString += models[i].ID + "; " + models[i].PassportNumber + "; " + models[i].Payment + "\r\n"; // создание строки с измен данными
                }
            }
            File.WriteAllText(pathNewFile, newString); // запись в новый файл

            Console.WriteLine("\n\tФорма после изменения");

            string path2 = @"D:\Task\textNew.txt";
            using (StreamReader sr = new StreamReader(path2, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            Console.ReadKey();
        }
    }
}