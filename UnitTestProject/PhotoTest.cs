using Microsoft.VisualStudio.TestTools.UnitTesting;
using practiceTest.Service;
using practiceTest.Core;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class PhotoTest
    {
        [TestMethod]
        public async Task TestGetPhotoById()
        {
            int idPrueba = 1;
            Album album = new Album();

            IPhotoService photoService = new PhotoService();
            int albumId= await photoService.GetAlbumByIdAsync(idPrueba);

            Assert.IsNotNull(albumId);
            
        }

        [TestMethod]
        public async Task TestGetPhotos()
        {
            int idPrueba = 1;
            string url = "";

            IPhotoService photoService = new PhotoService();
            url = await photoService.GetFirstThumbnail(idPrueba);

            Assert.IsNotNull(url);

        }
    }
}
