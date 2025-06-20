using BookReadingManager.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingManager.Application.Validators
{
    public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
    {
        public CreateBookDtoValidator() { 
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");
            RuleFor(x => x.Author).NotEmpty().WithMessage("Author is required.");
            RuleFor(x => x.Genre).NotEmpty().WithMessage("Genre is required.");
            RuleFor(x => x.Publisher).NotEmpty().WithMessage("Publisher is required.");
            RuleFor(x => x.PageCount)
                .GreaterThan(0).WithMessage("Page count must be greater than 0.");
            RuleFor(x => x.PublishedDate) 
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Published date cannot be in the future.");
            RuleFor(x => x.ISBN).Length(10, 13).WithMessage("ISBN must be between 10 and 13 characters long.")
                .Matches(@"^\d{9}[\dX]$|^\d{13}$").WithMessage("ISBN must be a valid 10 or 13 digit number.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0.")
                .WithMessage("Price must have a maximum of 2 decimal places.");
            RuleFor(x => x.Format)
                .IsInEnum()
                .WithMessage("Formato inválido. Os valores permitidos são: Fisico, Kindle e PDF");

            RuleFor(x => x.Status)
                .IsInEnum()
                .WithMessage("Status inválido. Os valores permitidos são: Desejado, QueroLer, Lendo, Lido");

        }
    }
}
