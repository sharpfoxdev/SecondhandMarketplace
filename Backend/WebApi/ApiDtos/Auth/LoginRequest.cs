using System.ComponentModel.DataAnnotations;

namespace WebApi.ApiDtos.Auth {
    public class LoginRequest {
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Username { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
