
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace Allspice.Repositories;

public class IngredientsRepository
{

    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        string sql = @"
        INSERT INTO ingredients(name, quantity, recipeId, creatorId)
        VALUES (@Name, @Quantity, @RecipeId, @CreatorId);

        SELECT 
        ing.*,
        acc.*
        FROM ingredients ing
        JOIN accounts acc ON acc.id = ing.creatorId
        WHERE ing.id = LAST_INSERT_ID();";

        Ingredient ingredient = _db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, account) =>
        {
            ingredient.Creator = account;
            return ingredient;
        }, ingredientData).FirstOrDefault();
        return ingredient;
    }
}