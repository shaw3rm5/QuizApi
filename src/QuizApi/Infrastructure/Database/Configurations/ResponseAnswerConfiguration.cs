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
            .HasColumnType("uuid[]");

        builder
            .Property(r => r.TextAnswer)
            .HasMaxLength(200) 
            .IsRequired(false); 

        builder
            .Property(r => r.RatingValue)
            .IsRequired(); 

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
            .OnDelete(DeleteBehavior.Restrict); 

    }
}
