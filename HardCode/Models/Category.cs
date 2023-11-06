using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace HardCode.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Порядок отображения")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Порядок отображения категории должен быть больше 0")]
        public int DisplayOrder { get; set; }
    }
}
