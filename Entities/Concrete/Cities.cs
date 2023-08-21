﻿using Core.Entities;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Concrete
{
    public partial class Cities:IEntity
    {
        public Cities()
        {
            CustomerReport = new HashSet<CustomerReport>();
            Customers = new HashSet<Customers>();
            Prospects = new HashSet<Prospects>();
            SalesPerformanceReport = new HashSet<SalesPerformanceReport>();
        }

        public int Id { get; set; }
        public int CountryId { get; set; }
        public string CityName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Countries Country { get; set; }
        public virtual ICollection<CustomerReport> CustomerReport { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }
        public virtual ICollection<Prospects> Prospects { get; set; }
        public virtual ICollection<SalesPerformanceReport> SalesPerformanceReport { get; set; }
    }
}
