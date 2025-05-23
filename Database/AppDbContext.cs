using Hazelnut.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hazelnut.Database
{
	public class AppDbContext : DbContext
	{
		public DbSet<ToiletPaper> ToiletPapers { get; set; }
		public DbSet<SmallToiletPaper> SmallToiletPapers { get; set; }
		public DbSet<Napkin> Napkins { get; set; }
		public DbSet<PaperHandkerchiefs> PaperHandkerchiefs { get; set; }
		public DbSet<PaperContainer> PaperContainers { get; set; }
		public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Seeding data here
			modelBuilder.Entity<ToiletPaper>().HasData(
				new ToiletPaper { ProductId = -1, Name = "Giấy Vệ Sinh Cuộn Lớn 500g MC", Size = "100% Bột giấy nguyên sinh cao cấp", Origin = "Việt Nam", Producer = "Thế Giới Giấy", Weight = "500g 2&3 Lớp", Price = "200k/kg", Description = "_", ImagePath = "images/z5255387897448_58d446087449c96b41a44c4db8516e17.jpg", ImagePathSmall = "images/z5255387897448_58d446087449c96b41a44c4db8516e17-100x100.jpg 100w", ImagePathMedium = "images/z5255387897448_58d446087449c96b41a44c4db8516e17-400x400.jpg 400w", ImagePathLarge = "images/z5255387897448_58d446087449c96b41a44c4db8516e17.jpg 500w" },
				new ToiletPaper { ProductId = -2, Name = "Giấy Vệ Sinh Cuộn Lớn 600g MC", Size = "100% Bột giấy nguyên sinh cao cấp", Origin = "Việt Nam", Producer = "Thế Giới Giấy", Weight = "600g 2&3 Lớp", Price = "200k/kg", Description = "_", ImagePath = "images/z5255387897448_58d446087449c96b41a44c4db8516e17.jpg", ImagePathSmall = "images/z5255387897448_58d446087449c96b41a44c4db8516e17-100x100.jpg 100w", ImagePathMedium = "images/z5255387897448_58d446087449c96b41a44c4db8516e17-400x400.jpg 400w", ImagePathLarge = "images/z5255387897448_58d446087449c96b41a44c4db8516e17.jpg 500w" },
				new ToiletPaper { ProductId = -3, Name = "Giấy Vệ Sinh Cuộn Lớn 700g MC", Size = "100% Bột giấy nguyên sinh cao cấp", Origin = "Việt Nam", Producer = "Thế Giới Giấy", Weight = "700g 2&3 Lớp", Price = "200k/kg", Description = "_", ImagePath = "images/z5255387897448_58d446087449c96b41a44c4db8516e17.jpg", ImagePathSmall = "images/z5255387897448_58d446087449c96b41a44c4db8516e17-100x100.jpg 100w", ImagePathMedium = "images/z5255387897448_58d446087449c96b41a44c4db8516e17-400x400.jpg 400w", ImagePathLarge = "images/z5255387897448_58d446087449c96b41a44c4db8516e17.jpg 500w" }
			);
			modelBuilder.Entity<SmallToiletPaper>().HasData(
				new SmallToiletPaper { ProductId = -4, Name = "Giấy Vệ Sinh Tesla 10 Cuộn 3 Lớp", Size = "10 cuộn 3 lớp có lõi và không lõi", Weight = "800g/túi", Origin = "Việt Nam", Producer = "Thế Giới Giấy", Description = "_", ImagePath = "images/z5255371706902_f30db0cd5c7b7752529b437b38b1194f.jpg", ImagePathLarge = "images/z5255371706902_f30db0cd5c7b7752529b437b38b1194f.jpg 666w", ImagePathMedium = "images/z5255371706902_f30db0cd5c7b7752529b437b38b1194f-600x338.jpg 600w", Price = "200k/kg" },
				new SmallToiletPaper { ProductId = -5, Name = "Giấy vệ sinh Posy 10 cuộn 3 lớp có lõi và không lõi", Size = "_", Weight = "_", Origin = "Việt Nam", Producer = "Thế Giới Giấy", Description = "_", ImagePath = "images/Picture11.png", ImagePathLarge = "images/Picture11.png", Price = "200k/kg" }
			);
			modelBuilder.Entity<Napkin>().HasData(
				new Napkin { ProductId = -6, Name = "Giấy Lụa Rút Posy 120 Tờ 3 lớp Cao Cấp", Size = "198mm × 200 mm", Weight = "180 Tờ 3 lớp", Origin = "Posy Việt Nam", Producer = "Thế Giới Giấy", Description = "_", ImagePath = "images/Picture16.png", ImagePathLarge = "images/Picture16.png 349w", ImagePathSmall = "images/Picture16-100x100.png 100w", Price = "200k/kg" },
				new Napkin { ProductId = -7, Name = "Giấy Lụa Rút Cata", Size = "200mm x 185mm", Weight = "280 tờ/ túi x 2 lớp", Origin = "Việt Nam", Producer = "Thế Giới Giấy", Description = "_", ImagePath = "images/Picture15.png", ImagePathLarge= "images/Picture15.png", Price = "200k/kg" }
			);
			modelBuilder.Entity<PaperHandkerchiefs>().HasData(
				new PaperHandkerchiefs { ProductId = -8, Name = "Giấy Lau Tay Đa Năng Posy", Size = "190mm x 220mm", Weight = "100 Tờ 2 Lớp Gấp 2", Origin = "Posy Việt Nam", Producer = "Thế Giới Giấy", Description = "_", ImagePath = "images/Picture7.png", ImagePathLarge = "images/Picture7.png", Price = "200k/kg" },
				new PaperHandkerchiefs { ProductId = -9, Name = "Giấy Lụa Rút Cata", Size = "190mm x 220mm", Weight = "100 Tờ 2 Lớp", Origin = "Việt Nam", Producer = "Thế Giới Giấy", Description = "_", ImagePath = "images/Picture6.png", ImagePathLarge = "images/Picture6.png", Price = "200k/kg" }
			);
			modelBuilder.Entity<PaperContainer>().HasData(
				new PaperContainer { ProductId = -10, Name = "Hộp Đựng Giấy Lau Tay Nhựa", Size = "_", Weight = "_", Origin = "Posy Việt Nam", Producer = "Thế Giới Giấy", Description = "_", ImagePath = "images/Picture10.png", ImagePathLarge = "images/Picture10.png", Price = "200k/kg" },
				new PaperContainer { ProductId = -11, Name = "Hộp Đựng Giấy Lau Tay Inox", Size = "Inox 304 Cao Cấp", Weight = "_", Origin = "Việt Nam", Producer = "Thế Giới Giấy", Description = "_", ImagePath = "images/z5270723986943_6e8a877ec9d8f31c134b0c0d28e49651.jpg", ImagePathLarge = "images/z5270723986943_6e8a877ec9d8f31c134b0c0d28e49651.jpg", Price = "200k/kg" }
			);

		}
	}

}
