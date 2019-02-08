#if NET35
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Markdig.Helpers
{
    internal static class LegacyHelper
    {
        [MethodImpl(MethodImplOptionPortable.AggressiveInlining)]
        public static bool HasFlag<TEnum>(this TEnum enumeration, TEnum flags) where TEnum : Enum
        {
            Debug.Assert(enumeration.GetType() == flags.GetType());
            ulong enumVal = Convert.ToUInt64(enumeration);
            ulong flagsVal = Convert.ToUInt64(flags);
            return (enumVal & flagsVal) == flagsVal;
        }
    }
}
#endif