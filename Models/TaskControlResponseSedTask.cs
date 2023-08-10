using System.Collections.Generic;

namespace testprog.Models
{
    public class TaskControlResponseSedTask
    {
        public string documentId { get; set; }
        public string numerator { get; set; }
        public string summaryOfDocument { get; set; }
        public int daysLeft { get; set; }
        public string dateForExecution { get; set; }
        public string commissionSubject { get; set; }
        public string documentSubType { get; set; }
        public string internalNumber { get; set; }
        public TaskControlResponsePerson[] signers { get; set; }
        public TaskControlResponsePerson[] responsibles { get; set; }
    }
}