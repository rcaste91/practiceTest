using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using practiceTest.Core;

namespace practiceTest.Service
{
    public interface IAlbumService
    {
        Task<List<Album>> GetAlbumByIdAsync(int id);
        Task<Album> updateTitle(Album toUpdate);
    }
}
