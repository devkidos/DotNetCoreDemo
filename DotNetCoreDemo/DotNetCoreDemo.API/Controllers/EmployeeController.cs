using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DotNetCoreDemo.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DotNetCoreDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public EmployeeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        { 
            this.userManager = userManager;
            this.signInManager = signInManager;
        } 

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return userManager.Users.Select(u => u.UserName).ToArray();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<JsonResult> Post(VMRegister vmRegister)
        {
            IdentityResult result = new IdentityResult();
            string errorMessage = "success";

            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = vmRegister.EmailId,
                    Email = vmRegister.EmailId
                };

                result = await userManager.CreateAsync(user, vmRegister.Password);

                if (result.Succeeded)
                {
                    //to Signin user
                    //signInManager.SignInAsync(user, isPersistent: false).Start();
                }
                else
                {
                    if (result.Errors.Count() > 0)
                    {
                        errorMessage = "";
                        foreach (var error in result.Errors)
                        {
                            errorMessage += error.Description;
                        }
                    }
                }
            }

            return Json(new { id = "1", message = errorMessage });
        } 

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<IActionResult> Login(VMLogin vmLogin)
        {
            var user = await userManager.FindByNameAsync(vmLogin.EmailId);
            if (user != null && await userManager.CheckPasswordAsync(user, vmLogin.Password))
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Secret 1234567890 phase"));

                var token = new JwtSecurityToken(
                    issuer: "http://mydomain.com",
                    audience: "http://mydomain.com",
                    expires: DateTime.UtcNow.AddHours(1),
                    claims: claims,
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
            }
            return Unauthorized();
        }  
    }
}