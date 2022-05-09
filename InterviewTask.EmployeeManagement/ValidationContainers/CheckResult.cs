using InterviewTask.EmployeeManagement.Enums;

namespace InterviewTask.EmployeeManagement.ValidationContainers
{
    public class CheckResult<T>
    {
        public CheckResultEnum Status { get; set; }

        public T Result { get; set; }
    }
}
