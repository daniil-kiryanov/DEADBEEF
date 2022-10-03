// See https://aka.ms/new-console-template for more information

using System.Collections.Concurrent;

namespace ProcessFiles
{ 
    class Program

    { 
        static ConcurrentQueue<string> textQueue = new ConcurrentQueue<string>(); // очередь, которая обслуживает текстовые файлы
        static ConcurrentQueue<string> docxQueue = new ConcurrentQueue<string>(); // очередь, которая обслуживает doc файлы
        static ConcurrentQueue<string> xlsxQueue = new ConcurrentQueue<string>(); // очередь, которая обслуживает xlsx файлы

        static void Main()
        {
            var textTask = new Task(() =>
            {
                // TODO обработка отмены ?
                while (true) // мы пытаемся все время взять текстовый документ из начала очереди и обработать его
                {
                    bool dequeued = textQueue.TryDequeue(out string textFile); // в булевую переменную извлекаем статус (извлекли текстовый документ или нет)
                    if(dequeued)
                    {
                        // TODO обработка текстового файла
                    }
                    Thread.Sleep(10);
                }
            });
            using var watcher = new FileSystemWatcher(@"C:\Users\besed\FileProcess");

            watcher.Created += OnCreated; // добавляем обработчик для события Created

            watcher.IncludeSubdirectories = false; // не нужно следить за подкаталогами
            watcher.EnableRaisingEvents = true; // включить слежение

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        static void OnCreated(object sender, FileSystemEventArgs e) // e - это событие, касающееся создания файла, sender - источник событий (watcher)

        {
            if (File.Exists(e.FullPath))
            {
                string value = $"Created: {e.FullPath}";
                Console.WriteLine(value);
                bool locked = LockFile(e.Name); // если true, то это значит что процессу удалось заблокировать файл, false - файл уже заблокирован др. процессом
                if (locked)
                {
                    string extension = Path.GetExtension(e.Name).ToLower();
                    switch (extension)
                    {
                        case ".txt":
                            ProcessTextFile(e.Name);
                            break;
                        case ".docx":
                            ProcessDocFile(e.Name);
                            break;
                        case ".xlsx":
                            ProcessXlsFile(e.Name);
                            break;
                    }
                }

            }
        }

        static void ProcessXlsFile(string name)
        {
            xlsxQueue.Enqueue(name);
        }

        static void ProcessDocFile(string name)
        {
            docxQueue.Enqueue(name);
        }

        static void ProcessTextFile(string name)
        {
            textQueue.Enqueue(name);
        }

        static bool LockFile(string name)
        {
            return true; // см. https://iq.direct/blog/54-using-c-mutexes-for-inter-interprocess-synchronization.html
        }
            //    EventWaitHandle handle = new EventWaitHandle(
            //        false,                           /* Parameter ignored since handle already exists.*/
            //        EventResetMode.ManualReset,          /* Explained below. */
            //        "Course.C#.Directum.FileProcessing"
            //    );
            //    handle.
            //}
      }
}