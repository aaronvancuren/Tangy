using AutoMapper;
using Tangy_Business.Repo.IRepo;
using Tangy_Dao.Dao;
using Tangy_Models;

namespace Tangy_Business.Repo
{
	public class CategoryRepo : ICategoryRepo
	{
		private readonly ApplicationDbContext _db;
		private readonly IMapper _mapper;

		public CategoryRepo(ApplicationDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}

		public CategoryDTO CreateCategory(CategoryDTO categoryDTO)
		{
			Category? category = _mapper.Map<CategoryDTO, Category>(categoryDTO);
			category.CreatedDate = DateTime.Now;

			_db.Categories.Add(category);
			_db.SaveChanges();

			return _mapper.Map<Category, CategoryDTO>(category);
		}

		public int DeleteCategory(int id)
		{
			Category? category = _db.Categories.FirstOrDefault(c => c.Id == id);
			if(category is not null)
			{
				_db.Categories.Remove(category);
				return _db.SaveChanges();
			}
			return 0;
		}

		public IEnumerable<CategoryDTO> GetCategories()
		{
			return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
		}

		public CategoryDTO GetCategory(int id)
		{
			Category? category = _db.Categories.FirstOrDefault(c => c.Id == id);
			if (category is not null)
			{
				return _mapper.Map<Category, CategoryDTO>(category);
			}
			return new CategoryDTO();
		}

		public CategoryDTO UpdateCategory(CategoryDTO categoryDTO)
		{
			Category? category = _db.Categories.FirstOrDefault(c => c.Id == categoryDTO.Id);
			if (category is not null)
			{
				category.Name = categoryDTO.Name;
				_db.Categories.Update(category);
				_db.SaveChanges();
				return _mapper.Map<Category, CategoryDTO>(category);
			}
			return categoryDTO;
		}
	}
}