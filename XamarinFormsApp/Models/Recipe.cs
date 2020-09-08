using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsApp.Models
{
    [Table("Recipes")]
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }
    }
}
