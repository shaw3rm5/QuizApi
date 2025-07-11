using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApi.Infrastructure.Models.Entities;
using QuizApi.Infrastructure.Database.Constants;
namespace QuizApi.Infrastructure.Database.Configurations;

public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
{
    public void Configure(EntityTypeBuilder<Quiz> builder)
    {
        builder
            .HasKey(q => q.Id);
        builder
            .HasIndex(q => q.Title);
        
        builder
            .Property(q => q.Title)
            .IsRequired()
            .HasMaxLength(QuizConstants.TITLE_MAX_LENGTH);
        
        builder
            .Property(q => q.Description)
            .HasMaxLength(QuizConstants.DESCRIPTION_MAX_LENGTH);

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
            .HasMaxLength(QuizConstants.ACCESCODE_MAX_LENGTH);

        builder
            .Property(q => q.IsAnonymousAllowed)
            .IsRequired();

        builder
            .Property(q => q.DurationMinutes)
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
    