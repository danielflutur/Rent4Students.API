using Rent4Students.Domain.Entities.Base;

namespace Rent4Students.Domain.Entities.Enums
{
    public record DocumentType : BaseEnumEntity
    {
        public List<DocumentStorage> Documents { get; set; }
    }
}
