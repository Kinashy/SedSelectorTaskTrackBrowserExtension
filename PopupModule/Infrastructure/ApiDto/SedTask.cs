using testprog.Models;

namespace testprog.PopupModule.Infrastructure.ApiDto
{
    public class SedTask
    {
        public string documentId { get; set; }
        public string numerator { get; set; }
        public string summaryOfDocument { get; set; }
        public int daysLeft { get; set; }
        public string dateForExecution { get; set; }
        public string commissionSubject { get; set; }
        public string documentSubType { get; set; }
        public string internalNumber { get; set; }
        public TaskPerson[] signers { get; set; }
        public TaskPerson[] responsibles { get; set; }
    }
}
