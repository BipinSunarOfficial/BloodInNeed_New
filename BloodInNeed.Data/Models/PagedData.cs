using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodInNeed.Data.Models
{
    public class PagedData<T>
    {
        public IEnumerable<T> Data { get; set; }

        public Pager Pager { get; set; }
    }
    public class PagedDataEditProfile<T1,T2>
    {
        public IEnumerable<T1> Data { get; set; }
        public IEnumerable<T2> Data2 { get; set; }

        public Pager Pager { get; set; }
        //public string ShowTmsPaymentStatus { get; set; }
    }

    public class PagedData1<T>
    {
        public List<T> Data { get; set; }

        public Pager Pager { get; set; }
    }

    public class PagedDataWithTotal<T1, T2>
    {
        public IEnumerable<T1> Data { get; set; }
        public Pager Pager { get; set; }
        public T2 Total { get; set; }
    }

    public class PagedDataWithTotal1<T1, T2>
    {
        public List<T1> Data { get; set; }
        public Pager Pager { get; set; }
        public T2 Total { get; set; }
    }

    public class PagerFilter
    {
        public int PageNo { get; set; }

        public int ItemsPerPage { get; set; }


        public int PagePerDisplay { get; set; }
    }

    public class Pager
    {
        public int PageNo { get; set; }

        public int ItemsPerPage { get; set; }

        public int PagePerDisplay { get; set; }

        public int TotalNextPages { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }

        public int ItemsThisDisplay { get; set; }

        public int TotalActiveUsers { get; set; }
        public decimal GrandTotal { get; set; }

        public decimal GrandTotalDebit { get; set; }
        public decimal GrandTotalCredit { get; set; }
        public decimal GrandTotalBalance { get; set; }
        public decimal GrandTotalCollateralBalance { get; set; }
        public decimal GrandTotalNetBalanceAfterPendingSettlement { get; set; }
        public decimal GrandTotalPurchaseAmt { get; set; }
        public decimal GrandTotalPurchaseComm { get; set; }
        public decimal GrandTotalSalesAmt { get; set; }
        public decimal GrandTotalSalesComm { get; set; }
        public decimal GrandTotalTotalComm { get; set; }
    }

    public class PagedDataItem<T>
    {
        public IEnumerable<T> Data { get; set; }

        public PagerItem Pager { get; set; }
    }

    public class PagedDataItemWithTotal<T1, T2>
    {
        public IEnumerable<T1> Data { get; set; }

        public PagerItem Pager { get; set; }

        public T2 Total { get; set; }
    }

    public class PagerItem
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int TotalRecords { get; set; }
        public string DefaultSubject { get; set; }
    }

    public class PagedDbResult<T>
    {
        public PagedDataItem<T> Data { get; set; }

        public DbMessage DbMessage { get; set; }
    }

    public class ObjectDbResult<T>
    {
        public T Data { get; set; }

        public DbMessage DbMessage { get; set; }
    }

    public class ListDbResult<T>
    {
        public IEnumerable<T> Data { get; set; }

        public DbMessage DbMessage { get; set; }
    }

}
