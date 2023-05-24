using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace PawKarTIWypozyczalnia.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Musisz podać email")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy format email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Musisz podać login")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Musisz podać hasło")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Musisz powtórzyć hasło")]
        [Compare("Password", ErrorMessage = "Hasła muszą być jednakowe")]
        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
