﻿using KeepItFresh.Platform.API.Profiles.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;


namespace KeepItFresh.Platform.API.Profiles.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyProfilesConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Profile>().HasKey(p => p.Id);
        builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Profile>().OwnsOne(p => p.Name,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.FirstName).HasColumnName("FirstName");
                n.Property(p => p.LastName).HasColumnName("LastName");

            });
        builder.Entity<Profile>().OwnsOne(p => p.Email,
            e =>
        {
            
            //!!!!!!!!!!!!!ADDRESS MIGHT BE DELETED.
            e.WithOwner().HasForeignKey("Id");
            e.Property(a => a.Address).HasColumnName("EmailAddress");
        });
    }
}