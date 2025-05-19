namespace e_commerce.Errors;

public class AddressErrors
{
    public static readonly Error AddressNotFound =
        new("Address.NotFound", "Address is not found", StatusCodes.Status404NotFound);
    
    public static readonly Error NonRelatedAddress =
        new("Address.NonRelatedAddress", "This address is not related to the user", StatusCodes.Status404NotFound);
}
