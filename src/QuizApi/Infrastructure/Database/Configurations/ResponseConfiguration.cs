using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApi.Infrastructure.Entities;

namespace QuizApi.Infrastructure.Database.Configurations;

public class ResponseConfiguration : IEntityTypeConfiguration<Response>
{
    public void Configure(EntityTypeBuilder<Response> builder)
    {
        builder
            .HasKey(r => r.Id);

        builder
            .Property(r => r.QuizId)
            .IsRequired();

        builder
            .Property(r => r.UserId)
            .IsRequired(false);

        builder
            .Property(r => r.SessionId)
            .IsRequired(false);

        builder
            .Property(r => r.IpAddressHash)
            .IsRequired()
            .HasMaxLength(256);

        builder
            .Property(r => r.CreatedAt)
            .IsRequired();

        builder
            .Property(r => r.CompletedAt)
            .IsRequired();

        // Навигация к Quiz
        builder.HasOne(r => r.Quiz)
            .WithMany(q => q.Responses) // добавь Responses в Quiz, если ещё нет
            .HasForeignKey(r => r.QuizId)
            .OnDelete(DeleteBehavior.Cascade);

        // Навигация к ResponseAnswers
        builder.HasMany(r => r.Answers)
            .WithOne() // если в ResponseAnswer нет свойства Response
            .HasForeignKey(a => a.ResponseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
