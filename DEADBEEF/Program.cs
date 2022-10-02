class Program
{
    static void Main(string[] args)
    {
        /*
        using (FileStream fs = new FileStream("..\\..\\..\\filefolder\\file1.txt", FileMode.Create, FileAccess.Write))
        {
            double x = 2.55;
            byte[] bt = Encoding.Default.GetBytes(x.ToString());
            fs.Write(bt, 0, bt.Length);
        }
        */

        using (FileStream fs2 = new FileStream("..\\..\\..\\filefolder\\file2.txt", FileMode.Open, FileAccess.Read))
        {
            byte[] bt2 = new byte[fs2.];
            //Console.WriteLine("bt2 = {0}", bt2.ToString());
            //string str = " ";
            //str = fs2.;
            //Console.WriteLine("str = {0}", str);
            //fs2.Read(bt2, 0, bt2.Length);
            // ;
            //double x2 = Convert.ToDouble(st);
            //var bt3 = Convert.ToByte(bt2);
            //Console.WriteLine("st = {0}", st);
            /*
            if (fs2.CanSeek)
            {
                fs2.Seek(0, SeekOrigin.Begin);
            }
            else
            {
                Console.WriteLine(@"The stream doesn't support seeking.");
            }*/
        }
    }
}
