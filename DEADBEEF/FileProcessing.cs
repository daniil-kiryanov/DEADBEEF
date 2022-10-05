using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEADBEEF
{
    internal class FileProcessing
    {
        private readonly TextWorker textWorker = new TextWorker();
        private readonly DocxWorker docxWorker = new DocxWorker();
        private readonly XlsxWorker xlsxWorker = new XlsxWorker();
        private readonly Watcher watcher;

        public FileProcessing()
        {
            watcher = new Watcher(textWorker, docxWorker, xlsxWorker);
        }

        public void Start()
        {
            textWorker.Start();
            docxWorker.Start();
            xlsxWorker.Start();

            watcher.StartWatching();
        }
    }
}
