using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer;
using RepositoryLayer.Entity;

namespace BusinessLayer.Interface
{
    public interface INoteBussiness
    {

        public NoteEntity AddNote(NoteModel noteModel, long userId);
        public NoteEntity UpdateNote(NoteModel noteModel, long userId);
        public bool DeleteNote(long userId, long noteId);
        public List<NoteEntity> GetAllNote(long userId);

        public bool IsPinNote(long noteId);
        public bool IsArchive(long noteId);
        public bool Istrash(long noteId);
        public NoteEntity Updatecolor(long noteId, string color);
        public bool RemoveTrashForever(long noteId);
        public IEnumerable<NoteEntity> DisplayNotes(long userId);
        public IEnumerable<NoteEntity> DisplayIsTrash(long userId);
        public NoteEntity Reminder(long noteId, DateTime reminder);

    }
}
