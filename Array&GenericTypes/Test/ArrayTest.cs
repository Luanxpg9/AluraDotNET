namespace Array_GenericTypes.ArrayTest;
internal class ArrayTest
{

    //Array samples = Array.CreateInstance(typeof(double), 5);
    readonly Array samples = new double[5];

    public ArrayTest()
    {
        samples.SetValue(9.5, 0);
        samples.SetValue(8.5, 1);
        samples.SetValue(7.9, 2);
        samples.SetValue(7.7, 3);
        samples.SetValue(6.4, 4);
    }

    public double? Median()
    {
        if (samples == null || samples.Length == 0)
        {
            Console.WriteLine("Empty or null array");
            return null;
        }

        double[] orderedList = (double[]) samples.Clone();
        Array.Sort(orderedList);

        int size = orderedList.Length;
        int half = size / 2;

        double median = (size % 2 != 0) ? orderedList[half] : orderedList[half] + orderedList[half - 1] / 2;

        Console.WriteLine($"Median is {median} at position {half + 1}");
        return median;
    }
}
