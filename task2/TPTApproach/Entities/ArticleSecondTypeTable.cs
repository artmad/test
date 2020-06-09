using System.ComponentModel.DataAnnotations.Schema;

namespace TPT.Entities
{
    [Table("ArticleSecondTypeTable")]
    public class ArticleSecondTypeTable : ArticleCommonTable
    {
        public string ArticleSecondTypeTableProperty { get; set; }
    }
}