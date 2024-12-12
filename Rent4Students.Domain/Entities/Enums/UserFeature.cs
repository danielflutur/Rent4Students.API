﻿using Rent4Students.Domain.Entities.Base;

namespace Rent4Students.Domain.Entities.Enums
{
    public record UserFeature : BaseEnumEntity
    {
        public string Value { get; set; }
    }
}
