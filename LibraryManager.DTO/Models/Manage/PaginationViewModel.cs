﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DTO.Models.Manage
{
    public class PaginationViewModel
    {

        public int PageNumber { get; private set; }
        public int TotalPages { get; private set; }

        public PaginationViewModel(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageNumber < TotalPages);
            }
        }
    }
}
 