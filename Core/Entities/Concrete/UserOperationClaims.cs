using Core.Entities;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Core.Entities.Concrete
{
    public partial class UserOperationClaims : IEntity
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? OperationClaimId { get; set; }
    }
}
