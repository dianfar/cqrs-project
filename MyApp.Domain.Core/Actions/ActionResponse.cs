namespace MyApp.Domain.Core.Commands
{
    public class ActionResponse
    {
        public static ActionResponse Ok = new ActionResponse { Success = true };
        public static ActionResponse Fail = new ActionResponse { Success = false };

        public ActionResponse(bool success = false)
        {
            Success = success;
        }

        public bool Success { get; private set; }
    }
}
