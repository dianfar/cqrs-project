using MyApp.Domain.Commands;

namespace MyApp.Domain.Validations
{
    public class AddEntryLogCommandValidation : EntryLogValidation<AddEntryLogCommand>
    {
        public AddEntryLogCommandValidation()
        {
            ValidateUserId();
            ValidateProjectId();
        }
    }
}
