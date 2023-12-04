

namespace Allspice.Services;

public class AccountService
{
  private readonly AccountsRepository _repo;

  public AccountService(AccountsRepository repo)
  {
    _repo = repo;
  }

  internal Account GetProfileByEmail(string email)
  {
    return _repo.GetByEmail(email);
  }

  internal Account GetOrCreateProfile(Account userInfo)
  {
    Account profile = _repo.GetById(userInfo.Id);
    if (profile == null)
    {
      return _repo.Create(userInfo);
    }
    return profile;
  }


  // internal Account Edit(Account editData, string userEmail)
  // {
  //   Account original = GetProfileByEmail(userEmail);
  //   original.Name = editData.Name?.Length > 0 ? editData.Name : original.Name;
  //   original.Picture = editData.Picture?.Length > 0 ? editData.Picture : original.Picture;
  //   return _repo.Edit(original);
  // }
  internal Account EditAccount(Account user, string accountId, Account accountData)
  {
    Account original = GetProfileByEmail(user.Email);
    original.Picture = accountData.Picture ?? original.Picture;
    original.Name = accountData.Name ?? original.Name;
    Account newAccount = _repo.EditAccount(original);
    return newAccount;

  }


}
