using System;

namespace Bgs.Common.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int UserId { get; set; }

        public DateTime CreateDate { get; set; }

        public string Description { get; set; }
    }
}