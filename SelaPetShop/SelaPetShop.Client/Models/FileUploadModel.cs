using System.ComponentModel.DataAnnotations;

namespace SelaPetShop.Client.Models
{
    public class FileUploadModel
    {
        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        [Required(ErrorMessage = "Please choose a file to upload.")]
        public string file { get; set; }
    }
}
