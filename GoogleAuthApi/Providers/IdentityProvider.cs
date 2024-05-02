using Google.Apis.Auth;
using GoogleAuthApi.Contracts;
using GoogleAuthApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace GoogleAuthApi.AuthServices
{
    public class IdentityProvider: IIdentityProvider
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;
        public IdentityProvider(IConfiguration config, IUserRepository userRepository)
        {
            _config = config;   
            _userRepository = userRepository;
        }

        public async Task<string> ValidateGoogleToken(string idToken)
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = new List<string> { _config["GoogleClientID"] }
                };
                var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);

                await HandleNewUser(payload.Email, payload.Name);

                var token = GenerateToken(payload.Email);
                if (token != null)
                    return token;
                else
                    throw new InvalidOperationException("Invalid Credentials");

            }
            catch (InvalidJwtException _)
            {
                Console.WriteLine(_);
                return "";
            }

        }

        public string GenerateToken(string email)
        {

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email)
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("youcannotreallyknowwhatthisisandwhythisis12345679824jfds8"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new(
                issuer: "Issuer",
                audience: "Audience",
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.Now.AddDays(2),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task HandleNewUser(string email, string Name)
        {
            try
            {
                User user = await _userRepository.GetUserByEmailAsync(email);
                if (user == null)
                {
                    User newUser = new User
                    {
                        Email = email,
                        Name = Name
                    };

                    await _userRepository.AddUserAsync(newUser);
                }
            }
            catch(Exception e) 
            { 
                Console.WriteLine(e);
            }

        }
    }
}
