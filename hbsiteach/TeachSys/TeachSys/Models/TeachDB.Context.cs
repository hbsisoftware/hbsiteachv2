﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeachSys.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class TeachDBEntities3 : DbContext
    {
        public TeachDBEntities3()
            : base("name=TeachDBEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<BaseDataDics> BaseDataDics { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<BookUsed> BookUsed { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Majors> Majors { get; set; }
        public DbSet<PartJobTeacherDocs> PartJobTeacherDocs { get; set; }
        public DbSet<PartJobTeachers> PartJobTeachers { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<TeacherClasses> TeacherClasses { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Books_View> Books_View { get; set; }
        public DbSet<View_Books> View_Books { get; set; }
        public DbSet<View_TeacherClasses> View_TeacherClasses { get; set; }
    
        public virtual int AddClasses(Nullable<int> majorID, string name, Nullable<int> teacherID)
        {
            var majorIDParameter = majorID.HasValue ?
                new ObjectParameter("majorID", majorID) :
                new ObjectParameter("majorID", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var teacherIDParameter = teacherID.HasValue ?
                new ObjectParameter("TeacherID", teacherID) :
                new ObjectParameter("TeacherID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddClasses", majorIDParameter, nameParameter, teacherIDParameter);
        }
    }
}
