using System;

namespace Stegano
{
    class ParametersGenerator
    {
        public static string[] ArrayCombination(string[][] parameters)
        {
            if(parameters.Length == 0)
            {
                throw new Exception("Parameters must have at list one array");
            }  
            return ArrayCombinationRecursive(parameters);
        }

        private static string[] ArrayCombinationRecursive(string[][] parameters)
        {
            if (parameters.Length == 1)
            {
                return parameters[0];
            }
            string[][] newParameters = new string[parameters.Length-1][];
            for(int i = 0; i < newParameters.Length; i++)
            {
                newParameters[i] = parameters[i + 1];
            }
            string[] nextParameters = ArrayCombinationRecursive(newParameters);
            string[] result = new string[parameters[0].Length * nextParameters.Length];
            for (int i = 0; i < parameters[0].Length; i++)
            {
                for(int j = 0; j < nextParameters.Length; j++)
                {
                    result[i * nextParameters.Length + j] = parameters[0][i] + " " + nextParameters[j];
                }
            }
            return result;
        }

        public static string[] GetArray(string[] array1, string[] array2)
        {
            string[] result = new string[array1.Length*array2.Length];
            for (int i = 0; i < array1.Length; i++)
            {
                for (int j = 0; j < array2.Length; j++)
                {
                    result[i * array1.Length + j] = array1[i] + " " + array2[j];
                }
            }
            return result;
        }

        public static string[] OrderCombination(string[] parameters)
        {
            if (parameters.Length == 0)
            {
                throw new Exception("Parameters must have at list one element");
            }
            return OrderCombinationRecursive(parameters);
        }

        private static string[] OrderCombinationRecursive(string[] parameters)
        {
            string[] result = new string[Factorial(parameters.Length)];
            if(parameters.Length == 1)
            {
                return parameters;
            } else
            {
                for(int i = 0; i < parameters.Length; i++)
                {
                    string[] nextArray = OrderCombinationRecursive(SubArray(parameters, i));
                    for (int j = 0; j < nextArray.Length; j++)
                    {
                        result[i * nextArray.Length + j] = parameters[i] + " " + nextArray[j];
                    }
                }
            }
            return result;
        }

        private static string[] SubArray(string[] array, int position)
        {
            string[] subArray = new string[array.Length - 1];
            int sub = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i == position)
                {
                    sub = 1;
                }
                else
                {
                    subArray[i - sub] = array[i];
                }
            }
            return subArray;
        }

        private static int Factorial(int number)
        {
            int res = 1;
            for(int i = 2; i <= number; i++)
            {
                res *= i;
            }
            return res;
        }
    }
}
