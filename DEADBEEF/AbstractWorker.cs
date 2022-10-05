using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEADBEEF
{
    internal abstract class AbstractWorker : IWorker
    {
        // очередь, которая обслуживает файлы
        private ConcurrentQueue<string> queue = new ConcurrentQueue<string>(); 

        public void AddWork(string name)
        {
            queue.Enqueue(name);
        }

        public void Start()
        { 
            var task = new Task(() =>
            {
                // TODO обработка отмены ?
                // мы пытаемся все время взять файл из начала очереди и обработать его
                while (true) 
                {
                    // в булевую переменную извлекаем статус (извлекли файл или нет)
                    bool dequeued = queue.TryDequeue(out string file); 
                    if (dequeued)
                    {
                        ProcessFile(file);
                    }
                    Thread.Sleep(10);
                }
            });

            task.Start();

        }

        protected abstract void ProcessFile(string name);
      
    }
}
