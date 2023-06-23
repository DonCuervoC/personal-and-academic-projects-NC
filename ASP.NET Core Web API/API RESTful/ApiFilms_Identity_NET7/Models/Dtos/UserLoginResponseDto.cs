namespace ApiFilms.Models.Dtos
{
    /* Una vez ingresamos los datos correctos, este recibe la respuesta del servidor (Usuario(nombre,id,username,role), Token(jwt))
     * Para obtener todos los datos utilizamos este Dto */
    public class UserLoginResponseDto
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}
