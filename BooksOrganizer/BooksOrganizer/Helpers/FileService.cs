using BooksOrganizer.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksOrganizer.Model
{
    public class FileService : IFileService
    {
    
        private string _folder  ;
        private string _filter;
        private bool _includeSubs;

        public Task<bool> DeleteAsync(string filename)
        {
            // удаляем файл
            try
            {
                File.Delete(GetFilePath(filename));

                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(true);
            }
        }

        // вспомогательный метод для построения пути к файлу
        string GetFilePath(string filename)
        {
            return Path.Combine(GetDocsPath(), filename);
        }
        // получаем путь к папке MyDocuments
        string GetDocsPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        public Task<bool> ExistsAsync(string filename)
        {
            string filepath = GetFilePath(filename);
            // существует ли файл
            bool exists = File.Exists(filepath);
            return Task.FromResult(exists);
        }

        public async void GetData(string folder, string filter, bool includeSubs, Action<DataItem, Exception> callback)
        {
            _folder = folder;
            _filter = filter;
            _includeSubs = includeSubs;

            // Use this to connect to the actual data service
            var item = new DataItem(_folder, _filter, _includeSubs);
            await ScanFolderAsync();
            callback(item, null);
        }

        public async Task<bool> ScanFolderAsync()
        {
            try
            {
               // var ret = new List<DataListItem>();
                var files = Directory.EnumerateFiles(_folder, _filter, _includeSubs ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                await Task.Run(() => {
                    Parallel.ForEach(files, new ParallelOptions() { MaxDegreeOfParallelism = 1 }, (file) =>
                    {
                        var item = new DataListItem(file);
                        Messenger.Default.Send<DataListItem>(item);
                       // this.files.Add(item);
                    });
                });

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
