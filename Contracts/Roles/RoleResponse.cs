﻿namespace e_commerce.Contracts.Roles;

public record RoleResponse(
    string Id,
    string Name,
    bool IsDeleted
);
