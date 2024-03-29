namespace Allspice.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly Auth0Provider _auth0Provider;
  private readonly FavoritesService _favoritesService;

  public AccountController(AccountService accountService, Auth0Provider auth0Provider, FavoritesService favoritesService)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
    _favoritesService = favoritesService;
  }

  [HttpGet]
  [Authorize]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [Authorize]
  [HttpGet("favorites")]
  public async Task<ActionResult<List<FavoriteRecipes>>> GetMyFavorites()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      string userId = userInfo.Id;
      List<FavoriteRecipes> favorites = _favoritesService.GetMyFavorites(userId);
      return Ok(favorites);
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }

  [Authorize]
  [HttpPut("{accountId}")]
  public async Task<ActionResult<Account>> EditAccount(string accountId, [FromBody] Account accountData)
  {
    try
    {
      Account user = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Account account = _accountService.EditAccount(user, accountId, accountData);
      return Ok(account);
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }
}
