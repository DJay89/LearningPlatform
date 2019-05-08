using System.ComponentModel.DataAnnotations;


namespace LearningPlatform.Models.Validators
{
    public class PageValidate : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            FileUploadModel fileUploadModel = (FileUploadModel) validationContext.ObjectInstance;
           
            if ((int) value <= fileUploadModel.StartPage)
            {
                return new ValidationResult("The end page must be higher than start page");
            }

            return ValidationResult.Success;
        }
    }
}
