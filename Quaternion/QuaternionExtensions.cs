using UnityEngine;

namespace Euclase.EQuaternion {
    public static class QuaternionExtensions {

        public static Quaternion Lerp(this Quaternion source, Quaternion target, float speed) {
            return Quaternion.Lerp(source, target, speed);
        }

        public static Quaternion Slerp(this Quaternion source, Quaternion target, float speed) {
            return Quaternion.Slerp(source, target, speed);
        }

    }
}
