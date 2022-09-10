using UnityEngine;

namespace GDT.Core
{
    public static class ExtensionMethods
    {
        public static void FillArrayRandomly(this int[] array, int range)
        {
            if (array == null) return;
            
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Random.Range(1, range);
            }
        }

        public static Color SetSaturation(this Color color, int saturation)
        {
            Color.RGBToHSV(color, out float h, out float s, out float v);
            return Color.HSVToRGB(h, saturation * 0.01f, v);
        }
    }
}