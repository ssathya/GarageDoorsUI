using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArduinoControl.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        #region Public Properties

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required, Display(Name = "User Name")]
        [StringLength(15, ErrorMessage = "User Name is between 5 to 15 char"),
         MinLength(5, ErrorMessage = "User Name is between 5 to 15 char")]
        public string UserName { get; set; }

        #endregion Public Properties
    }

    public class ExternalLoginListViewModel
    {
        #region Public Properties

        public string ReturnUrl { get; set; }

        #endregion Public Properties
    }

    public class ForgotPasswordViewModel
    {
        #region Public Properties

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        #endregion Public Properties
    }

    public class ForgotViewModel
    {
        #region Public Properties

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        #endregion Public Properties
    }

    public class LoginViewModel
    {
        #region Public Properties

        //[Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        #endregion Public Properties
    }

    public class RegisterViewModel
    {
        #region Public Properties

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "User Name")]
        [StringLength(15, ErrorMessage = "User Name is between 5 to 15 char"), MinLength(5, ErrorMessage = "User Name is between 5 to 15 char")]
        public string UserName { get; set; }

        #endregion Public Properties
    }

    public class ResetPasswordViewModel
    {
        #region Public Properties

        public string Code { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        #endregion Public Properties
    }

    public class SendCodeViewModel
    {
        #region Public Properties

        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }

        public string SelectedProvider { get; set; }

        #endregion Public Properties
    }

    public class VerifyCodeViewModel
    {
        #region Public Properties

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        public string Provider { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }

        #endregion Public Properties
    }
}