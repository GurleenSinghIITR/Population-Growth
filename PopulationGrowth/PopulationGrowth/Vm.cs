using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PopulationGrowth
{
    class Vm : INotifyPropertyChanged
    {
        public const decimal CENT = 100;   
        decimal count;
        public decimal Count { get { return count; } set { count = value; NotifyChange(); } }

        decimal rate;
        public decimal Rate { get { return rate; } set { rate = value; NotifyChange(); } }

        decimal days;
        public decimal Days { get { return days; } set { days = value; NotifyChange(); } }

        decimal death;
        public decimal Death { get { return death; } set { death = value; NotifyChange(); } }

        string disaster;
        public string Disaster { get { return disaster; } set { disaster = value; NotifyChange(); } }

        object destruct;
        public Object Destruct { get { return destruct; } set { destruct = value; NotifyChange(); } }

        List<People> peeps = new List<People>();    /// Binding of the Listbox Item Source
        public List<People> Peeps
        { get { return peeps; }  set { peeps = value; NotifyChange(); } }

        
        public void Shew()
        {
            List<People> _peeps = new List<People>();
            decimal Counts = Count;
            for (int i = 0; i < Days; i++)  ///Caculate with birth and death rate
            {
                Counts += Counts * (Rate - Death) / CENT;

                People thing = new People
                {
                    Message = $"Population on day {i+1} is",
                    Value = Math.Round(Counts)
                };
                _peeps.Add(thing);
            }
            Peeps = _peeps;
        }

        public void Shoot()  /// Method for the Catastrophe Click Button
        {
            decimal dToll=0;
            Random r = new Random();    /// Random Integer to introduce Disasters
            int deads = r.Next(1, 4);
            switch(deads)
            {
                case 1:
                    dToll = 5;
                    Disaster = "Earthquake will kill at 5% Rate";
                    Destruct = "Disaster1.jpg";
                    break;
                case 2:
                    dToll = 10;
                    Disaster = "Hurricane will kill at 10% rate";
                    Destruct = "Disaster2.jpg";
                    break;
                case 3:
                    dToll = 15;
                    Disaster = "Plague with kill at 15% rate";
                    Destruct = "Disaster3.jpg";
                    break;
            }
            List<People> _peeps = new List<People>();
            decimal Counts = Count;
            for (int i = 0; i < Days; i++)  ///Calculate with the birth rate ,death rate and death toll
            {
                Counts += Counts * (Rate - Death - dToll) / CENT;

                People thing = new People
                {
                    Message = $"Population on day {i + 1}",
                    Value = Math.Round(Counts)
                };
                _peeps.Add(thing);
            }
            Peeps = _peeps;
        }

        public void Resets()    ///resets everything
        {
            Count = 0;
            Days = 0;
            Death = 0;
            Rate = 0;
            Disaster = " ";
            Destruct = " ";
            Peeps = null;
        }

        public void Saves() /// saves it to the file output.txt
        {
            string saveString = "";
            foreach (People  thing in Peeps)
                saveString += thing.ToString();
            File.AppendAllText("output.txt", saveString);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyChange([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
