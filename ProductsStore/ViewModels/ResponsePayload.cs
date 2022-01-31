namespace ProductsStore.ViewModels
{
    public class ResponsePayload
    {
        public string Error { get; set; }
        public bool IsSuccess { get; set; }

        public ResponsePayload()
        {
            Error = "";
            IsSuccess = false;
        }

    }
}
