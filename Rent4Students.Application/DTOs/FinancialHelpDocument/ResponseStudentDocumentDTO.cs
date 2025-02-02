namespace Rent4Students.Application.DTOs.FinancialHelpDocument
{
    public class ResponseStudentDocumentDTO
    {
        public Guid Id { get; set; }
        public string StorageURL { get; set; }
        public string DocumentName { get; set; }
        public int DocumentStatusId { get; set; }
    }
}
