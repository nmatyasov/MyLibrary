using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksOrganizer.Model
{
    public interface IFileService
    {
        Task<bool> ExistsAsync(string filename); // проверка существования файла
        Task<bool> ScanFolderAsync();  // получение файлов из определнного каталога
        Task<bool> DeleteAsync(string filename);  // удаление файла
        void GetData(string folder, string filter, bool includeSubs, Action<DataItem, Exception> callback); // поиск файлов по заданным критериям
    }
}
