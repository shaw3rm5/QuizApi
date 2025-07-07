namespace QuizApi.Infrastructure.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities;

public class AnswerOptionConfiguration : IEntityTypeConfiguration<AnswerOption>
{
    public void Configure(EntityTypeBuilder<AnswerOption> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .Property(a => a.OptionText)
            .IsRequired()
            .HasMaxLength(30);

        builder
            .Property(a => a.OrderIndex)
            .IsRequired();

        builder
            .Property(a => a.IsCorrect)
            .IsRequired();

        builder
            .Property(a => a.QuestionId)
            .IsRequired();

        builder
            .HasOne<Question>()
            .WithMany()
            .HasForeignKey(a => a.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
