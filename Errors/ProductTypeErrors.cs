namespace e_commerce.Errors;

public class ProductTypeErrors
{
    public static readonly Error ProductTypeNotFound =
        new("ProductType.NotFound", "Product type is not found", StatusCodes.Status404NotFound);
    
    public static readonly Error DuplicatedTitle =
        new("ProductType.DuplicatedTitle", "Another product type with the same title is already exists", StatusCodes.Status409Conflict);
}
