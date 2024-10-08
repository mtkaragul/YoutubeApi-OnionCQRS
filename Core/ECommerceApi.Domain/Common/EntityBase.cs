﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Domain.Common
{
    public class EntityBase : IEntityBase
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;

        // bu entity base in amacı entitylerimiz için ortak değerler vererek
        // kod tekrarını azaltmak. ve busayede generic repositorylerde kullanabiliyoruz.
    }
}
