using QuizApi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApi.Infrastructure.Models;
using QuizApi.Infrastructure.Models.Entities;

namespace QuizApi.Infrastructure.Database.Configurations;

public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
{
    public void Configure(EntityTypeBuilder<Quiz> builder)
    {
        builder
            .HasKey(q => q.Id);

        builder
            .Property(q => q.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder
            .Property(q => q.Description)
            .HasMaxLength(1000);

        builder
            .Property(q => q.Type)
            .IsRequired()
            .HasConversion<string>(); 
        
        builder
            .Property(q => q.Visibility)
            .IsRequired()
            .HasConversion<string>(); 

        builder
            .Property(q => q.AccessCode)
            .HasMaxLength(100);

        builder
            .Property(q => q.IsAnonymousAllowed)
            .IsRequired();

        builder
            .Property(q => q.StartsAt)
            .IsRequired();

        builder
            .Property(q => q.EndsAt)
            .IsRequired();

        builder
            .Property(q => q.IsActive)
            .IsRequired();

        builder
            .Property(q => q.CreatedAt)
            .IsRequired();

        builder
            .HasMany(q => q.Questions)
            .WithOne(qst => qst.Quiz)
            .HasForeignKey(qst => qst.QuizId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
    