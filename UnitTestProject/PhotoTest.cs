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

        PhotoService photoService;

        public PhotoTest()
        {
            photoService =  new PhotoService();
        }

        [TestMethod]
        public async Task TestGetPhotoById()
        {
            List<Album> albums;
            int idPrueba = 1;

            
            albums= await photoService.GetAlbumByIdAsync(idPrueba);

            Assert.IsNotNull(albums);
            
        }

        [TestMethod]
        public async Task TestGetPhotos()
        {
            int idPrueba = 1;
            string url = "";

            url = await photoService.GetFirstThumbnail(idPrueba);

            Assert.IsNotNull(url);

        }


        [TestMethod]
        public async Task TestGetAllPhotos()
        {
            int idPrueba = 1;

            List<Photo> photos = await photoService.GetAllPhotosInlbum(idPrueba);

            Assert.IsNotNull(photos);

        }

        [TestMethod]
        public async Task TestDeletePhoto()
        {
            int idPrueba = 1;

            bool deleted = await photoService.DeletePhoto(idPrueba);

            Assert.IsTrue(deleted);

        }


    }
}
