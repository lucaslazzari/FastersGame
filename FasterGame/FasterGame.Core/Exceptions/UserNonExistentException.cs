namespace FasterGame.Core.Exceptions
{
    public class UserNonExistentException : Exception
    {
        public UserNonExistentException() : base("Usuario nao existente")
        {
            
        }
    }
}
