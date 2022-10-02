/*using System.Text;


class Program
{
    static void Main(string[] args)
    {
        using (FileStream fs = new FileStream("..\\..\\..\\filefolder\\file2.txt", FileMode.Open, FileAccess.Read))
        {

            byte[] arrayData = new byte[100];

            string searchSrting = "DEADBEEF";

            byte[] searchBytes = Encoding.Unicode.GetBytes(searchSrting.ToCharArray());

            int i = 0;
            byte[] tmp = new byte[0];
            int indexByte = 0;
            int skipSentenceCount = 0;
            while (i < fs.Length)
            {
                i += fs.Read(arrayData, 0, arrayData.Length);

                if (tmp.Length > 0)
                {
                    byte[] temp = new byte[arrayData.Length];
                    Array.Resize(ref arrayData, arrayData.Length + tmp.Length);
                    tmp.CopyTo(arrayData, 0);
                    temp.CopyTo(arrayData, tmp.Length);
                }

                int length = (i < arrayData.Length) ? i : arrayData.Length;
                int skipCount = 0;
                for (int j = 0; j < length - searchBytes.Length; j++)
                {
                    int count = 0;
                    for (int l = 0; l < searchBytes.Length; l++)
                    {
                        if ((arrayData[j + l] & searchBytes[l]) == searchBytes[l])
                            count++;
                    }

                    if ((arrayData[j] & 0x66) == 0x66)
                    {
                        skipCount++;
                    }
                    else
                    {
                        skipCount = (arrayData[j] != 0) ? 0 : skipCount;
                    }

                    if (count == searchBytes.Length)
                    {
                        Console.WriteLine("Искомая строка начинается с {0} бита", indexByte * 8);
                    }

                    if (skipCount == 5)
                    {
                        skipSentenceCount++;
                        skipCount = 0;
                    }

                    indexByte++;
                }

                tmp = new byte[searchSrting.Length];
                for (int j = 0; j < searchSrting.Length; j++)
                    tmp[j] = arrayData[arrayData.Length - searchSrting.Length + j];

                arrayData = new byte[1000];
            }
            Console.WriteLine("Кол-во пропущенных предложений: {0}", skipSentenceCount);
        }
    }
}
*/