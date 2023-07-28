using System.ComponentModel.DataAnnotations;
using backend.Dtos;

namespace backend.Middleware
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Provera da li zahtev sadrži podatke tela (body)
            if (context.Request.Method == "POST" && context.Request.HasFormContentType)
            {
                var form = await context.Request.ReadFormAsync();

                // Pokušaj deserializacije tela zahteva u LoginReqDto objekat
                var loginReqDto = new LoginReqDto();
                if (!TryParseLoginReqDto(form, loginReqDto))
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Neispravni podaci u zahtevu.");
                    return;
                }

                // Validacija podataka koristeći DataAnnotations atribute
                var validationContext = new ValidationContext(loginReqDto, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();
                if (!Validator.TryValidateObject(loginReqDto, validationContext, validationResults, true))
                {
                    var errorMessages = string.Join(", ", validationResults.Select(v => v.ErrorMessage));
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Neispravni podaci u zahtevu. Greške: " + errorMessages);
                    return;
                }
            }

            await _next(context);
        }

        private bool TryParseLoginReqDto(IFormCollection form, LoginReqDto loginReqDto)
        {
            loginReqDto.Ime = form["Ime"];
            loginReqDto.Prezime = form["Prezime"];
            loginReqDto.Pol = form["Pol"];
            loginReqDto.DatumRodjenja = DateTime.Parse(form["DatumRodjenja"]);
            loginReqDto.Telefon = int.Parse(form["Telefon"]);
            loginReqDto.Drzava = form["Drzava"];
            loginReqDto.Grad = form["Grad"];
            loginReqDto.Adresa = form["Adresa"];
            loginReqDto.Email = form["Email"];
            loginReqDto.Password = form["password"];
            loginReqDto.Tip = form["Tip"];
            loginReqDto.Odobrenje = int.Parse(form["Odobrenje"]);

            // Povratna vrednost označava da li je objekat uspešno popunjen
            return true;
        }
    }
}
