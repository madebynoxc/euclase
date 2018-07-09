using UnityEngine;

namespace Euclase.EObject {
    public static class ObjectExtensions {

        public static float Clamp(this float source, float from, float to) {
            return Mathf.Clamp(source, from, to);
        }

        public static float ClampAngle(this float angle, float from, float to) {
            if(angle < 0f)
                angle = 360 + angle;
            if(angle > 180f)
                return Mathf.Max(angle, 360 + from);
            return Mathf.Min(angle, to);
        }

        private static float GetAbsoluteAngle(this float ang) {
            if(ang > 180)
                ang = 360 - ang;
            return ang;
        }

        public static T Clone<T>(this T obj) {
            var inst = obj.GetType().GetMethod("MemberwiseClone", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            return (T)inst.Invoke(obj, null);
        }

    }
}
