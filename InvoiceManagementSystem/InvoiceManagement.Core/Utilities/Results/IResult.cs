namespace InvoiceManagement.Core.Utilities.Results
{
    public interface IResult
    {
        public string Message { get; }
        public bool Success { get; }
    }
}