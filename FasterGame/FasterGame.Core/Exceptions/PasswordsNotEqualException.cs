namespace FasterGame.Core.Exceptions
{
    public class PasswordsNotEqualException : Exception
    {
        public PasswordsNotEqualException() : base("As senhas devem ser iguais")
        {
            
        }
    }
}
