﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.DTOs
{
    public abstract class PageRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public bool Descending { get; set; }

    }
}
