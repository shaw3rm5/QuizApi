using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApi.Infrastructure.Models.Entities;

namespace QuizApi.Infrastructure.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(x => x.Id);
        builder
            .HasIndex(x => x.UserName);
        builder
            .Property(x => x.UserName);
        
        builder
            .HasMany(x => x.Quizzes)
            .WithOne(x => x.Author)
            .HasForeignKey(x => x.AuthorId);
    }
}