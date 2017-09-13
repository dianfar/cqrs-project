using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Application.ViewModels
{
    public class RoleViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }
    }
}
