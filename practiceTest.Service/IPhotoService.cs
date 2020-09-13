using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using practiceTest.Core;

namespace practiceTest.Service
{
    public interface IPhotoService
    {
        Task<string> GetFirstThumbnail(int id);
        Task<int> GetAlbumByIdAsync(int id);
    }
}
