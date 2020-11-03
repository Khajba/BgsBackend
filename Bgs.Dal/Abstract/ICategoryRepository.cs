using Bgs.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Dal.Abstract
{
    public interface ICategoryRepository
    {
        public void AddArtist(string name);
        public void AddDesigner(string name);
        public IEnumerable<Artist> GetArtists();
        public void DeleteArtist(int Id);
        public void DeleteDesigner(int Id);
        public IEnumerable<Designer> GetDesigners();
    }
}
