using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Review
    {
        public Guid Id {get; set;} = Guid.NewGuid();
        // User ----------------
        public Guid? UserId {get; set;}
        // ---------------------
        //  Product -----------------
        public Guid? ProductId {get; set;}
        // ----------------------
        public int Rating {get; set;}
        public string Comment {get; set;} = string.Empty;
        public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
    }
}