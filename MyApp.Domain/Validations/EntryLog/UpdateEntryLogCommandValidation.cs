using MyApp.Domain.Commands;

namespace MyApp.Domain.Validations
{
    public class UpdateEntryLogCommandValidation : EntryLogValidation<UpdateEntryLogCommand>
    {
        public UpdateEntryLogCommandValidation()
        {
            ValidateId();
            ValidateUserId();
            ValidateProjectId();
        }
    }
}
