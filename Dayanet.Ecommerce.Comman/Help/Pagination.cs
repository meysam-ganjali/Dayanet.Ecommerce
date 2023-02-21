namespace Dayanet.Ecommerce.Comman.Help;

public static class Pagination {

    public static IEnumerable<TSource> ToPaged<TSource>(this IEnumerable<TSource> source, int page, int pageSize, out int rowsCount) {
        rowsCount = source.Count();
        return source.Skip((page - 1) * pageSize).Take(pageSize);
    }
}
