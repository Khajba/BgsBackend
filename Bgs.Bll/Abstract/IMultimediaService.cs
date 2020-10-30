using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Bll.Abstract
{
    public interface IMultimediaService
    {
        public string AddImage(IFormFile file);
    }
}
