using UnityEngine;

namespace Caculator
{
    public class CaculatorLogic : ICaculatorLogic
    {
        public float Addition(params float[] numbers)
        {
            var result = 0f;
            foreach (var number in numbers)
            {
                result += number;
            }

            return result;
        }

        public float Subtraction(params float[] numbers)
        {
            var result = 0f;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == 0) result = numbers[i];
                else
                {
                    result -= numbers[i];
                }
            }
            
            return result;
        }
        
        public float Multiplication(params float[] numbers)
        {
            var result = 1f;
            foreach (var number in numbers)
            {
                result *= number;
            }
            
            return result;
        }
        
        public float Division(params float[] numbers)
        {
            var result = 1f;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == 0) result = numbers[i];
                else
                {
                    result /= numbers[i];
                }
            }

            return result;
        }
    }
}
