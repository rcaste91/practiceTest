using System;
using System.Collections.Generic;
using System.Text;
using practiceTest.Service;
using practiceTest.Core;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class AlbumTest
    {
        IAlbumService albumService;

        public AlbumTest()
        {
            albumService = new AlbumService();
        }

        [TestMethod]
        public async Task TestGetAlbumById()
        {
            List<Album> albums;
            int idPrueba = 1;


            albums = await albumService.GetAlbumByIdAsync(idPrueba);

            Assert.AreEqual(idPrueba, albums[0].id);

        }


        [TestMethod]
        public async Task TestUpdateAlbumTitle()
        {
            Album album = new Album();
            album.id = 1;
            album.userId = 1;
            album.title = "nuevo titulo de prueba";

            Album updatedAlbum = await albumService.updateTitle(album);

            Assert.AreEqual(album.title, updatedAlbum.title);

        }


    }
}
