using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPT.Entities
{
    public class ArticleCommonTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; }
        public virtual string  ArticleTitle { get; set; }
        public virtual string Type { get; set; }
    }
}