using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json.Serialization;

namespace MoverAndStore.WebApp.Models
{
    public class TaskData
    {
        [JsonPropertyName("success")]
        public bool IsCompleted { get; set; }

        [JsonPropertyName("tasks")]
        public List<TaskList> TaskList { get; set; }
    }

    
    public class TaskList
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string  Description { get; set; }

        [JsonPropertyName("foreman_name")]
        public string? Foreman_Name { get; set; }

        [JsonPropertyName("complete")]
        public bool Status { get; set; }

        [JsonPropertyName("task_due_on")]
        public string? Task_Date { get; set;}
    }

    public class UpdateTask
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }

    public class UpdateTaskResponse
    {
        public bool success { get; set; }

        public string message { get; set; }
    }
}
