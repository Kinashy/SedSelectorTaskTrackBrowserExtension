namespace SelectorExtensionForChrome.PopupModule.Infrastructure.ApiDto
{
    public class TasksOfDocumentEntitySigner
    {
        public string id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string partronymic { get; set; }
        public string? departmentId { get; set; }
        public string? departmentName { get; set; }
        public string? sectionId { get; set; }
        public string? sectionName { get; set; }
        public string? position { get; set; }
        public string? fullPosition { get; set; }
        public int role { get; set; }
        public int headRole { get; set; }
        public bool isController { get; set; }
        public string? previousUserId { get; set; }
        public string? previousUserSurname { get; set; }
        public string? previousUserName { get; set; }
        public string? previousUserPatronymic { get; set; }
        public string? dateTimeOfReplacement { get; set; }
        //public string? forInformation { get; set; }
    }
}
