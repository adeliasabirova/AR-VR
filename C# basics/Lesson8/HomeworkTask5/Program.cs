using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
//Аделя Сабирова
namespace HomeworkTask5
{
    class Program
    {
        //Конвертер информации из csv файла в xml
        static void Converter(string fileNameOpen, string fileNameSave)
        {
            string[] lines = File.ReadAllLines(fileNameOpen);
            string[] headers = { 
                                    "Name", 
                                    "Surname", 
                                    "University", 
                                    "Faculty", 
                                    "Department", 
                                    "Age", 
                                    "Course", 
                                    "Group", 
                                    "City" 
                                };
            var xml = new XElement("Students", lines.Select(line => 
                      new XElement("StudentInfo", line.Split(';').Select((column, index) => 
                      new XElement(headers[index], column)))));
            xml.Save(fileNameSave);
        }
        static void Task5()
        {
            Converter("..\\..\\Task5.csv", "..\\..\\Task5.xml");
        }
        /// <summary>
        /// **Написать программу-преобразователь из CSV в XML-файл с информацией о студентах (6 урок).
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Task5();
        }
    }
}
