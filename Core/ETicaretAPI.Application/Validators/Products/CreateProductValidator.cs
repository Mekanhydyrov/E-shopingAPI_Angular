using ETicaretAPI.Application.Repositories.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Products
{
    public class CreateProductValidator: AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen Ürün Adını Boş Geçmeyiniz.")
                .MaximumLength(150)
                .MinimumLength(2)
                    .WithMessage("Lütfen Ürün Adını 2 ile 150 Karakter Arasında Giriniz.");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen Stok Bilgisin Boş Geçmeyiniz.")
                .Must(s => s >= 0)
                    .WithMessage("Stok Bilgisi Negatif Olamaz.");

            RuleFor(p => p.Price)
               .NotEmpty()
               .NotNull()
                   .WithMessage("Lütfen Fiyat Bilgisin Boş Geçmeyiniz.")
               .Must(s => s >= 0)
                   .WithMessage("Fiyat Bilgisi Negatif Olamaz.");
        }
    }
}
