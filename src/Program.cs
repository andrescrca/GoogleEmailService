using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoogleEmailService.APP
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Ruta del archivo de credenciales descargado desde la Consola de Desarrolladores de Google
            string credentialsFilePath =Path.Combine(Directory.GetCurrentDirectory(), "Providers", "Credentials-email.json");

            // Dirección de correo electrónico de la cuenta que enviará los correos
            string senderEmail = "test@test.net";

            // Dirección de correo electrónico del destinatario
            string recipientEmail = "test2@test2.com";

            // Asunto y cuerpo del correo el cuerpo puede ser un html
            string subject = "¡Hola desde la aplicación de consola!";
            string body = "Este es un correo de prueba enviado desde una aplicación de consola.";

            // Inicializar una instancia de GoogleEmailService
            var emailService = new GoogleEmailService(credentialsFilePath, senderEmail);

            try
            {
                // Enviar el correo electrónico
                await emailService.SendEmailAsync(recipientEmail, subject, body);

                Console.WriteLine("El correo electrónico se ha enviado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el correo electrónico: {ex.Message}");
            }
            finally
            {
                // Liberar los recursos utilizados por GoogleEmailService
                emailService.Dispose();
            }

            Console.ReadLine();
        }
    }
}
