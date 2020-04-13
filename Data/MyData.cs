using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class MyData
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
    }
}