


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

    internal Favorite GetFavoriteById(int favoriteId)
    {
        Favorite favorite = _repository.GetFavoriteById(favoriteId);
        if (favorite == null)
        {
            throw new Exception("This favorite doesn't exist");
        }
        return favorite;
    }

    internal string DestroyFavorite(int favoriteId, string userId)
    {
        Favorite favorite = GetFavoriteById(favoriteId);
        if (favorite.AccountId != userId)
        {
            throw new Exception("It gone");
        }
        _repository.DestoryFavorite(favoriteId);
        return "She gone";
    }

    internal List<FavoriteRecipes> GetMyFavorites(string userId)
    {
        List<FavoriteRecipes> favorites = _repository.GetMyFavorites(userId);
        return favorites;
    }
}