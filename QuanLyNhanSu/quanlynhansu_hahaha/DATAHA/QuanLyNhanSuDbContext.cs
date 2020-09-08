namespace QuanLyNhanSu.DATAHA
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuanLyNhanSuDbContext : DbContext
    {
        public QuanLyNhanSuDbContext()
            : base("name=QuanLyNhanSuDbContext")
        {
        }
    }
}
