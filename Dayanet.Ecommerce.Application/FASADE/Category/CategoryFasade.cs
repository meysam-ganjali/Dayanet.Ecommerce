using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.Application.Services.Single.Category.Command;
using Dayanet.Ecommerce.Application.Services.Single.Category.Query;
using Dayanet.Ecommerce.Domain.Entities.Auth;

namespace Dayanet.Ecommerce.Application.FASADE.Category;

public class CategoryFasade : ICategoryFasade {
    private readonly IDataBaseContext _db;
    private IMapper _mapper;

    public CategoryFasade(IDataBaseContext bd, IMapper mapper) {
        _db = bd;
        _mapper = mapper;
    }
    private ICreateCategoryService _createCategoryService;
    public ICreateCategoryService CreateCategoryService {
        get {
            return _createCategoryService = _createCategoryService ?? new CreateCategoryService(_db, _mapper);
        }
    }
    private IDeleteCategoryService _deleteCategoryService;
    public IDeleteCategoryService DeleteCategoryService {
        get {
            return _deleteCategoryService = _deleteCategoryService ?? new DeleteCategoryService(_db);
        }
    }
    private IUpdateCategoryService _updateCategoryService;
    public IUpdateCategoryService UpdateCategoryService {
        get {
            return _updateCategoryService = _updateCategoryService ?? new UpdateCategoryService(_db);
        }
    }
    private IFetchCategoryService _fetchCategoryService;
    public IFetchCategoryService FetchCategoryService {
        get {
            return _fetchCategoryService = _fetchCategoryService ?? new FetchCategoryService(_db, _mapper);
        }
    }
    private IFetchCategoryByIdService _fetchCategoryByIdService;
    public IFetchCategoryByIdService FetchCategoryByIdService {
        get {
            return _fetchCategoryByIdService = _fetchCategoryByIdService ?? new FetchCategoryByIdService(_db, _mapper);
        }
    }
}