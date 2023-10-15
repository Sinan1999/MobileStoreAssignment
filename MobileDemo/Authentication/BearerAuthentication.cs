using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MobileDemo.Authentication
{
    public class BearerAuthentication : IBearerAuthentication
    {
        private readonly String bearerKey;
        public BearerAuthentication(String bearerKey)
        {
            this.bearerKey = bearerKey;
        }
        public string GetToken()
        {


            var TokenHandler = new JwtSecurityTokenHandler();
            var TokenKey = Encoding.ASCII.GetBytes(bearerKey);
            var TokenDescriptor = new SecurityTokenDescriptor
            {

                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(TokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = TokenHandler.CreateToken(TokenDescriptor);
            return TokenHandler.WriteToken(token);
        }
    }
}