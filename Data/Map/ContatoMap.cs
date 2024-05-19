using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Data.Map
{
    public class ContatoMap : IEntityTypeConfiguration<AlimentoModel>
    {
        public void Configure(EntityTypeBuilder<AlimentoModel> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
