using StoreServices.Api.ShoppingCart.RemoteModels;

namespace StoreServices.Api.ShoppingCart.RemoteInterfaces
{
    public interface IBooksService
    {
        Task<( bool result, RemoteBookMaterial book, string errorMessage )> GetBook(Guid BookId);
    }
}
