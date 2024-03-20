using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRESTServices.BLL.DTOs.Validation
{
    public class CategoryUpdateDTOValidator : AbstractValidator<CategoryUpdateDTO>
    {
        public CategoryUpdateDTOValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category Name harus diisi");
            RuleFor(x => x.CategoryName).MaximumLength(100).WithMessage("Category Name maksimal 50 karakter");
        }
    }
}
