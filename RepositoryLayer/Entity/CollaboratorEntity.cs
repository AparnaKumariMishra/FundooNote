using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public class CollaboratorEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CollaboratorId { get; set; }
        public string CollaboratorEmail { get; set; }
        public DateTime Modifiedat { get; set; }

        [ForeignKey("Note")]
        public long NoteId { get; set; }
        public virtual NoteEntity Note { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }

        public virtual UserEntity User { get; set; }
        
    }
}
