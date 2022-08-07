using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class User{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; } = "Not null";//Eğer AccessToken süresi dolduğunda kullanıcıyı logout etmek istemiyorsan kullanılır
        public DateTime? RefreshTokenExpireDate { get; set; } 
    }
}