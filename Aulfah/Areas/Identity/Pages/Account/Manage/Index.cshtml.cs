// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Xml.Linq;
using Aulfah.DAL.Model;
using Aulfah.Models;
using Aulfah.PL.Helper;
using Aulfah.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aulfah.PL.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IEmailSender _emailSender;




        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IUserStore<ApplicationUser> userStore,
            IEmailSender emailSender
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _emailSender = emailSender;


        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
           
            public string Fname { get; set; }
            public string Lname { get; set; }
            public string Email { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public string? Goverment { get; set; }
            public string? State { get; set; }
            //Image
            public string UserImage { get; set; }
            public IFormFile UserPath { get; set; }
            public string? Skills { get; set; }
            public string? Courses { get; set; }
            public string? SocialMedia { get; set; }
            public string? Services { get; set; }
            public string? ServicesType { get; set; }
            public string? NewServicesType { get; set; }


            public IEnumerable<SelectListItem> ServicesTypeList { get; set; }


        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            var email = await _userManager.GetEmailAsync(user);
            Username = userName;

            /* Assigning Value for User In Input */
            Input = new InputModel
            {
                Fname = user.FName,
                Lname = user.LName,
                Email = email,
                PhoneNumber = phoneNumber,
                DateOfBirth = user.dateOfBirth,
                Goverment = user.Goverment,
                ServicesTypeList = new List<string> { "Painting", "Drawing", "Textile", "Glass", "Mixed" }
                    .Select(i => new SelectListItem
                    {
                        Text = i,
                        Value = i
                    }).ToList()
            };

            /* If The user Logged In is Artist Only */
            /* Assign The Value Of These Attributes */
            if (user is Artist artist)
            {
                Input.Skills = artist.Skills;
                Input.Courses = artist.Courses;
                Input.SocialMedia = artist.socialMedia;
                Input.Services = artist.ServicesType;
                //Input.ServicesType = artist.ServicesType;
                //Input.NewServicesType = artist.ServicesType;

            }

            /*
            Username = userName;
            Input.Fname = user.FName;
            Input.Lname = user.LName;
            Input.Email = email;
            Input.DateOfBirth = user.dateOfBirth;
            Input.Goverment = user.Goverment;
            Input.State = user.State;
            */
        }

        public async Task<IActionResult> OnGetAsync()
        {

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            /* Change Here */
            await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);

            /* Setting The Updated Value */
           
                user.FName = Input.Fname;
                user.LName = Input.Lname;
                user.dateOfBirth = Input.DateOfBirth;
                user.PhoneNumber = Input.PhoneNumber;
                user.Goverment = Input.Goverment;
                user.State = Input.State;
            //  user.UserImage = DucomentConfi.DocumentUplod( "artistpic", Input.UserPath);

                user.UserImage = DucomentConfi.DocumentUplod(Input.UserPath, "ArtistPic");



            /* If The user Logged In is Artist Only */
            /* Update The Value Of These Attributes */
            if (user is Artist artist)
            {
                artist.Skills = Input.Skills;
                artist.Courses = Input.Courses;
                artist.socialMedia = Input.SocialMedia;

                //if ( Input.ServicesType != Input.NewServicesType && Input.NewServicesType != null)
                //{
                //    artist.ServicesType = Input.NewServicesType;
                //}
                //else
                if(Input.ServicesType != null)
                {
                    artist.ServicesType = Input.ServicesType;
                }
                else
                {
                    artist.ServicesType = Input.NewServicesType;
                }

            }


            // Save changes to the database
            var result = await _userManager.UpdateAsync(user);

            // Check the result
            if (result.Succeeded)
            {
                // Changes saved successfully
            }
            else
            {
                // Handle errors, for example, display error messages to the user
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            await _signInManager.RefreshSignInAsync(user);

            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}
