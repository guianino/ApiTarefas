using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTarefas.Models;

[Table("tasks")]
public class MyTask {

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id {get; set;}

    [Required]
    [StringLength(100)]
    public string Title {get; set;} = default!;

    [Column(TypeName = "text")]
    public string description {get; set;} = default!;
    public bool completed {get; set;} = default!;
}