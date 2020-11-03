using Bgs.Bll.Abstract;
using Bgs.Common.Entities;
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
            _categoryRepository.AddArtist(name);
        }

        public void AddDesigner(string name)
        {
            _categoryRepository.AddDesigner(name);
        }

        public void DeleteArtist(int Id)
        {
            _categoryRepository.DeleteArtist(Id);
        }

        public void DeleteDesigner(int Id)
        {
            _categoryRepository.DeleteDesigner(Id);
        }

        public IEnumerable<Artist> GetArtists()
        {
            return _categoryRepository.GetArtists();
        }

        public IEnumerable<Designer> GetDesigners()
        {
            return _categoryRepository.GetDesigners();
        }
    }
}
