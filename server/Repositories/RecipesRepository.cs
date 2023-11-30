

namespace Allspice.Repositories;

public class RecipesRepository
{

    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        string sql = @"
        INSERT INTO recipes(title, instructions, img, category, creatorId)
        VALUES(@Title, @Instructions, @Img, @Category, @CreatorId);

        SELECT 
        rec.*,
        acc.*
        FROM recipes rec
        JOIN accounts acc ON rec.creatorId = acc.id
        WHERE rec.id = LAST_INSERT_ID();";

        Recipe recipe = _db.Query<Recipe, Account, Recipe>
        (sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }, recipeData).FirstOrDefault();
        return recipe;
    }

    internal List<Recipe> GetRecipes()
    {
        string sql = @"SELECT
         rec.*,
         acc.*
        FROM recipes rec
        JOIN accounts acc ON rec.creatorId = acc.id;";

        List<Recipe> recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }).ToList();
        return recipe;
    }
}
