using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coffee;
using static Coffee.Utility;

namespace Coffee
{
    class Shop
    {
        //List of beverages available in the shop
        private List<Beverage> beverages = new List<Beverage>
        {
          new Beverage("Double Latte", Beverage.BeverageType.Coffee, Beverage.TemperatureState.Hot, 70),
          new Beverage("Decaf Coffee", Beverage.BeverageType.Coffee, Beverage.TemperatureState.Hot, 75),
          new Beverage("Iced Cappuccino", Beverage.BeverageType.Coffee, Beverage.TemperatureState.Cold, 5),
          new Beverage("Ice Water", Beverage.BeverageType.Water, Beverage.TemperatureState.Cold, 2)
        };

        // simulate opening the shop
        public void OpenShop()
        {
            foreach (Beverage beverage in beverages)
            {
                beverage.TemperatureChanged += Beverage_TemperatureChanged;
            }

            SimulateTemperatureChanges();
        }


        private void Beverage_TemperatureChanged(object sender, TemperatureChangedEventArgs e)
        {
            Beverage beverage = sender as Beverage;
            Console.WriteLine($"{beverage.Name}'s temperature changed from {e.OldTemperature}° to {e.NewTemperature}°.");
        }

        // simulate temperature changes multiple times
        private void SimulateTemperatureChanges()
        {
            for (int i = 0; i < 5; i++)
            {
                foreach (Beverage beverage in beverages)
                {
                    beverage.AdjustTemperature();
                    Thread.Sleep(500);
                }

                Print("--------------------------");
            }
        }
    }
}