[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Core")]
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Tests")]
namespace Domain.Relations
{
    public class FuaContextualizedResource
    {
        private string resourceId;
        private string noteId;

        internal FuaContextualizedResource()
            : this(null, null)
        {
            
        }

        internal FuaContextualizedResource(string pResourceId, string pNoteId)
        {
            resourceId = pResourceId;
            noteId = pNoteId;
        }

        #region Properties

        public string ResourceId
        {
            get { return resourceId; }
            set { resourceId = value; }
        }

        public string NoteId
        {
            get { return noteId; }
            set { noteId = value; }
        }

        #endregion

    }
}
