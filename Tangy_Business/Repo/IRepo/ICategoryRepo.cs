using Tangy_Models;

namespace Tangy_Business.Repo.IRepo
{
	public interface ICategoryRepo
	{
		public CategoryDTO CreateCategory(CategoryDTO objDTO);
		public int DeleteCategory(int id);
		public IEnumerable<CategoryDTO> GetCategories();
		public CategoryDTO GetCategory(int id);
		public CategoryDTO UpdateCategory(CategoryDTO objDTO);
	}
}