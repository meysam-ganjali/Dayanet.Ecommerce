using AutoMapper;
using Dayanet.Ecommerce.Application.Context;
using Dayanet.Ecommerce.Application.FASADE.Category;
using Dayanet.Ecommerce.Application.Services.Single.CategoryAttributes.Command;
using Dayanet.Ecommerce.Application.Services.Single.CategoryAttributes.Query;

namespace Dayanet.Ecommerce.Application.FASADE.CategoryAttribute;

public class CategoryAttributeFasade : ICategoryAttributeFasade {
    private readonly IDataBaseContext _db;
    private IMapper _mapper;

    public CategoryAttributeFasade(IDataBaseContext db, IMapper mapper) {
        _db = db;
        _mapper = mapper;
    }
    private ICreateCategoryAttributeService _createCategoryAttributeService;

    public ICreateCategoryAttributeService CreateCategoryAttribute {
        get {
            return _createCategoryAttributeService =
                _createCategoryAttributeService ?? new CreateCategoryAttributeService(_db, _mapper);
        }
    }

    private IUpdateCategoryAttributeService _updateCategoryAttributeService;
    public IUpdateCategoryAttributeService UpdateCategoryAttribute {
        get {
            return _updateCategoryAttributeService =
                _updateCategoryAttributeService ?? new UpdateCategoryAttributeService(_db);
        }
    }
    private IDeleteCategoruAttributeService _deleteCategoruAttributeService;
    public IDeleteCategoruAttributeService DeleteCategoruAttribute {
        get {
            return _deleteCategoruAttributeService =
                _deleteCategoruAttributeService ?? new DeleteCategoruAttributeService(_db);
        }
    }
    private IFetchCategoryAttributeService _fetchCategoryAttributeService;
    public IFetchCategoryAttributeService FetchCategoryAttribute {
        get {
            return _fetchCategoryAttributeService =
                _fetchCategoryAttributeService ?? new FetchCategoryAttributeService(_db, _mapper);
        }
    }

    private IFetchCategoryAttributeServiceById _fetchCategoryAttributeById;
    public IFetchCategoryAttributeServiceById FetchCategoryAttributeById {
        get {
            return _fetchCategoryAttributeById =
                _fetchCategoryAttributeById ?? new FetchCategoryAttributeServiceById(_db, _mapper);
        }

    }
}