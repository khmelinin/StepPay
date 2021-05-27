using System.ComponentModel;

namespace TransHistory.Models
{
    public class Transactions : INotifyPropertyChanged
    {
        private string receiver;
        private string sum;
        private string time;
        private string purpose;

        public string Receiver
        {
            get { return receiver; }
            set
            {
                receiver = value;
                OnPropertyChanged("Receiver");
            }
        }

        public string Sum
        {
            get { return sum; }
            set
            {
                sum = value;
                OnPropertyChanged("Sum");
            }
        }

        public string Time
        {
            get { return time; }
            set
            {
                time = value;
                OnPropertyChanged("Time");
            }
        }

        public string Purpose
        {
            get { return purpose; }
            set
            {
                purpose = value;
                OnPropertyChanged("Purpose");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
