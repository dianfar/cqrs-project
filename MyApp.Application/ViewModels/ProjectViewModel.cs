using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Application.ViewModels
{
    public class ProjectViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description is Required")]
        [MaxLength(100)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Completion Date is Required")]
        [DisplayName("Completion Date")]
        public DateTime CompletionDate { get; set; }
    }
}
