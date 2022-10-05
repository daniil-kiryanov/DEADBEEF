using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEADBEEF
{
    internal class Watcher
    {
        private readonly IWorker TextWorker;
        private readonly IWorker DocxWorker;
        private readonly IWorker XlsxWorker;

        public Watcher(IWorker textWorker, IWorker docxWorker, IWorker xlsxWorker)
        {
            TextWorker = textWorker;
            DocxWorker = docxWorker;
            XlsxWorker = xlsxWorker;
        }
    
        public void StartWatching()
        {
            var watcher = new FileSystemWatcher(Constants.DIR_PATH); //

            watcher.Created += OnCreated; // добавляем обработчик для события Created

            watcher.IncludeSubdirectories = false; // не нужно следить за подкаталогами
            watcher.EnableRaisingEvents = true; // включить слежение
        }

        private void OnCreated(object sender, FileSystemEventArgs e) // e - это событие, касающееся создания файла, sender - источник событий (watcher)

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
                            TextWorker.AddWork(e.Name);
                            break;
                        case ".docx":
                            DocxWorker.AddWork(e.Name);
                            break;
                        case ".xlsx":
                            XlsxWorker.AddWork(e.Name);
                            break;
                    }
                }

            }
        }
        private bool LockFile(string name)
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