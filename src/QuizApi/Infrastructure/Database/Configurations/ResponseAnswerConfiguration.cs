namespace QuizApi.Infrastructure.Database.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities;

public class ResponseAnswerConfiguration : IEntityTypeConfiguration<ResponseAnswer>
{
    public void Configure(EntityTypeBuilder<ResponseAnswer> builder)
    {
        builder
            .HasKey(r => r.Id);

        builder
            .Property(r => r.ResponseId)
            .IsRequired();

        builder
            .Property(r => r.QuestionId)
            .IsRequired();

        builder
            .Property(r => r.SelectedAnswerIds)
            .IsRequired()
            .HasColumnType("uuid[]"); // массив UUID для PostgreSQL

        builder
            .Property(r => r.TextAnswer)
            .HasMaxLength(2000) // ограничение для текстового ответа
            .IsRequired(false); // не обязателен, зависит от вопроса

        builder
            .Property(r => r.RatingValue)
            .IsRequired(false); // только для rating

        builder
            .Property(r => r.AnsweredAt)
            .IsRequired();

        builder
            .HasOne<Response>()
            .WithMany(r => r.Answers)
            .HasForeignKey(r => r.ResponseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne<Question>()
            .WithMany()
            .HasForeignKey(r => r.QuestionId)
            .OnDelete(DeleteBehavior.Restrict); // не удаляем ответы при удалении вопроса

    }
}
