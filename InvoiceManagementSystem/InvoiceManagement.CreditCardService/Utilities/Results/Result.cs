namespace InvoiceManagement.CreditCardService.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool status, int statusCode, string message) : this(status,statusCode)
        {
            Message = message;
        }

        public Result(bool status, int statusCode)
        {
            Status = status;
            StatusCode = statusCode;
        }

        public bool Status { get;}
        public int StatusCode { get; }
        public string Message { get; }
    }
}
