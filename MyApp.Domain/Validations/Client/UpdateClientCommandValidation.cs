using MyApp.Domain.Commands;

namespace MyApp.Domain.Validations
{
    public class UpdateClientCommandValidation : ClientValidation<UpdateClientCommand>
    {
        public UpdateClientCommandValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}
