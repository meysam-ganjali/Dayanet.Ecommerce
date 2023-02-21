using Dayanet.Ecommerce.Application.Services.Single.Category.Command;
using Dayanet.Ecommerce.Application.Services.Single.Category.Query;

namespace Dayanet.Ecommerce.Application.FASADE.Category;

public interface ICategoryFasade
{
    ICreateCategoryService CreateCategoryService { get; }
    IDeleteCategoryService DeleteCategoryService { get; }
    IUpdateCategoryService UpdateCategoryService { get;}
    IFetchCategoryService FetchCategoryService { get; }
    IFetchCategoryByIdService FetchCategoryByIdService { get; }
}