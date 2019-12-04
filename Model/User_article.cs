using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AukroDbWPF.Model
{
    class User_article
    {
        public int ArticleId { get; set; }

        [ForeignKey("ArticleId")]
        [Required]
        public Article Article { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [Required]
        public User User { get; set; }
    }
}