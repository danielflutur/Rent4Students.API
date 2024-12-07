﻿namespace Rent4Students.Domain.Entities
{
    public record FinancialHelpDocuments : DocumentStorage
    {
        public Guid? FacultyId { get; set; }
        public Faculty? Faculty { get; set; }
        public Guid? StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
