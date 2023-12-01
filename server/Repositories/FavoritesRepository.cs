
namespace Allspice.Repositories;

public class FavoritesRepository
{


    private readonly IDbConnection _db;

    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Favorite CreateFavorite(Favorite favoriteData)
    {
        string sql = @"
        INSERT INTO favorites(recipeId, accountId)
        VALUES (@RecipeId, @accountId);

        SELECT * FROM favorites WHERE id = LAST_INSERT_ID();";

        Favorite favorite = _db.Query<Favorite>(sql, favoriteData).FirstOrDefault();
        return favorite;
    }
}