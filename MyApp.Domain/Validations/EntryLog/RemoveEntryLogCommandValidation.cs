using MyApp.Domain.Commands;

namespace MyApp.Domain.Validations
{
    public class RemoveEntryLogCommandValidation : EntryLogValidation<RemoveEntryLogCommand>
    {
        public RemoveEntryLogCommandValidation()
        {
            ValidateId();
        }
    }
}
