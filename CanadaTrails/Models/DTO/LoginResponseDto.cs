namespace CanadaTrails.Models.DTO
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public string[] Roles { get; set; }
    }
}
