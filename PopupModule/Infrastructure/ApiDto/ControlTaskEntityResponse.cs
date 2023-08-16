
namespace testprog.PopupModule.Infrastructure.ApiDto
{
    public class ControlTaskEntityResponse // Response: api/task/taskControl
    {
        public string documentId { get; set; }
        public string numerator { get; set; }
        public string summaryOfDocument { get; set; }
        public int daysLeft { get; set; }
        public string dateForExecution { get; set; }
        public string commissionSubject { get; set; }
        public string documentSubType { get; set; }
        public string internalNumber { get; set; }
        public ControlTaskEntityPerson[] signers { get; set; }
        public ControlTaskEntityPerson[] responsibles { get; set; }
    }
}