using MyApp.Domain.Commands;

namespace MyApp.Domain.Validations
{
    public class AddProjectMemberCommandValidation : ProjectMemberValidation<AddProjectMemberCommand>
    {
        public AddProjectMemberCommandValidation()
        {
            ValidateProjectId();
            ValidateUserId();
        }
    }
}
