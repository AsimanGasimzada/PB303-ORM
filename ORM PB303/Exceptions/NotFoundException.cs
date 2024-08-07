namespace ORM_PB303.Exceptions;

public class NotFoundException:Exception
{
    public NotFoundException(string message="Not found"):base(message)
    {
        
    }
}
