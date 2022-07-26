using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DBJoin
{
    [Table("model")]
    public class Model
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Make { get; set; }
        public string Name { get; set; }
    }
}
