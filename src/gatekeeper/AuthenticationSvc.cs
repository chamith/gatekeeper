using System;
namespace Gatekeeper
{
	public class AuthenticationSvc
	{
		public AuthenticationSvc ()
		{
		}
		
		public User AddUser(string userName, string password, string firstName, string lastName)
		{
			string salt = CryptoHelper.CreateSalt(5);
			string hash = CryptoHelper.CreatePasswordHash(password, salt);
			User user = new User()
			{
				LoginName = userName,
				FirstName = firstName,
				LastName = lastName,
				PasswordHash = hash,
				PasswordSalt = salt
			};
			
			GatekeeperFactory.UserSvc.Add(user);
			
			return user;
		}
		
		public bool IsValidUser(string userName, string password)
		{
			User user = GatekeeperFactory.UserSvc.GetByLoginName(userName);
			
			string hash = CryptoHelper.CreatePasswordHash(password, user.PasswordSalt);
			
			return (hash == user.PasswordHash);
			
		}
	}
}

