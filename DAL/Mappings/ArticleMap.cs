using ENTITY.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(new Article
            {
                Id = Guid.NewGuid(),
                Title = "ASP NET",
                Content = "ASP.NET, Microsoft tarafından geliştirilen ve web uygulamaları ile dinamik web siteleri oluşturmak için kullanılan bir web geliştirme framework'üdür. ASP.NET, .NET framework'ü üzerine inşa edilmiştir ve geliştiricilere güçlü bir araç seti sunar. Bu framework, dinamik sayfalar oluşturmak için HTML, CSS, JavaScript ve server-side kodları birleştirir. ASP.NET, MVC (Model-View-Controller) yapısı, Web Forms ve Web API gibi çeşitli programlama modelleri sunar. MVC modeli, uygulama yapısını daha düzenli ve yönetilebilir hale getirirken, Web Forms hızlı bir şekilde form tabanlı uygulamalar geliştirmeyi sağlar. Ayrıca, ASP.NET Core, platformlar arası destek sunarak Windows, Linux ve macOS üzerinde çalışabilen modern ve yüksek performanslı web uygulamaları geliştirmeyi mümkün kılar. ASP.NET'in sunduğu güvenlik özellikleri, performans optimizasyonları ve geniş kütüphane desteği, geliştiricilere hızlı ve güvenilir web çözümleri üretme imkanı tanır.",
                ViewCount = 15,
                CategoryId = Guid.Parse("4C569A9A-5F41-478F-9D17-69AC5B02AE0B"),
                ImageId = Guid.Parse("F71F4B9A-AA60-461D-B398-DE31001BF214"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                UserId = Guid.Parse("CB94223B-CCB8-4F2F-93D7-0DF96A7F065C")
            },
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Visual Studio",
                Content = "Visual Studio, Microsoft tarafından geliştirilen kapsamlı bir entegre geliştirme ortamıdır (IDE) ve yazılım geliştirme süreçlerini kolaylaştırmak için tasarlanmıştır. Geliştiricilere, uygulama geliştirme, hata ayıklama ve test yapma gibi bir dizi araç ve özellik sunar. Visual Studio, C#, VB.NET, C++, Python, JavaScript gibi birçok programlama dilini destekler ve çeşitli proje türleri için uygun araçlar sunar, bunlar arasında masaüstü uygulamaları, web uygulamaları, mobil uygulamalar ve bulut hizmetleri yer alır.",
                ViewCount = 15,
                CategoryId = Guid.Parse("D23E4F79-9600-4B5E-B3E9-756CDCACD2B1"),
                ImageId = Guid.Parse("D16A6EC7-8C50-4AB0-89A5-02B9A551F0FA"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                UserId = Guid.Parse("3AA42229-1C0F-4630-8C1A-DB879ECD0427")
            });
        }
    }
}
