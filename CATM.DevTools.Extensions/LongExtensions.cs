
namespace CATM.DevTools.Extensions
{
    public static class LongExtensions
    {
        public static bool Between(this long obj, long val1, long val2)
        {
            return (obj > val1 && obj < val2);
        }
    }
}
