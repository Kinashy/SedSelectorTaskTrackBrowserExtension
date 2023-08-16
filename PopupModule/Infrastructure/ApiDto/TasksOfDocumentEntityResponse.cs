

namespace testprog.PopupModule.Infrastructure.ApiDto
{
    public class TasksOfDocumentEntityResponse
    {
        public string? name { get; set; }
        public string documentId { get; set; }
        public string? parentId { get; set; }
        public string[] fieldLogs { get; set; }
        public string[] remappingLogs { get; set; }
        //public string[] taskToDraftLogs { get; set; }
        public int status { get; set; }
        //public string? commission { get; set; }
        public string comissionSubject { get; set; }
        public string? relatedDocuments { get; set; }
        public string executionProgress { get; set; }
        public string dateForExecution { get; set; }
        public string? dateOfExecution { get; set; }
        public string dateControl { get; set; }
        public string dateSigned { get; set; }
        public bool controlSign { get; set; }
        //public string[] childTasks { get; set; }
        public TasksOfDocumentEntityController[] controllers { get; set; }
        public TasksOfDocumentEntityResponsible[] responsibles { get; set; }
        public TasksOfDocumentEntityCreator creator { get; set; }
        public TasksOfDocumentEntityExecutor[] executors { get; set; }
        public string[] taskInWorkUsers { get; set; }
        public string[] toReport { get; set; }
        public TasksOfDocumentEntitySigner[] signers { get; set; }
        public TasksOfDocumentEntityForInformationItem[] forInformation { get; set; }
        public bool uread { get; set; }
        public bool creatorStart { get; set; }
        public TasksOfDocumentEntityDocumentInfo documentInfo { get; set; }
        public string id { get; set; }
        public string dateTime { get; set; }
        public string dateTimeLastChange { get; set; }
    }
}
