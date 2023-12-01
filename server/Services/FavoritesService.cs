

namespace Allspice.Services;

public class FavoritesService
{

    private readonly FavoritesRepository _repository;

    public FavoritesService(FavoritesRepository repository)
    {
        _repository = repository;
    }

    internal Favorite CreateFavorite(Favorite favoriteData)
    {
        Favorite favorite = _repository.CreateFavorite(favoriteData);
        return favorite;
    }

    // internal List<Favorite> GetMyFavorites(string userId)
    // {
    //     List<Favorite> favorites = _repository.GetMyFavorites(userId);
    //     return favorites;
    // }
}