public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Declare variable to hold the array of multiples of the number.
        // The array is declared with the double data type, to be able to contain decimal numbers with precision.
        var multiples = new double[length];

        // Step 2: Make a loop based on the given length and fill the array with the multiples of the number.
        for (int i = 0; i < length; i++)
        {
            // Step 3: To store each multiple in the x position of the array, the number must be multiplied by (x+1). This is because the indices start at 0 in C#; however, to calculate the natural multiple, it must start at 1.
            // This expression must be enclosed in a parenthesis because if it is not, the result will not be correct, for example (7 * 0 + 1) = 1 (7*(0+1)) = 7
            multiples[i] = number * (i + 1);
        }

        // Step 4: Return the array with the multiples set for the chosen number.
        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Check if the list is empty, if it is, return void.
        if (data.Count == 0) return;

        // Step 2: Calculate rotation amount, to check if the amount that is being passed does not exceed the list size to avoid possible errors.
        int rotationAmount = amount % data.Count;

        // Step 3: Check if the rotation amount is 0, if it is, the list will not be rotated, since it will be in the same position.
        if (rotationAmount == 0) return;

        // Step 4: Create a new list with the data that will be removed from the original list. This process will be done by calculating the starting index, which is the list size minus the rotation amount, and the amount of elements to be removed, which is the rotation amount.
        List<int> removedData = data.GetRange(data.Count - rotationAmount, rotationAmount);

        // Step 5: Remove the rotated data from the original list. This process is done by calculating the starting index, which is the list size minus the rotation amount, and the amount of elements to be removed, which is the rotation amount(Basically the same logic as in step 4).
        data.RemoveRange(data.Count - rotationAmount, rotationAmount);

        // Step 6: Insert the removed data or the rotated data in the original list. It's necessary to insert the data at the beginning of the list (index 0), since the list is being rotated.
        data.InsertRange(0, removedData);
    }
}
