using System;

namespace ComplexNumber {

  public struct ComplexNumStruct {
    public double Real { get; }
    public double Imaginary { get; }

    //Constructor
    public ComplexNumStruct(double real, double imaginary) {

      Real = real;
      Imaginary = imaginary;
    }

    public override string ToString() =>
            $"({Real} { (Imaginary < 0 ? "-" : "+") } {Math.Abs(Imaginary)}i)";

    //overload the add operator
    public static ComplexNumStruct operator +(ComplexNumStruct x, ComplexNumStruct y) {

      return new ComplexNumStruct(x.Real + y.Real, x.Imaginary + y.Imaginary);

    }

    //overload the sub operator
    public static ComplexNumStruct operator -(ComplexNumStruct x, ComplexNumStruct y) {

      return new ComplexNumStruct(x.Real - y.Real, x.Imaginary - y.Imaginary);

    }

    //overload the mult operator
    public static ComplexNumStruct operator *(ComplexNumStruct x, ComplexNumStruct y) {

      return new ComplexNumStruct(x.Real * y.Real - x.Imaginary * y.Imaginary,
          x.Real * y.Real + x.Imaginary * y.Imaginary);

    }
  }
}
