using System.ComponentModel.DataAnnotations;

namespace TextSplitter.ViewModels
{
    public class TextSplitViewModel
    {
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Text to split must be between 2 and 30 characters long!")]
        public string TextToSplit { get; set; } = null!;
        public string? SplitText { get; set; }
    }
}
