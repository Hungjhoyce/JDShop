using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Review
{
    public class CreateReviewDto
    {
        public int Rating {get; set;}
        public string Comment {get; set;} = string.Empty;
        public Guid? ProductId {get; set;}
    }
}