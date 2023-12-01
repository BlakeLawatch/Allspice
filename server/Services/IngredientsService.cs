
using System.Security.Cryptography;

namespace Allspice.Services;

public class IngredientsService
{

    private readonly IngredientsRepository _repository;

    public IngredientsService(IngredientsRepository repository)
    {
        _repository = repository;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        Ingredient ingredient = _repository.CreateIngredient(ingredientData);
        return ingredient;
    }

    internal Ingredient GetIngredientById(int ingredientId)
    {
        Ingredient ingredient = _repository.GetIngredientsById(ingredientId);
        if (ingredient == null)
        {
            throw new Exception($"invalid Id:{ingredientId}");
        }
        return ingredient;
    }

    internal Ingredient DestroyIngredient(int ingredientId, string userId)
    {
        Ingredient ingredient = GetIngredientById(ingredientId);
        if (ingredient.CreatorId != userId)
        {
            throw new Exception("Not your ingredient to delete");
        }
        _repository.DestroyIngredient(ingredientId);
        return ingredient;
    }

    internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
    {
        List<Ingredient> ingredients = _repository.GetIngredientsByRecipeId(recipeId);
        return ingredients;
    }
}