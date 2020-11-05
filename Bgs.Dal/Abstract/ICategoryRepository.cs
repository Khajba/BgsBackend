using Bgs.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Dal.Abstract
{
    public interface ICategoryRepository
    {
        public void AddArtist(string name, int statusId);
        public void AddDesigner(string name, int statusId);
        public void AddMechanics(string name, int statusId);        
        public void UpdateArtistStatus(int id, int statusId);
        public void UpdateDesignerStatus(int id, int StatusId);
        public void UpdateMechanicsStatus(int id, int statusId);
        public IEnumerable<Designer> GetDesigners(int statusId);
        public IEnumerable<Artist> GetArtists(int statusId);
        public IEnumerable<Designer> GetMechanics(int statusId);

    }
}
