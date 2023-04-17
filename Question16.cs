namespace NetFinalTestCodes
{
    
    // 1) Create a class to pass as an argument for the event handlers (EventArgs class)
    public class WeightChangedEventArgs : EventArgs
    {
        public double OldWeight { get; }
        public double NewWeight { get; }

        public WeightChangedEventArgs(double oldWeight, double newWeight)
        {
            OldWeight = oldWeight;
            NewWeight = newWeight;
        }
    }

    public class WeightSensor
    {
        // 2) Set up the delegate for the event
        public delegate void WeightChangedEventHandler(object sender, WeightChangedEventArgs e);

        // 3) Declare the code for the event
        public event WeightChangedEventHandler WeightChanged;

        private double _Weight;

        public double Weight
        {
            get => _Weight;
            set
            {
                if (_Weight != value)
                {
                    double oldWeight = _Weight;
                    _Weight = value;
                    // Trigger the event
                    WeightChanged?.Invoke(this, new WeightChangedEventArgs(oldWeight, _Weight));
                }
            }
        }
    }

    public class WeightMonitor
    {
        public WeightMonitor(WeightSensor sensor)
        {
            // 5) Associate the event with the event handler
            sensor.WeightChanged += OnWeightChanged;
        }

        // 4) Create code that will be run when the event occurs (Event Handler)
        private void OnWeightChanged(object sender, WeightChangedEventArgs e)
        {
            Console.WriteLine($"Weight changed from {e.OldWeight} to {e.NewWeight}");
        }
    }


}