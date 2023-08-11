namespace testprog.PopupModule.Infrastructure.ApiDto
{
    public class TasksOfDocumentEntityDocumentInfo
    {
        public int type { get; set; }
        public string internalNumber { get; set; }
        public string? externalNumber { get; set; }
        public string summary { get; set; }
        public string dateInternalRegistration { get; set; }
        public string? dateExternalRegistration { get; set; }
        public int version { get; set; }
    }
}
