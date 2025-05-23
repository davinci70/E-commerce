﻿namespace e_commerce.Contracts.Products;

public record UpdateProductRequest(
    string Name,
    int ProductTypeId,
    string Description,
    string SmallDescription,
    decimal Price,
    decimal Discount,
    int StockQuantity,
    List<int>? RemoveImagesIds,
    List<IFormFile>? ProductImages
);
