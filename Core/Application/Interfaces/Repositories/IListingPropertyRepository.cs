using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories {
	public interface IListingPropertyRepository {
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T">T has to be a class/ref type, so that we can add Include() on it in the implementation</typeparam>
		/// <returns></returns>
		public Task<List<T>> GetAllAsync<T>() where T : class, IEntity;
		public Task<T?> GetByIdAsync<T>(Guid id) where T : class, IEntity;
	}
}
