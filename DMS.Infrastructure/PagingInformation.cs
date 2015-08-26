using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Infrastructure
{
    public class DataPagingInformation
    {
        private object lockSync = new object();
        private int? _numberingStart = null;
        private int? _numberingEnd = null;
        private int? _pageCount = null;
        public int Page { get; set; }
        public int PageSize { get; set; }

        public int NumberingStart
        {
            get
            {
                if (!_numberingStart.HasValue)
                {
                    lock (lockSync)
                    {
                        if (!_numberingStart.HasValue)
                        {
                            _numberingStart = ((Page - 1) * PageSize) + 1;
                        }
                    }
                }
                return (int)_numberingStart;
            }
        }

        public int NumberingEnd
        {
            get
            {
                if (!_numberingEnd.HasValue)
                {
                    lock (lockSync)
                    {
                        if (!_numberingEnd.HasValue)
                        {
                            _numberingEnd = NumberingStart + PageSize - 1;

                            if (_numberingEnd > ItemCount)
                            {
                                _numberingEnd = ItemCount;
                            }
                        }
                    }
                }
                return (int)_numberingEnd;
            }
        }

        public int PageCount
        {
            get
            {
                if (!_pageCount.HasValue)
                {
                    lock (lockSync)
                    {
                        if (!_pageCount.HasValue)
                        {
                            _pageCount = (int)Math.Ceiling(ItemCount / (double)PageSize);
                        }
                    }
                }
                return (int)_pageCount;
            }
        }

        public int ItemCount { get; set; }
        public int[] PageSizes { get; set; }
        public Func<int, string> CurrentPageLink { get; set; }
        public Func<int, string> PageSizeLink { get; set; }

        public DataPagingInformation(int pageSize, int page)
        {
            this.PageSize = pageSize;
            this.Page = page;
        }
    }
}
