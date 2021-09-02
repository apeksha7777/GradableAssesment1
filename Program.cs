using System;
using System.IO;
using System.Collections.Generic;

namespace TeacherStoreRetrieveUpdate
{
    class Teacher
    {
        string id;
        string name;
        string tClass;
        string section;

        public void perform()
        {


            displayRecord();
            while (true)
            {

                Console.WriteLine("\n1.Add teacher record");
                Console.WriteLine("2.Update teacher record");
                Console.WriteLine("3.Exit");
                Console.Write("Enter choice: ");
                int ch = int.Parse(Console.ReadLine());
                if(ch==3)
                {
                    break;
                }

                switch (ch)
                {
                    case 1:
                        {
                            addRecord();
                            break;
                        }
                    case 2:
                        {
                            updateRecord();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("incorrect choice");
                            break;
                        }
                }

            }
           

        }

        void displayRecord()
        {
            string strdata = File.ReadAllText(@"D:\teacher.txt");
            if (strdata != "")
            {
                string[] rowdata = strdata.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine("\n-----------teacher details-----------");


                foreach (string trecord in rowdata)
                {


                    string[] splitdata = trecord.Split('|');


                    Console.Write("\n ID:" + splitdata[0] + "    ");
                    Console.Write("name:" + splitdata[1] + "    ");
                    Console.Write("class:" + splitdata[2] + "    ");
                    Console.Write("section:" + splitdata[3] + "\n");


                }
            }
            else
            {
                Console.WriteLine("--------file empty------");
            }
        }

        void addRecord()
        {

            FileStream fs = new FileStream("D:\\teacher.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            Console.WriteLine("---Enter teacher details---");
           
            Console.Write("\nTeacher ID:");
            string tID = Console.ReadLine();
            Console.Write("Teacher Name:");
            string tName = Console.ReadLine();
            Console.Write("Teacher class:");
            string tClass = Console.ReadLine();
            Console.Write("Teacher section:");
            string tSection = Console.ReadLine();

            string str = tID + "|" + tName + "|" + tClass + "|" + tSection;
            sw.WriteLine(str);

            Console.Write("\nTeacher added successfully.\n");
               

            
            sw.Flush();
            sw.Close();
            displayRecord();



        }
        void updateRecord()
        {
            string strdata = File.ReadAllText(@"D:\teacher.txt");

            string[] rowdata = strdata.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
           
            List<Teacher> tlist = new List<Teacher>();
            foreach (string trecord in rowdata)
            {

                Teacher tobj = new Teacher();
                string[] splitdata = trecord.Split('|');
                tobj.id = splitdata[0];
                tobj.name = splitdata[1];
                tobj.tClass = splitdata[2];
                tobj.section = splitdata[3];
                tlist.Add(tobj);


            }
            FileStream fs = new FileStream("D:\\teacher.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            Console.Write("enter teacher id to update record: ");
            string updateRecordId = Console.ReadLine();
          

            int flag = 0;

            foreach (var record in tlist)
            {

                if (updateRecordId == record.id)
                {
                    Console.Write("\nEnter new id: ");
                    string newId = Console.ReadLine();
                    Console.Write("Enter new name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Enter new class: ");
                    string newClass = Console.ReadLine();
                    Console.Write("Enter new section: ");
                    string newSec = Console.ReadLine();

                    record.id = newId;
                    record.name = newName;
                    record.tClass = newClass;
                    record.section = newSec;
                    flag = 1;
                }
                string str = record.id + "|" + record.name + "|" + record.tClass + "|" + record.section;
                sw.WriteLine(str);
               

            }
            sw.Flush();
            sw.Close();
            if (flag==0)
            {
                Console.Write("No record found!!\n");
            }
            else
            {
                Console.Write("\nTeacher updated successfully.");
                displayRecord();
            }


            
           

        }
        static void Main(string[] args)
        {

            Teacher p = new Teacher();
            p.perform();

        }
    }
}
