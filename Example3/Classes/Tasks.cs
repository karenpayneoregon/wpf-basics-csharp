using System.Collections.ObjectModel;

namespace Example3.Classes
{
    public class Tasks
    {
        public ObservableCollection<TaskItem> List()
        {
            return new ObservableCollection<TaskItem>()
            {
                new TaskItem()
                {
                    Priority = 2,
                    TaskType = TaskType.Work,
                    TaskName = "Unit test data operations",
                    Description = "Delegate to junior developer"
                },
                new TaskItem()
                {
                    Priority = 1,
                    TaskType = TaskType.Work,
                    TaskName = "Prototype dashboard",
                    Description = "Put together dashboard prototype"
                },
                new TaskItem()
                {
                    Priority = 1,
                    TaskType = TaskType.Home,
                    TaskName = "Cook dinner",
                    Description = "Ah, get a pizza"
                },
                new TaskItem()
                {
                    Priority = 3,
                    TaskType = TaskType.Work,
                    TaskName = "Single signon discussion",
                    Description = "Discuss options"
                }
            };
        }
    }
}