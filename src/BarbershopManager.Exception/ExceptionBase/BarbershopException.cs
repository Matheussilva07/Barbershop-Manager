namespace BarbershopManager.Exception.ExceptionBase;
public abstract class BarbershopException : SystemException
{
    protected BarbershopException(string message) : base(message)
    {
        
    }
    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}
