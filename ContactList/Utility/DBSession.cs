

using ContactList.Data;
using ContactList.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ContactList.Utility
{
	public class DBSession

	{
		private ApplicationDbContext _context;

		public DBSession(ApplicationDbContext context)
		{
			_context = context;
		}

		public void Clear(int userId)
		{
			_context.Database.ExecuteSqlRaw("DELETE FROM Session WHERE UserId = {0}", userId);
		}

		public void Set(int userId, string Key, String Value)
		{
			Session? session = _context.Session.Where(s => s.UserId == userId & s.Key == Key).FirstOrDefault();
			if (session != null)
			{
				session.Value = Value;
				session.Updated = System.DateTime.Now;
				_context.Attach(session).State = EntityState.Modified;
				_context.SaveChanges();
			}
			else
			{
				session = new Session();
				session.Key = Key;
				session.Value = Value;
				session.UserId = userId;
				session.Updated = System.DateTime.Now;
				_context.Add(session);
				_context.SaveChanges();
			}
		}

		public string Get(int userId, string Key)
		{
			string result = string.Empty;
			Session? session = _context.Session.Where(s => s.UserId == userId & s.Key == Key).FirstOrDefault();
			
			if (session != null)
			{
				result = session.Value;
			}

			return result;

		}

	}
}
