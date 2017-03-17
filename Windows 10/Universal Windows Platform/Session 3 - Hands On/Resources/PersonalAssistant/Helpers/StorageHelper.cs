using Factoid.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Factoid.Helpers
{
    public static class StorageHelper
    {
        public async static Task<List<FactInformation>> GetFavoritesAsync()
        {
            List<FactInformation> favorites = new List<FactInformation>();

            var folder = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFolderAsync("Favorites", CreationCollisionOption.OpenIfExists);

            var files = await folder.GetFilesAsync();
            
            foreach(var file in files)
            {
                string content = await FileIO.ReadTextAsync(file);

                var favorite = JsonConvert.DeserializeObject<FactInformation>(content);

                favorites.Add(favorite);
            }

            return favorites;
        }

        public async static Task<bool> SaveFavoriteAsync(FactInformation fact)
        {
            bool successful = false;
            
            var folder = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFolderAsync("Favorites", CreationCollisionOption.OpenIfExists);

            var file = await folder.CreateFileAsync(fact.Id.ToString());

            fact.IsFavorite = true;

            string content = JsonConvert.SerializeObject(fact);

            await FileIO.WriteTextAsync(file, content);
            
            return successful;
        }

        public async static Task<bool> RemoteFavoriteAsync(FactInformation fact)
        {
            bool successful = false;

            var folder = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFolderAsync("Favorites", CreationCollisionOption.OpenIfExists);

            var file = await folder.GetFileAsync(fact.Id.ToString());

            await file.DeleteAsync();
            
            return successful;
        }
    }
}
