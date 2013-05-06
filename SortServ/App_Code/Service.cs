using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    private static String key = "";
    static Guid myGuid = Guid.NewGuid();

    /// <summary> 
    /// This function is used to Generate a Key using the GUID class.
    /// </summary>
    /// <returns> return the String format of key created</returns> 

    public string GetKey()
    {
        key = myGuid.ToString();
        return key;
    }

    /// <summary> 
    /// This function is used to break the array into parts and send to total merge function
    /// </summary>
    /// <param name="query">input array to be sorted</param>
    /// <returns> sorted array from the total merge function which sorts and merge's two array subparts</returns> 

    private int[] mergesortLocal(int[] input)
    {

        if (input.Length < 2)
        {
            return input;
        }

        int midValue = (input.Length) / 2;
        int[] leftsubPart = new int[midValue];
        int[] rightSubPart = new int[input.Length - midValue];

        Array.Copy(input, 0, leftsubPart, 0, leftsubPart.Length);
        Array.Copy(input, midValue, rightSubPart, 0, rightSubPart.Length);

        mergesortLocal(leftsubPart);
        mergesortLocal(rightSubPart);

        return totalMerge(input, leftsubPart, rightSubPart);

    }
    /// <summary> 
    /// This function is used to find an instance of a single song
    /// </summary>
    /// <param name="input">input array in which numbers will be sorted</param>
    /// <param name="leftPart">left part of partition</param>
    /// <param name="rightPart">right part of the partition</param>
    /// <returns> return the merged and sorted array</returns> 
    private int[] totalMerge(int[] input, int[] leftPart, int[] rightPart)
    {
        int inputIndex = 0;
        int leftIndex = 0;
        int rightIndex = 0;

        while (leftIndex < leftPart.Length && rightIndex < rightPart.Length)
        {
            if (leftPart[leftIndex] <= rightPart[rightIndex])
            {
                input[inputIndex] = leftPart[leftIndex];
                inputIndex++;
                leftIndex++;
            }
            else
            {
                input[inputIndex] = rightPart[rightIndex];
                inputIndex++;
                rightIndex++;
            }
        }

        while (leftIndex < leftPart.Length)
        {
            input[inputIndex] = leftPart[leftIndex];
            inputIndex++;
            leftIndex++;
        }

        while (rightIndex < rightPart.Length)
        {
            input[inputIndex] = rightPart[rightIndex];
            inputIndex++;
            rightIndex++;
        }

        return input;
    }

    /// <summary> 
    /// This function is used to covert string of numbers into array of integers
    /// </summary>
    /// <param name="input">String of numbers</param>
    /// <returns> Array of numbers returned</returns> 

    private int[] stringToIntArray(String input)
    {
        String[] arr = input.Split(' ');
        int[] newArr = new int[arr.Length];
        int count = 0;
        foreach (var a in arr)
        {
            newArr[count] = Convert.ToInt32(a);
            count++;
        }
        return newArr;
    }

    /// <summary> 
    /// This function is used to covert array of integers into string of numbers
    /// </summary>
    /// <param name="input">Array of integers (input)</param>
    /// <returns> String of numbers returned</returns> 

    private string intArrayToString(int[] input)
    {
        string output = "";

        foreach (var integer in input)
        {
            output = output + Convert.ToString(integer) + " ";
        }
        return output;
    }

    /// <summary> 
    /// This function is used to find call merge sort as a service
    /// </summary>
    /// <param name="input">String of numbers sent</param>
    /// <param name="userKey">the key returned by the user</param>
    /// <returns> return the String format of numbers sorted using mergesort</returns> 

    public string mergeSort(string input, String userKey)
    {
        string outputString = "";
        if (key.Equals(userKey))
        {

            int[] arrTobeSorted = stringToIntArray(input);
            int[] sortedArray = mergesortLocal(arrTobeSorted);
            outputString = intArrayToString(sortedArray);
        }
        else
        {
            outputString = "Invalid Key";
        }
        return outputString;

    }

    /// <summary> 
    /// This function is used to find sort an array of integers
    /// </summary>
    /// <param name="input">Array of integers to be sorted</param>
    /// <param name="start">Start value</param>

    private void selectionSortLocal(int[] input, int start)
    {
        if (start < input.Length - 1)
        {
            swap(input, start, findMinimumPosition(input, start));
            selectionSortLocal(input, start + 1);
        }
    }

    /// <summary> 
    /// This function is used to find the smallest number in the array
    /// </summary>
    /// <param name="input">Array of integers to be sorted</param>
    /// <param name="start">Start value</param>
    /// <returns> return the smallest int</returns> 

    private int findMinimumPosition(int[] input, int start)
    {
        int minimumPosition = start;
        for (int i = minimumPosition + 1; i < input.Length; i++)
        {
            if (input[i] < input[minimumPosition])
            {
                minimumPosition = i;
            }
        }
        return minimumPosition;
    }

    /// <summary> 
    /// This function is used to swap two numbers
    /// </summary>
    /// <param name="input">Array of integers to be sorted</param>
    /// <param name="index1">index of the 1nd number to be sorted</param>
    /// <param name="index2">index of the 2nd number to be sorted</param>

    private void swap(int[] input, int index1, int index2)
    {
        int tempHolder = input[index1];
        input[index1] = input[index2];
        input[index2] = tempHolder;
    }

    /// <summary> 
    /// This function is used to find call merge sort as a service
    /// </summary>
    /// <param name="input">String of numbers sent</param>
    /// <param name="userKey">the key returned by the user</param>
    /// <returns> return the String format of numbers sorted using mergesort</returns> 

    public string selectionSort(string input, String userKey)
    {
        string outputString = "";

        if (userKey.Equals(key))
        {

            int[] inputArr = stringToIntArray(input);

            selectionSortLocal(inputArr, 0);

            outputString = intArrayToString(inputArr);

        }
        else
        {
            outputString = "Invalid Key !";
        }
        return outputString;
    }
	
}
