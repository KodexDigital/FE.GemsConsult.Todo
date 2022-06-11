using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FE.GemsConsult.Todo.ViewModels
{
    public class LoginViewModel
    {
        [JsonPropertyName("email")]
        [Required(ErrorMessage ="Email required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        [Required(ErrorMessage = "Password required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
