using System;

namespace Bgs.Common.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public DateTime CreateDate { get; set; }

        public string Description { get; set; }
    }
}