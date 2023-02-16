namespace Bouvet_Task.Models
{
    public class TaskDetails
    {
        public Guid id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectManager { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string EpicName { get; set; }
        public string EpicDescription { get; set; }
        public string EpicResponsibility { get; set; }

    }
}
