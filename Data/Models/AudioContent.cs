using System.ComponentModel.DataAnnotations.Schema;

namespace yadro.Data.Models
{
    #nullable disable
    public class AudioContent
    {
        public string Id { get; set; }
        public string Path { get; set; }
        public string DisplayedName { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public bool IsPlaying { get; set; }
    }
}