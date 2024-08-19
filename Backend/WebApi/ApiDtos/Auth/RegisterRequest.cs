using System.ComponentModel.DataAnnotations;

namespace WebApi.ApiDtos.Auth {
	public class RegisterRequest {
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Username { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		// TODO will not be here, basic users will always have role "User"
		public string[] Roles { get; set; }
	}
}
