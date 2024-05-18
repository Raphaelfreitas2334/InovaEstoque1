using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Data.Map
{
    public class LogsMap : IEntityTypeConfiguration<LogsModel>
    {
        public void Configure(EntityTypeBuilder<LogsModel> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Alimento);
        }
    }
}
