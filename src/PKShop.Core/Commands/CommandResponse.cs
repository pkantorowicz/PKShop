namespace PKShop.Core.Commands
{
    public class CommandResponse
    {
        public static CommandResponse Ok = new CommandResponse { Success = true };
        public static CommandResponse Fail = new CommandResponse { Success = false };

        public bool Success { get; set; }

        public CommandResponse(bool success = false)
        {
            Success = success;
        }

    }
}