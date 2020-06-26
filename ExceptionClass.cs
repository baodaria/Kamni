using System;
using System.Collections.Generic;
using System.Text;

namespace Kamni
{
    static public class ExceptionClass
    {
        static public void CheckTheOperatorAndOperand(int oper)
        {
            if (oper == 0)
            {
                throw new CheckWrittennumbers("Введен неправильный оператор или операнд. Попробуйте снова: ");
            }
        }

        static public void CheckFinishNumber(int number)
        {
            if (number <= 1)
            {
                throw new CheckNumberException("Количество камней для победы не может быть меньше 1ого. Попробуйте снова: ");
            }
        }

        static public void CheckVariant(string firstvar, string secondvar)
        {
            if (firstvar == secondvar)
            {
                throw new CheckVariantException("Такой вариант уже есть. Попробуйте снова: ");
            }
        }

        static public void CheckVariant(string firstvar, string secondvar, string thirdvar)
        {
            if (thirdvar == firstvar || thirdvar == secondvar)
            {
                throw new CheckVariantException("Такой вариант уже есть. Попробуйте снова: ");
            }
        }
    }
}
