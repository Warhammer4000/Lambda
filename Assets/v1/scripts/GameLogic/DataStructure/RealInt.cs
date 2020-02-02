using System;
using DTD.Calculator.Core;

namespace BrainJam2020
{
    
    public struct RealInt : IOperatorOverLoaded
    {
        public int Value { get; }

        public RealInt(int value=0)
        {
            Value = value;
        }

        public static RealInt operator +(RealInt left, RealInt right)
        {
            return new RealInt(left.Value+right.Value);
        }

        public static RealInt operator -(RealInt left, RealInt right)
        {
            return new RealInt(left.Value - right.Value);
        }

        public static RealInt operator *(RealInt left, RealInt right)
        {
            return new RealInt(left.Value * right.Value);
        }

        public static RealInt operator /(RealInt left, RealInt right)
        {
            return new RealInt(left.Value / right.Value);
        }

        public static RealInt operator %(RealInt left, RealInt right)
        {
            return new RealInt(left.Value % right.Value);
        }

        public override string ToString() => Value.ToString();

        public void PlsOverLoad()
        {
            
        }

    }
}
