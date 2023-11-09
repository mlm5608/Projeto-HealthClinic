namespace webapi.healthClinic.miguel.Utils
{
    public static class Criptografia
    {
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool CompararHash(string senhaForm, string SenhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, SenhaBanco);
        }
    }
}
