using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.Services.ResponseMessenger
{
    public interface IResponseMessenger
    {
        string SendProductIdNotFoundMessage(string productName, int productId);
        string SendWrongProductDataMessage();
        string SendWrongProductIdMessage(string productName, int IdOfTheProduct, int currentId);
        string SendWrongSocketTypeMessage(int socketEnumValue);
    }
}
