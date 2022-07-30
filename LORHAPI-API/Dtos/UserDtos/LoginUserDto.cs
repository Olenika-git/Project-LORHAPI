namespace LORHAPI_API.Dtos.UserDtos
{
    public record LoginUserDto
    {
        public string Mail { get; set; }

        public string Password { get; set; }
    }
}
