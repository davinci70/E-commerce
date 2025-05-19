namespace e_commerce.Contracts.Roles;

public record RoleRequest(
    string Name,
    IList<string> Permissions
);
