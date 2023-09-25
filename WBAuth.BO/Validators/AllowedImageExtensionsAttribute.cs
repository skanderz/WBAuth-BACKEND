using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;


namespace WBAuth.BO.Validators;
public class AllowedImageExtensionsAttribute : ValidationAttribute
{
    private readonly string[] _extensions;

    public AllowedImageExtensionsAttribute(params string[] extensions){    _extensions = extensions;    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!_extensions.Contains(fileExtension)) {  return new ValidationResult($"Seuls les fichiers avec les extensions suivantes sont autorisés : {string.Join(", ", _extensions)}"); }
        }

        return ValidationResult.Success;
    }





}




