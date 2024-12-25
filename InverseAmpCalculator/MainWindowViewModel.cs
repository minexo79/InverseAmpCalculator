using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InverseAmpCalculator
{
    public partial class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private double vInValue = 0;
        public double VInValue
        {
            get { return vInValue; }
            set
            {
                vInValue = value;
                CalculateVOut();
                OnPropertyChanged(nameof(VInValue));
            }
        }

        private double vRefValue = 0;
        public double VRefValue
        {
            get { return vRefValue; }
            set
            {
                vRefValue = value;
                CalculateVOut();
                OnPropertyChanged(nameof(VRefValue));
            }
        }

        private double r2Value = 0;
        public double R2Value
        {
            get { return r2Value; }
            set
            {
                r2Value = value;
                CalculateVOut();
                OnPropertyChanged(nameof(R2Value));
            }
        }

        private double r1Value = 0;
        public double R1Value
        {
            get { return r1Value; }
            set
            {
                r1Value = value;
                CalculateVOut();
                OnPropertyChanged(nameof(R1Value));
            }
        }


        private string vInValueDisp = "NULL";
        public string VInValueDisp
        {
            get { return vInValueDisp; }
            set
            {
                vInValueDisp = value;
                OnPropertyChanged(nameof(VInValueDisp));
            }
        }

        private string vOutValue = "NULL";
        public string VOutValue
        {
            get { return vOutValue; }
            set
            {
                vOutValue = value;
                OnPropertyChanged(nameof(VOutValue));
            }
        }

        public void CalculateVOut()
        {
            double vOut = VRefValue + ((1 + (R2Value / R1Value)) * (VRefValue - VInValue));
            VInValueDisp = $"{VInValue:F2} V";
            VOutValue = $"{vOut:F2} V";
        }

        public MainWindowViewModel()
        {

        }
    }
}
