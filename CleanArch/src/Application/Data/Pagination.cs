namespace Application.Data;

public record PaginationParams(
    int Page = 1, 
    int PageSize = 10
);

public record PaginatedResult<T>(
    int Page, 
    int PageSize,
    int LastPage,
    List<T> Data
);