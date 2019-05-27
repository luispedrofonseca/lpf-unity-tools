using UnityEngine;
using System.Collections;

public static class MoreRandom
{
    public static int GetUniqueRandom(int min, int max, ref int prev)
    {
        var hasFoundUniqueRandomSelection = false;
        var tempSectionNum = 0;

        while (!hasFoundUniqueRandomSelection)
        {
            tempSectionNum = Random.Range(min, max);

            if (tempSectionNum != prev)
            {
                hasFoundUniqueRandomSelection = true;
                prev = tempSectionNum;
            }
        }
        return tempSectionNum;
    }
}