using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TogglTimeWeb.Shared;

public class TimeLimit
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TimeLimitID { get; set; }

    public TimeSpan? TimeSpan { get; set; } = null;
    public string? Description { get; set; } 
    public Priority Priority { get; set; }

    //Input Edit Model Only - Not Saved to DB
    [Required]
    [NotMapped] public int? Hours
    {
        get => this.TimeSpan?.Hours;
        set
        {
            if (value != null)
            {
                this.TimeSpan = System.TimeSpan.FromHours(value.Value);
            }
        }
    }
}

public enum Priority
{
    Low = 0,
    Medium = 1,
    High = 2, 
    Critical = 3
}