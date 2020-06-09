using System.ComponentModel.DataAnnotations.Schema;

namespace TPT.Entities
{
    [Table("ArticleFirstTypeTable")]
    public class ArticleFirstTypeTable: ArticleCommonTable
    {
        public string ArticleFirstTypeTableProperty { get; set; }
    }
}