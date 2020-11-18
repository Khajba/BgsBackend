using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Common.Entities
{
    public class Comment
    {
        public string Author { get; set; }

        public DateTime CreateDate { get; set; }

        public string Description { get; set; }
    }
}
