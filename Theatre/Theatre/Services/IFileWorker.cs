using System.Threading.Tasks;

namespace Theatre.Services
{
    public interface IFileWorker
    {
        void DownloadPDF(string name, byte[] pdfArray);

        void ShowPdfFile();
    }
}