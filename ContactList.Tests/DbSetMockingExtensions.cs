using Microsoft.EntityFrameworkCore;
using Moq;
namespace ContactList.Tests
{
	public static class DbSetMockingExtensions
	{
		public static DbSet<T> ReturnsDbSet<T>(this Mock<DbSet<T>> mockSet, IEnumerable<T> data) where T : class
		{
			var queryable = data.AsQueryable();
			mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
			mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
			mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
			mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
			return mockSet.Object;
		}
	}
}