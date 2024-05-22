using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using clouddata.Data;
using System;
using System.Linq;

namespace clouddata.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new clouddataContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<clouddataContext>>()))
            {
                // Look for any files.
                if (context.DeduplicateViewModel.Any())
                {
                    return; // DB has been seeded
                }

                context.DeduplicateViewModel.AddRange(
                    new DeduplicateViewModel
                    {
                        FileName = "When Harry Met Sally",
                        FilePath = "/path/to/file1.txt",
                        FileHash = "abc123",
                        FileSize = 1024,
                        UploadDate = DateTime.Parse("1989-2-12"),
                        IsDuplicate = false
                    },
                    new DeduplicateViewModel
                    {
                        FileName = "Ghostbusters",
                        FilePath = "/path/to/file2.mp4",
                        FileHash = "xyz456",
                        FileSize = 2048,
                        UploadDate = DateTime.Parse("1984-3-13"),
                        IsDuplicate = false
                    },
                    new DeduplicateViewModel
                    {
                        FileName = "Ghostbusters 2",
                        FilePath = "/path/to/file3.mp4",
                        FileHash = "qrs789",
                        FileSize = 3072,
                        UploadDate = DateTime.Parse("1986-2-23"),
                        IsDuplicate = true
                    },
                    new DeduplicateViewModel
                    {
                        FileName = "Rio Bravo",
                        FilePath = "/path/to/file4.txt",
                        FileHash = "lmn012",
                        FileSize = 512,
                        UploadDate = DateTime.Parse("1959-4-15"),
                        IsDuplicate = false
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
