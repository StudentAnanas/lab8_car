using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8_myCar
{
    [Serializable]
    public class Car
    {
        public string FIO;
        public string CodeMark;
        public string Marka;
        public string TypeB;
        public float Power;
        public float VmaxB;
        public float VB;
        public float VmaxM;
        public float VM;
        public Car()
        {

        }

        public Car(string fIO, string codeMark, string marka, string typeB, float power, float vmaxB, float vB, float vmaxM, float vM)
        {
            FIO = fIO;
            CodeMark = codeMark;
            Marka = marka;
            TypeB = typeB;
            Power = power;
            VmaxB = vmaxB;
            VB = vB;
            VmaxM = vmaxM;
            VM = vM;
        }
        public Car(Car car)
        {
            FIO = car.FIO;
            CodeMark = car.CodeMark;
            Marka = car.Marka;
            TypeB = car.TypeB;
            Power = car.Power;
            VmaxB = car.VmaxB;
            VB = car.VB;
            VmaxM = car.VmaxM;
            VM = car.VM;
        }
    }
}
