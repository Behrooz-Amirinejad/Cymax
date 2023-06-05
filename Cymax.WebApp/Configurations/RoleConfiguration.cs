using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cymax.WebApp.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole() { Name = "Visitor", NormalizedName = "VISITOR" },
            new IdentityRole() { Name = "Administration", NormalizedName = "ADMINISTRATION" }
            );
    }
}
