﻿using Rent4Students.Domain.Entities.Base;
using Rent4Students.Domain.Entities.Enums;

namespace Rent4Students.Domain.Entities.Joined
{
    public record RentHistory : BaseEntity
    {
        public Guid StudentId {  get; set; }
        public Student Student { get; set; }
        public Guid ListingId { get; set; }
        public Listing Listing { get; set; }
        public Guid? AttatchedPhotoId { get; set; }
        public StoredPhoto? AttatchedPhoto { get; set; }
        public Guid? RentDocumentId {  get; set; }
        public RentDocument? RentDocument { get; set; }
        public int RentStatusId {  get; set; }
        public RentStatus RentStatus { get; set; }
    }
}
