﻿using Rent4Students.Domain.Entities.Base;

namespace Rent4Students.Domain.Entities.Enums
{
    public record DocumentType : BaseEnumEntity
    {
        public List<FinancialHelpDocument>? FinancialHelpDocuments { get; set; }
        public List<RentDocument>? RentDocuments { get; set; }
    }
}
