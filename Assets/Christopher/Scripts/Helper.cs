using System;
using System.Collections.Generic;

public static class Helper{
    public enum Rarity {
        comon,
        uncomon,
        rare,
        epic,
        mythic
    }
    public static T SelectRandomIndexInArray<T>(IList<T> array) {
        Random random = new Random();
        int value = random.Next(0, array.Count-1);
        return array[value];
    }
}