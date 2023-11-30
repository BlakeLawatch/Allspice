



namespace Allspice.Services;

public class RecipesService
{
    private readonly RecipesRepository _repository;

    public RecipesService(RecipesRepository repository)
    {
        _repository = repository;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        Recipe recipe = _repository.CreateRecipe(recipeData);
        return recipe;
    }

    internal string DestroyRecipe(int recipeId, string userId)
    {
        Recipe recipe = this.GetRecipeById(recipeId);
        if (recipe.CreatorId != userId)
        {
            throw new Exception("Not your recipe");
        }
        _repository.DestroyRecipe(recipeId);
        return "Recipe has been deleted";
    }

    internal Recipe EditRecipe(int recipeId, Account userInfo, Recipe recipeData)
    {
        Recipe originalRecipe = GetRecipeById(recipeId);
        if (originalRecipe.CreatorId != userInfo.Id)
        {
            throw new Exception("Not your recipe to edit");
        }
        originalRecipe.Title = recipeData.Title ?? originalRecipe.Title;
        originalRecipe.Instructions = recipeData.Instructions ?? originalRecipe.Instructions;
        originalRecipe.Img = recipeData.Img ?? originalRecipe.Img;
        originalRecipe.Category = recipeData.Category ?? originalRecipe.Category;




        _repository.EditRecipe(originalRecipe);
        return originalRecipe;
    }

    internal Recipe GetRecipeById(int recipeId)
    {
        Recipe recipe = _repository.GetRecipeById(recipeId);
        if (recipe == null)
        {
            throw new Exception("Doesn't exist");
        }
        return recipe;
    }

    internal List<Recipe> GetRecipes()
    {
        List<Recipe> recipes = _repository.GetRecipes();
        return recipes;
    }
}
