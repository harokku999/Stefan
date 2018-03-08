using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stefan.DataAccess.Entities
{
    public class Manufacturer : IEntity
    {
        [Column("rowid")]
        public int Id { get; set; }

        public string Name { get; set; }
        public string LogoPath { get; set; }
        public DateTime CreateDate { get; set; }
        public string Comment { get; set; }
        public int? ViewOrder { get; set; }
    }
}
