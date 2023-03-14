using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestEntityFramework.DataBase;

namespace TestEntityFramework.DataBase.ModelConfiguration
{
    public class AccountsConfig : IEntityTypeConfiguration<Accounts>
    {
        public void Configure(EntityTypeBuilder<Accounts> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}