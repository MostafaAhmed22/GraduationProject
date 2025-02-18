using Hakawy.Core.Entities;
using Hakawy.Core.Repositories.Interfaces;
using Hakawy.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hakawy.Repository.Repositories
{
	internal class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private readonly HakawyDBContext _context;

		public GenericRepository(HakawyDBContext context)
		{
			_context = context;
		}

		public Task AddAsync(T entity)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task<T?> GetByIdAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public Task UpdateAsync(T entity)
		{
			throw new NotImplementedException();
		}
	}
}
