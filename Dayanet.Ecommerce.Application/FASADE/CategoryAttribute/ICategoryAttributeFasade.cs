using Dayanet.Ecommerce.Application.Services.Single.CategoryAttributes.Command;
using Dayanet.Ecommerce.Application.Services.Single.CategoryAttributes.Query;

namespace Dayanet.Ecommerce.Application.FASADE.CategoryAttribute;

public interface ICategoryAttributeFasade
{
 ICreateCategoryAttributeService CreateCategoryAttribute { get; }   
 IUpdateCategoryAttributeService UpdateCategoryAttribute { get; }
 IDeleteCategoruAttributeService DeleteCategoruAttribute { get; }
 IFetchCategoryAttributeService FetchCategoryAttribute { get; }
 IFetchCategoryAttributeServiceById FetchCategoryAttributeById { get; }
}