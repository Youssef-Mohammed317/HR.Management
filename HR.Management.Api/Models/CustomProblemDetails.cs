using Microsoft.AspNetCore.Mvc;

namespace HR.Management.Api.Models
{
    public class CustomProblemDetails : ProblemDetails
    {
        public IDictionary<string, List<string>> Errors { get; set; } = new Dictionary<string, List<string>>();
    }
}