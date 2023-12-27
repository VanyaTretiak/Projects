using SQLite;
using System.ComponentModel;

namespace FinalApp
{
    [Table("Task")]
    public class TaskItem
    {
        [PrimaryKey]
        [AutoIncrement]
        //[Column("id")]
        public int Id { get; set; }
        //[Column("description")]
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Desc { get; set; }
        [MaxLength(250)]
        //[Column("category")]
        public string Category { get; set; }
        public bool Done{ get; set; }

    }
    //public override string ToString() => Name;
}
