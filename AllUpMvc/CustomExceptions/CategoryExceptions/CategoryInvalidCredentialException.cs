namespace AllUpMVC.CustomExceptions.ProductExceptions
{
    public class CategoryInvalidCredentialException : Exception
    {
        public string PropertyName { get; set; }
        public CategoryInvalidCredentialException()
        {
        }

        public CategoryInvalidCredentialException(string? message) : base(message)
        {
        }

        public CategoryInvalidCredentialException(string? propertyName,string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
