using System;

namespace ControlePlantas.Domain.Core
{
    public static class ObjectHelper
    {
        public static bool IsNotNull(this object obj) => obj != null;    
        public static bool IsNull(this object obj) => obj == null;
        public static int AsInt(this object obj) => Convert.ToInt32(obj);
        public static decimal AsDecimal(this object obj) => Convert.ToDecimal(obj);
        public static bool AsBoolean(this object obj) => Convert.ToBoolean(obj);

    }
}
