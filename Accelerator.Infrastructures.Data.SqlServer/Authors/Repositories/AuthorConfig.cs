using Accelerator.Core.Domain.Authors.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accelerator.Infrastructures.Data.SqlServer.Authors.Repositories
{
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.FirstName).IsRequired();
            entity.Property(x => x.LastName).IsRequired();
            entity.Property(x => x.AuthorType)
                .HasConversion(
                x => x.ToString(),
                x => (AuthorType)Enum.Parse(typeof(AuthorType), x));
            entity.Property<DateTime>("CreateTime");
            entity.Property<Guid>("CreateBy");
        }
    }
}
