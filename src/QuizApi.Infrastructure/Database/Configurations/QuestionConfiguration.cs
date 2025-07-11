using QuizApi.Infrastructure.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuizApi.Infrastructure.Database.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder
            .HasKey(q => q.Id);

        builder
            .Property(q => q.QuestionText)
            .IsRequired()
            .HasMaxLength(150);

        builder
            .Property(q => q.Type)
            .IsRequired()
            .HasConversion<string>(); 

        builder
            .Property(q => q.OrderIndex)
            .IsRequired();

        builder
            .Property(q => q.IsRequired)
            .IsRequired();

        builder
            .Property(q => q.TimeLimitSeconds)
            .IsRequired();

        builder
            .Property(q => q.ImageUrl)
            .HasMaxLength(500);

        builder
            .HasOne(q => q.Quiz)
            .WithMany(qz => qz.Questions)
            .HasForeignKey(q => q.QuizId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
