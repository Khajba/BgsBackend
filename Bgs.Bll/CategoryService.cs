using Bgs.Bll.Abstract;
using Bgs.Common.Entities;
using Bgs.Common.Enum;
using Bgs.Dal.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Bll
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService (ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void AddArtist(string name)
        {
            _categoryRepository.AddArtist(name, (int)CategoryStatus.Active);
        }

        public void AddDesigner(string name)
        {
            _categoryRepository.AddDesigner(name, (int)CategoryStatus.Active);
        }

        public void AddMechanics(string name)
        {
            _categoryRepository.AddMechanics(name, (int)CategoryStatus.Active);
        }

        public void DeleteArtist(int id)
        {
            _categoryRepository.UpdateArtistStatus(id, (int)CategoryStatus.Deleted);
        }

        public void DeleteDesigner(int id)
        {
            _categoryRepository.UpdateDesignerStatus(id, (int)CategoryStatus.Deleted);
        }

        public void DeleteMechanics(int id)
        {
            _categoryRepository.UpdateMechanicsStatus(id, (int)CategoryStatus.Deleted);
        }

        public IEnumerable<Artist> GetArtists()
        {
            return _categoryRepository.GetArtists((int)CategoryStatus.Active);
        }

        public IEnumerable<Designer> GetDesigners()
        {
            return _categoryRepository.GetDesigners((int)CategoryStatus.Active);
        }

        public IEnumerable<Designer> GetMechanics()
        {
            return _categoryRepository.GetMechanics((int)CategoryStatus.Active);
        }
    }
}
