using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee
{
    class Beverage
    {
        public enum BeverageType { Coffee, Tea, Water }
        public enum TemperatureState { Hot, Cold }

        public string Name { get; }
        public BeverageType Type { get; }
        public TemperatureState State { get; }
        private int temperature;

        // Event for temperature change
        public event EventHandler<TemperatureChangedEventArgs> TemperatureChanged;

        public Beverage(string name, BeverageType type, TemperatureState state, int initialTemperature)
        {
            Name = name;
            Type = type;
            State = state;
            Temperature = initialTemperature;
        }

        public int Temperature
        {
            get { return temperature; }
            set
            {
                if (temperature != value)
                {
                    int oldTemperature = temperature;
                    temperature = value;
                    OnTemperatureChanged(new TemperatureChangedEventArgs(oldTemperature, temperature));
                }
            }
        }

        // Event for the TemperatureChanged event
        protected virtual void OnTemperatureChanged(TemperatureChangedEventArgs e)
        {
            TemperatureChanged?.Invoke(this, e);
        }

        public void AdjustTemperature()
        {
            // Cold beverages heat up, hot beverages cool down
            Temperature += (State == TemperatureState.Cold) ? 5 : -5;
        }
    }

    public class TemperatureChangedEventArgs : EventArgs
    {
        public int OldTemperature { get; }
        public int NewTemperature { get; }

        public TemperatureChangedEventArgs(int oldTemp, int newTemp)
        {
            OldTemperature = oldTemp;
            NewTemperature = newTemp;
        }
    }

}
