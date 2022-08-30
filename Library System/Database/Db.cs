using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;

namespace Database_
{
    public class Db
    {
        private Db() { }

        static Db instance = new Db();

        public static Db Instance { get { return instance; } }

        public async void CreateFile(string fileName)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile itemsFile = await storageFolder.CreateFileAsync(fileName + ".txt", CreationCollisionOption.ReplaceExisting);
        }

        public async Task WriteLines(string fileName, string[] arr)
        {
            var file = await GetDbFile(fileName);
            await FileIO.WriteLinesAsync(file, arr);
        }

        public async Task AddItem(string fileName, string txt)
        {
            var file = await GetDbFile(fileName);
            await FileIO.AppendTextAsync(file, txt + "\n");
        }

        public async Task<IList<string>> ReadFile(string fileName)
        {
            var file = await GetDbFile(fileName);
            return await FileIO.ReadLinesAsync(file);
        }

        private async Task<StorageFile> GetDbFile(string fileName)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile DbFile;

            if (await storageFolder.TryGetItemAsync(fileName + ".txt") == null)
            {
                CreateFile(fileName);
                DbFile = (StorageFile)await storageFolder.TryGetItemAsync(fileName + ".txt");
            }
            else
            {
                DbFile = (StorageFile)await storageFolder.TryGetItemAsync(fileName + ".txt");
            }
            return DbFile;
        }

        public async void ClearData(string fileName)
        {
            var db = await GetDbFile(fileName);
            await FileIO.WriteTextAsync(db, "");
        }
    }
}
