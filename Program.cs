using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace FileStreamDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();

            // createFile();

            // readFileStream();
            // read();

            // textWriter();
            // textReader();

            // binaryWriter();
            // binaryReader();
            // StringWriter();
            // FileInfo();
            // DirectoryInfo();
            // Serializable();
            Deserialize();
        }

        /**
            序列化 和 反序列化 
         */
        public static void Serializable()
        {
            FileStream fileStream = new FileStream("file/test.txt", FileMode.OpenOrCreate);
            BinaryFormatter binary = new BinaryFormatter();
            Student student = new Student("xianSan", 100);
            binary.Serialize(fileStream, student);
            // fileStream.Close();
            Console.WriteLine("=================");
            fileStream.Close();
        }

        public static void Deserialize()
        {
            FileStream fileStream = new FileStream("file/test.txt", FileMode.OpenOrCreate);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Student s = (Student)binaryFormatter.Deserialize(fileStream);
            Console.WriteLine(s.name);
            Console.WriteLine(s.number);
            fileStream.Close();
        }

        


        //C# DirectoryInfo语法


        public static void DirectoryInfo()
        {
            DirectoryInfo directory = new DirectoryInfo("newdirectory");
            if (!directory.Exists)
            {
                directory.Create();
            }

            Console.WriteLine("CreationTime:" + directory.CreationTime);
            Console.WriteLine("CreationTimeUtc:" + directory.CreationTimeUtc);
            Console.WriteLine("FullName:" + directory.FullName);
            Console.WriteLine("LastAccessTime:" + directory.LastAccessTime);
            Console.WriteLine("LastAccessTimeUtc:" + directory.LastAccessTimeUtc);
            Console.WriteLine("Name:" + directory.Name);
            Console.WriteLine("Root:" + directory.Root);

            // directory.EnumerateDirectories();
            // directory.EnumerateFiles();
            // directory.GetDirectories();
            // directory.MoveTo("");
            // directory.Refresh();
            // directory.ToString();
            // directory.GetType();

            // directory.Delete();
        }


        /**
            FileStream 类有助于读取，写入和关闭文件  
         */

        public static void createFile()
        {
            FileStream fileStream = new FileStream("new sample.txt", FileMode.OpenOrCreate);
            for (int i = 65; i <= 90; i++)
            {
                fileStream.WriteByte((byte)i);
            }
            fileStream.Close();

        }


        public static void readFileStream()
        {
            FileStream F = new FileStream("sample.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(F);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
        /**
            StreamReader
         */
        public static void read()
        {
            StreamReader reader = new StreamReader("file/new sample.txt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }

        /**
            C# TextWriter类是一个抽象类。它用于将文本或连续的字符串写入文件。它在System.IO命名空间中定义。
         */

        public static void textWriter()
        {
            using (TextWriter writer = File.CreateText("TextWriter.txt"))
            {
                writer.WriteLineAsync("Hello World");
                writer.WriteLine("This is Test");
            }
            Console.WriteLine("Data written successfully...");
        }

        /**
            TextReader 
         */
        public static void textReader()
        {
            using (TextReader reader = File.OpenText("TextWriter.txt"))
            {
                Console.WriteLine(reader.ReadLine());
            }
        }

        /**
            BinaryWriter
         */
        public static void binaryWriter()
        {

            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open("binaryWriter.txt", FileMode.OpenOrCreate)))
            {
                binaryWriter.Write(1024);
                binaryWriter.Write("String ");
                binaryWriter.Write(true);
            }
        }
        /** BinaryReader*/
        public static void binaryReader()
        {
            using (BinaryReader reader = new BinaryReader(File
            .Open("binaryWriter.txt", FileMode.Open)))
            {

                Console.WriteLine("Integer Value : " + reader.ReadInt32());
                Console.WriteLine("String Value : " + reader.ReadString());
                Console.WriteLine("Boolean Value : " + reader.ReadBoolean());

            }
        }

        /**
            StringWriter 
         */

        public static void StringWriter()
        {
            string text = "Hello, Welcome to the yiibai.com \n" +
               "It is nice site. \n" +
               "It provides IT tutorials";

            StringBuilder stringBuilder = new StringBuilder();

            StringWriter stringWriter = new StringWriter(stringBuilder);
            stringWriter.WriteLine(text);
            stringWriter.Flush();
            stringWriter.Close();

            StringReader reader = new StringReader(stringBuilder.ToString());

            while (reader.Peek() != -1)
            {
                Console.WriteLine(reader.ReadToEnd());
            }

        }

        /**
            FileInfo
         */

        public static void FileInfo()
        {
            // FileInfo  属性 
            // FileInfo fileInfo=new FileInfo("file");
            // string name=fileInfo.Directory.Name;
            // Console.WriteLine(name);
            // Console.WriteLine(fileInfo.CreationTime);
            // Console.WriteLine(fileInfo.DirectoryName);
            // Console.WriteLine(fileInfo.Exists);
            // Console.WriteLine("FullName: "+fileInfo.FullName);
            // Console.WriteLine("IsReadOnly:"+fileInfo.IsReadOnly);

            // Console.WriteLine("NAME:"+fileInfo.Name);


            // 方法   
            //1. 生成文件
            FileInfo createFile = new FileInfo("file/test.txt");
            if (!createFile.Exists)
            {
                createFile.Create();
            }
            Console.WriteLine("test.txt create success !");
            //2. 写入文件

            StreamWriter writer = createFile.CreateText();
            writer.Write("add something into test.txt");
            writer.Close();

            Console.WriteLine("test.txt add success !");
            //3. 读取内容
            StreamReader reader = createFile.OpenText();

            Console.WriteLine(reader.ReadLine());


        }

    }

    [Serializable]
    class Student
    {
        public string name { get; }
        public int number { get; }
        public Student(string name, int number)
        {
            this.name = name;
            this.number = number;
        }

    }

}
