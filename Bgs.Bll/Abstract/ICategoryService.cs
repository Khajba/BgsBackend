using Bgs.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Bll.Abstract
{
    public interface ICategoryService
    {
        public void AddArtist(string name);
        public void AddDesigner(string name);
        public void AddMechanics(string name);
        public IEnumerable<Artist> GetArtists();
        public void DeleteArtist(int id);
        public void DeleteDesigner(int id);
        public void DeleteMechanics(int id);
        public IEnumerable<Designer> GetDesigners();               
        public IEnumerable<Designer> GetMechanics();

    }
}
