using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApi.Infrastructure.Models.Entities;

namespace QuizApi.Infrastructure.Database.Configurations;

public class QuizAnalyticConfiguration : IEntityTypeConfiguration<QuizAnalytic>
{
    public void Configure(EntityTypeBuilder<QuizAnalytic> builder)
    {

        builder
            .HasKey(q => q.Id);
        
        builder
            .HasIndex(q => q.QuizId)
            .IsUnique();
        builder
            .Property(q => q.QuizId)
            .IsRequired();
        
        builder
            .Property(q => q.TotalResponses)
            .IsRequired();

        builder
            .Property(q => q.AverageCompletionTime)
            .IsRequired();

        builder
            .Property(q => q.CompletionRate)
            .IsRequired();

        builder
            .Property(q => q.LastCalculatedAt)
            .IsRequired();

        builder
            .HasOne(q => q.Quiz)
            .WithOne()
            .HasForeignKey<QuizAnalytic>(q => q.QuizId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
