using System;
using Windows.Storage;
using Windows.UI.Popups;

namespace DodgeGame.Scripts
{
    class Storage
    {
        //Creates Storage Folder
        private static Windows.Storage.StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

        private static string _fileName = "GameSave.txt";

        public static async void CreateFile()
        {
            try
            {
                await storageFolder.CreateFileAsync(_fileName, CreationCollisionOption.ReplaceExisting);
            }
            catch
            {
                MessageDialog failed = new MessageDialog("There was a problem with saving the game."); await failed.ShowAsync();
            }
        }

        public static async void ReadFile()
        {
            try
            {
                Windows.Storage.StorageFile SaveFile = await storageFolder.GetFileAsync(_fileName);
                await Windows.Storage.FileIO.WriteTextAsync(SaveFile, "Save Slot 1.");
            } catch { }
        }
    }
}
