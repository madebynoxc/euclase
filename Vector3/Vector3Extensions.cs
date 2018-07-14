using System.Collections.Generic;
using UnityEngine;
using Euclase.ECollections;

namespace Euclase.EVector3 {
    public static class Vector3Extensions {

        public static Vector3 Lerp(this Vector3 v3, Vector3 target, float speed) {
            return Vector3.Lerp(v3, target, speed);
        }

        public static Vector3 Sum(this IEnumerable<Vector3> source) {
            return new Vector3(
                source.Sum(s => s.x),
                source.Sum(s => s.y),
                source.Sum(s => s.z));
        }

        public static Vector3 Mean(this IEnumerable<Vector3> source) {
            var sum = source.Sum();
            var c = source.Count();
            return new Vector3(
                sum.x / c,
                sum.y / c,
                sum.z / c);
        }

        public static Vector3 Mul(this Vector3 v3, int x = 1, int y = 1, int z = 1) {
            return new Vector3(
                v3.x * x,
                v3.y * y,
                v3.z * z);
        }

        public static Vector3 Mul(this Vector3 v3, Vector3 target) {
            return new Vector3(
                v3.x * target.x,
                v3.y * target.y,
                v3.z * target.z);
        }

    }
}
