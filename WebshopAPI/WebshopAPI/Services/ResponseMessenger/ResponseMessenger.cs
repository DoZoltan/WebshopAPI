namespace WebshopAPI.Services.ResponseMessenger
{
    public class ResponseMessenger : IResponseMessenger
    {
        public string SendProductIdNotFoundMessage(string productName, int productId)
        {
            return $"There is no {productName} with ID: {productId}";
        }

        public string SendWrongProductDataMessage()
        {
            return "Faulty product data";
        }

        public string SendWrongProductIdMessage(string productName, int IdOfTheProduct, int currentId)
        {
            return $"The {productName} to update id ({IdOfTheProduct}) and the current id ({currentId}) is not match";
        }

        public string SendWrongSocketTypeMessage(int socketEnumValue)
        {
            return $"The socket type ({socketEnumValue}) is not exist";
        }
    }
}
