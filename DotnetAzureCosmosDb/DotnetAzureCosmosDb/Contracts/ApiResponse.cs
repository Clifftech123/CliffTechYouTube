namespace DotnetAzureCosmosDb.Contracts
{
    public class ApiResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public object Result { get; set; }
    }
}
