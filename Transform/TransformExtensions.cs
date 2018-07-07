using Euclase.EVector3;
using System.Collections.Generic;
using UnityEngine;

namespace Euclase.ETransform {
    public static class TransformExtensions {

        public static Transform SetPos(this Transform tr, Vector3 pos) {
            tr.position = pos;
            return tr;
        }

        public static Transform SetLocalPos(this Transform tr, Vector3 pos) {
            tr.localPosition = pos;
            return tr;
        }

        public static Transform LerpPos(this Transform tr, Vector3 target, float speed) {
            return tr.SetPos(tr.position.Lerp(target, speed));
        }

        public static Transform LerpLocalPos(this Transform tr, Vector3 target, float speed) {
            return tr.SetLocalPos(tr.localPosition.Lerp(target, speed));
        }

        public static void ClearChildren(this Transform item) {
            var children = new List<GameObject>();
            foreach(Transform child in item)
                children.Add(child.gameObject);
            children.ForEach(child => Object.Destroy(child));
        }

    }
}
