using System;

namespace Examen_V2.Models.Base
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        DateTime? DateCreated { get; set; }
        DateTime? LastModified { get; set; }
    }
}
