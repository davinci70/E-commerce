

namespace e_commerce.Services.Service;

public class AddressService(ApplicationDbContext context, CurrentUser currentUser) : IAddressService
{
    private readonly ApplicationDbContext _context = context;
    private readonly CurrentUser _currentUser = currentUser;

    public async Task<Result<AddressResponse>> AddAsync(AddressRequest request, CancellationToken cancellationToken = default)
    {
        var address = request.Adapt<Address>();
        address.UserId = _currentUser.UserId;

        await _context.AddAsync(address, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(address.Adapt<AddressResponse>());
    }

    public async Task<Result<AddressResponse>> GetAsync(int Id, CancellationToken cancellationToken = default)
    {
        var address = await _context.Addresses
            .Where(x => x.Id == Id && !x.IsDeleted)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        return address is not null ? Result.Success(address.Adapt<AddressResponse>()) : Result.Failure<AddressResponse>(AddressErrors.AddressNotFound);
    }

    public async Task<IEnumerable<AddressResponse>> GetByUserIdAsync(CancellationToken cancellationToken)
    {
        return await _context.Addresses
            .Where(x => x.UserId == _currentUser.UserId && !x.IsDeleted)
            .ProjectToType<AddressResponse>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Result> ToggleStatusAsync(int Id, CancellationToken cancellationToken = default)
    {
        var address = await _context.Addresses
            .Where(x => x.Id == Id && x.UserId == _currentUser.UserId)
            .FirstOrDefaultAsync(cancellationToken);

        if (address is null)
            return Result.Failure(AddressErrors.AddressNotFound);

        address.IsDeleted = !address.IsDeleted;

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result> UpdateAsync(int Id, AddressRequest request, CancellationToken cancellationToken = default)
    {
        var address = await _context.Addresses
            .Where(x => x.Id == Id && x.UserId == _currentUser.UserId && !x.IsDeleted)
            .FirstOrDefaultAsync(cancellationToken);

        if (address is null)
            return Result.Failure(AddressErrors.AddressNotFound);

        address = request.Adapt(address);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
