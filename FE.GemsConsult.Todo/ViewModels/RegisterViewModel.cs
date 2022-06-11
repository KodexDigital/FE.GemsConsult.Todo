using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FE.GemsConsult.Todo.ViewModels
{
    public class RegisterViewModel
    {
        [JsonPropertyName("name")]
        [Required(ErrorMessage = "Name required.")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        [Required(ErrorMessage = "Email required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [JsonPropertyName("phoneNumber")]
        [Required(ErrorMessage = "Phone number required.")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("password")]
        [Required(ErrorMessage = "Password required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [JsonPropertyName("confirmPassword")]
        [Required(ErrorMessage = "Re-enter your password.")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
