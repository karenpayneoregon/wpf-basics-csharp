using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Example3.Classes
{
    public class TaskItem : INotifyPropertyChanged
    {
        private string _description;
        private string _taskName;
        private int _priority;

        public string TaskName
        {
            get => _taskName;
            set
            {
                if (value == _taskName) return;
                _taskName = value;
                OnPropertyChanged();
            }
        }
        public string Description 
        {
            get => _description;
            set
            {
                if (value == _description) return;
                _description = value;
                OnPropertyChanged();
            }
        }
        
        public TaskType TaskType { get; set; }
        public int Priority
        {
            get => _priority;
            set
            {
                if (value == _priority) return;
                _priority = value;
                OnPropertyChanged();
            }
        }

        public override string ToString() => TaskName;
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
