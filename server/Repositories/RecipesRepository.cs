





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

    internal void DestroyRecipe(int recipeId)
    {
        string sql = "DELETE FROM recipes WHERE id = @recipeId LIMIT 1;";

        _db.Execute(sql, new { recipeId });
    }



    internal Recipe EditRecipe(Recipe originalRecipe)
    {
        string sql = @"
        UPDATE recipes
        SET
        instructions = @instructions
        where id = @Id;

        SELECT
        rec.*,
        acc.*
        FROM recipes rec    
        JOIN accounts acc ON acc.id = rec.creatorId
        WHERE rec.id = @Id
        ;";

        Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }, originalRecipe).FirstOrDefault();
        return recipe;
    }

    internal Recipe GetRecipeById(int recipeId)
    {
        string sql = @"
        
        SELECT
        rec.*,
        acc.*
        FROM recipes rec
        JOIN accounts acc ON rec.creatorId = acc.id
        WHERE rec.id = @recipeId;";

        Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }, new { recipeId }).FirstOrDefault();
        return recipe;
    }

    internal List<Recipe> GetRecipes(string query)
    {
        query = "%" + query + "%";
        string sql = @"SELECT
         rec.*,
         acc.*
        FROM recipes rec
        JOIN accounts acc ON rec.creatorId = acc.id
        WHERE title LIKE @query OR category LIKE @query
        ;";

        List<Recipe> recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }, new { query }).ToList();
        return recipe;
    }
}
