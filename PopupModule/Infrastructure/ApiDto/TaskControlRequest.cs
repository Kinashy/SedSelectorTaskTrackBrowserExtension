

namespace testprog.PopupModule.Infrastructure.ApiDto
{
    public class TaskControlRequest // GET: api/task/taskControl
    {
        public int[] documentTypes { get; set; } = { 5, 7, 3, 1, 4, 8, 6 };
        public int periodFilter { get; set; } = 4;
        public int termless { get; set; } = 0;
        public bool onlyResolutions { get; set; } = false;
        public string[] controlTypes { get; set; } = new string[] { "without_control", "og_control", "special_control", "removed_from_control" };
        public string from { get; set; } = "";
        public string to { get; set; } = "";
        public string createFrom { get; set; } = "";
        public string createTo { get; set; } = "";
        public string[] numerators { get; set; } = new string[0];
        public string? documentSubType { get; set; } = null;
        public int[] statuses { get; set; } = { 50 };
        public bool onPerformanceExpired { get; set; } = false;
        public bool onPerformanceNotExpired { get; set; } = true;
        public bool executedExpired { get; set; } = false;
        public bool executedNotExpired { get; set; } = false;
        public int controlType { get; set; } = 0;
        public int departmentControl { get; set; } = 7;
        public string otherUserId { get; set; } = "63e1cf704f51e1ccc2c96e5f";
        TaskControlRequestResponsibleExecutor otherUser { get; set; } = new TaskControlRequestResponsibleExecutor();
        public int controlSignType { get; set; } = 0;
        public string token { get; set; } = "";
    }
}
