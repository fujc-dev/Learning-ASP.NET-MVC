﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace YT87s.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class YT87sEntities : DbContext
    {
        public YT87sEntities()
            : base("name=YT87sEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<SysModule> SysModule { get; set; }
        public DbSet<SysModuleOperate> SysModuleOperate { get; set; }
        public DbSet<SysRight> SysRight { get; set; }
        public DbSet<SysRightOperate> SysRightOperate { get; set; }
        public DbSet<SysRole> SysRole { get; set; }
        public DbSet<SysSimple> SysSimple { get; set; }
        public DbSet<SysUser> SysUser { get; set; }
        public DbSet<SysException> SysException { get; set; }
        public DbSet<SysLog> SysLog { get; set; }
    }
}
