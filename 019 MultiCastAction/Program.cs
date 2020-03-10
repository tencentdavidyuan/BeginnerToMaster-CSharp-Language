using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCastAction {
    /// <summary>
    /// 订阅者
    /// </summary>
    class Cooler {
        public Cooler(float temperature) {
            LimitTemperature = temperature;
        }

        public float LimitTemperature { get; set; }

        public void OnTemperatureChange(float temperature) {
            if (temperature > LimitTemperature) {
                Console.WriteLine("Cooler: On!");
            }
            else {
                Console.WriteLine("Cooler: Off!");
            }
        }
    }

    /// <summary>
    /// 订阅者
    /// </summary>
    class Heater {
        public Heater(float temperature) {
            LimitTemperature = temperature;
        }

        public float LimitTemperature { get; set; }

        public void OnTemperatureChange(float temperature) {
            if (temperature < LimitTemperature) {
                Console.WriteLine("Heat On!");
            }
            else {
                Console.WriteLine("Heat Off!");
            }
        }
    }

    /// <summary>
    /// 事件的发布者
    /// </summary>
    class Thermostat {
        private float _currentTemperatrue;

        /// <summary> 委托 </summary>
        public Action<float> OnTemperatureChange { get; set; }

        public float CurrentTemperature {
            get { return _currentTemperatrue; }
            set {
                _currentTemperatrue = value;
                OnTemperatureChange(value);
            }
        }
    }
    

    class Program {
        static void Main(string[] args) {
            Thermostat thermostat = new Thermostat();
            Heater heater = new Heater(60);
            Cooler cooler = new Cooler(80);

            thermostat.OnTemperatureChange += heater.OnTemperatureChange;
            thermostat.OnTemperatureChange += cooler.OnTemperatureChange;

            while (true) {
                var input = Console.ReadLine();
                thermostat.CurrentTemperature = int.Parse(input);
                Console.WriteLine("\n");
            }
        }
    }
}
