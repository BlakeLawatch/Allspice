namespace Allspice.Models;

public class Ingredient
{

    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public int RecipeId { get; set; }
    public int CreatorId { get; set; }
    public Account Creator { get; set; }
}