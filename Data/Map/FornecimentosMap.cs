using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Data.Map
{
    public class FornecimentosMap : IEntityTypeConfiguration<FornecimentosModel>
    {
        public void Configure(EntityTypeBuilder<FornecimentosModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Fornecedor);
            builder.HasOne(x => x.Alimento);
        }
    }
}
