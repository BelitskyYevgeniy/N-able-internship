using System;
namespace sin_2
{
    class SinProgram
    {
        public interface IMath<T>
        {
            T NotNullDefault();
            void ConvertFromInt32(double value);
            T Abs();
            T Divide(T value);
            T Divide(double value);
            T Multy(T value);
            T Multy(double value);
            T Sum(T value);
        }
        private static T SinHelper<T>(T currentValue, T currentElement, int factorialBase, T x, T e) where T: IMath<T>, IComparable<T>
        {
            if (currentElement.Abs().CompareTo(e) < 0) return currentValue;
            int fbCopy = factorialBase;
            currentElement = currentElement.Multy(x).Multy(x).Divide(++factorialBase).Divide(++factorialBase);
            return SinHelper(currentValue.Sum(currentElement.Multy(((long)((fbCopy + 1) / 2) & 1) == 1 ? -1 : 1)), 
                currentElement, factorialBase, x, e);            
        }
        public static T Sin<T>(T x, T e) where T : IMath<T>, IComparable<T>, ICloneable
        {
            if (x == null || e == null)
                throw new ArgumentNullException();
            T start = (T)x.Clone();
            T startElement = (T)x.Clone();
            return SinHelper<T>(start, startElement, 1, x, e);
        }


        public class DoubleForSin : IMath<DoubleForSin>, IComparable<DoubleForSin>, ICloneable
        {
            private double _value;

            public DoubleForSin(double value)
            {
                _value = value;
            }

            public DoubleForSin Abs()
            {
                var clone = this.Clone() as DoubleForSin;
                clone._value = Math.Abs(_value);
                return clone;
            }

            public object Clone()
            {
                return new DoubleForSin(this._value);
            }

            public int CompareTo(DoubleForSin obj)
            {
                double difference = _value - obj._value;
                if (difference == 0)
                    return 0;
                return difference < 0? -1: 1;
            }


            public void ConvertFromInt32(double value)
            {
                _value = value;
            }

            public DoubleForSin Divide(DoubleForSin value)
            {
                return Divide(value._value).Clone() as DoubleForSin;
            }

            public DoubleForSin Divide(double value)
            {
                var clone = this.Clone() as DoubleForSin;
                clone._value /= value;
                return clone;
            }

            public DoubleForSin Multy(double value)
            {
                var clone = this.Clone() as DoubleForSin;
                clone._value *= value;
                return clone;
            }

            public DoubleForSin Multy(DoubleForSin value)
            {
                return Multy(value._value).Clone() as DoubleForSin;
            }

            public DoubleForSin NotNullDefault()
            {
                var clone = this.Clone() as DoubleForSin;
                clone._value = 0;
                return clone;
            }

            public DoubleForSin Sum(DoubleForSin value)
            {
                var clone = this.Clone() as DoubleForSin;
                clone._value += value._value;
                return clone;
            }
            public override string ToString()
            {
                return this._value.ToString();
            }

        }

        static void Main(string[] args)
        {
            DoubleForSin x = new DoubleForSin(Math.PI/2);
            DoubleForSin e = new DoubleForSin(0.000001);
            Console.WriteLine(Sin(x, e));
        }
    }
}
