﻿using Eleshop.Persistance.Dtos.Users;
using Eleshop.Persistance.Helpers;
using FluentValidation;

namespace Eleshop.Persistance.Validations.Users;

public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
{
    public UserUpdateValidator()
    {
        RuleFor(dto => dto.FirstName)
            .Length(3, 20).WithMessage("FirstName must be between 3 and 50 characters.")
            .Matches("^[A-Za-z]+$").WithMessage("FirstName can only contain letters");

        RuleFor(dto => dto.LastName)
            .Length(3, 20).WithMessage("LastName must be between 3 and 50 characters.")
            .Matches("^[A-Za-z]+$").WithMessage("LastName can only contain letters");

        RuleFor(dto => dto.BirthDate)
            .Must(ValidDateOfBirth).WithMessage("BirthDate is invalid!");

        RuleFor(dto => dto.PhoneNumber)
            .Must(phone => PhoneNumberValidator.IsValid(phone)).WithMessage("Phone number is invalid! ex: +998xxYYYAABB");

        RuleFor(dto => dto.PassportSerialNumber)
            .Length(9).WithMessage("PassportSerialNumber must only be 9 characters!")
            .Must(StartsWithTwoUppercaseLetters).WithMessage("The first two characters must be uppercase letters.")
            .Matches("^[A-Z0-9]+$").WithMessage("PassportSerialNumber can only contain capital letters and numbers.");

        RuleFor(dto => dto.Region)
           .NotEmpty().NotNull().WithMessage("Region is required!")
           .Length(3, 50).WithMessage("Region must be between 3 and 50 characters.");

        RuleFor(dto => dto.District)
            .NotEmpty().NotNull().WithMessage("District is required!")
            .Length(3, 50).WithMessage("District must be between 3 and 50 characters.");

        RuleFor(dto => dto.Address)
            .NotEmpty().NotNull().WithMessage("Address is required!")
            .Length(3, 100).WithMessage("Address must be between 3 and 100 characters.");

        When(dto => dto.ImagePath is not null, () =>
        {
            int maxImageSizeMB = 3;
            RuleFor(dto => dto.ImagePath!.Length).LessThan(maxImageSizeMB * 1024 * 1024 + 1).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
            RuleFor(dto => dto.ImagePath!.FileName).Must(predicate =>
            {
                FileInfo fileInfo = new FileInfo(predicate);
                return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);
            }).WithMessage("This file type is not image file");
        });
    }

    private bool StartsWithTwoUppercaseLetters(string name)
    {
        if (string.IsNullOrEmpty(name) || name.Length != 9) return false;
        return char.IsUpper(name[0]) && char.IsUpper(name[1]);
    }

    private bool ValidDateOfBirth(DateTime birthDate)
    {
        if (birthDate > DateTime.Now) return false;
        else return true;
    }
}
