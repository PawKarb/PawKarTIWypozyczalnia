using System.ComponentModel.DataAnnotations;

namespace PawKarTIWypozyczalnia.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Musisz podać login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Musisz podać hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
