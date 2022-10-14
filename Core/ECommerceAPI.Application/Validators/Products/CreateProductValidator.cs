using ECommerceAPI.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Ürün adını boş geçmeyiniz")
                .MaximumLength(150)
                .MinimumLength(3)
                .WithMessage("Ürün adı 3-150 karakter arasında olmalı");


            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                .WithMessage("Stok bilgisi boş geçilemez")
                .Must(s => s >= 0)
                .WithMessage("Stok bilgisi negatif olamaz");


            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Fiyat bilgisi boş geçilemez")
                .Must(p => p >= 0)
                .WithMessage("Stok bilgisi negatif olamaz");


        }
    }
}
