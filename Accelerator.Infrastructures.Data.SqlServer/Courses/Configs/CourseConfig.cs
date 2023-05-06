using Accelerator.Core.Domain.Courses.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accelerator.Infrastructures.Data.SqlServer.Courses.Configs
{
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> entity)
        {
           entity.HasKey(x=>x.Id);
            entity.Property(x => x.Title).IsRequired();
            entity.Property<DateTime>("CreateTime");
            entity.Property<Guid>("CreateBy");
        }

    }
    
}
