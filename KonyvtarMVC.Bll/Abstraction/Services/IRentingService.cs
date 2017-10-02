using System.Threading.Tasks;

namespace KonyvtarMVC.Bll.Abstraction.Services
{
    public interface IRentingService
    {
        Task Rent(string bookBarcode, int userCardNumber);
        Task Return(string bookBarcode);
    }
}