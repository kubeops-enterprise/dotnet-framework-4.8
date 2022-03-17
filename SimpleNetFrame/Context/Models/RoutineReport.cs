using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleNetFrame.Context.Models
{
    [Table("routine_reports")]
    public class RoutineReport
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id")]
        public int Id { get; set; }
        [Column("topic")]
        public string Topic { get; set; }
        [Column("body")]
        public string Body { get; set; }
        [Column("created_date")]
        public DateTimeOffset CreatedDate { get; set; }
    }
}