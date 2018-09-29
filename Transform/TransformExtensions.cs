using Euclase.EQuaternion;
using Euclase.EVector3;
using System.Collections.Generic;
using UnityEngine;

namespace Euclase.ETransform {
    public static class TransformExtensions {

        public static Transform SetPos(this Transform tr, Vector3 pos) {
            tr.position = pos;
            return tr;
        }

        public static Transform SetRot(this Transform tr, Quaternion rot) {
            tr.rotation = rot;
            return tr;
        }

        public static Transform SetLocalRot(this Transform tr, Quaternion rot) {
            tr.localRotation = rot;
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

        public static Transform SlerpPos(this Transform tr, Vector3 target, float speed) {
            return tr.SetPos(tr.position.Slerp(target, speed));
        }

        public static Transform SlerpLocalPos(this Transform tr, Vector3 target, float speed) {
            return tr.SetLocalPos(tr.localPosition.Slerp(target, speed));
        }

        public static Transform LerpRot(this Transform tr, Quaternion target, float speed) {
            return tr.SetRot(tr.rotation.Lerp(target, speed));
        }

        public static Transform LerpLocalRot(this Transform tr, Quaternion target, float speed) {
            return tr.SetLocalRot(tr.localRotation.Lerp(target, speed));
        }

        public static Transform SlerpRot(this Transform tr, Quaternion target, float speed) {
            return tr.SetRot(tr.rotation.Slerp(target, speed));
        }

        public static Transform SlerpLocalRot(this Transform tr, Quaternion target, float speed) {
            return tr.SetLocalRot(tr.localRotation.Slerp(target, speed));
        }

        public static Transform LerpLookAt(this Transform tr, Vector3 target, float speed) {
            var look = Quaternion.LookRotation(target - tr.position);
            return tr.SetRot(Quaternion.Slerp(tr.rotation, look, speed));
        }

        public static Transform LerpLookAt(this Transform tr, Vector3 target, Vector3 axis, float speed) {
            var look = Quaternion.LookRotation(target - tr.position);
            look.eulerAngles = new Vector3(
                axis.x * look.eulerAngles.x,
                axis.y * look.eulerAngles.y,
                axis.z * look.eulerAngles.z);
            return tr.LerpRot(look, speed);
        }

        public static Transform ClearChildren(this Transform item) {
            var children = new List<GameObject>();
            foreach(Transform child in item)
                children.Add(child.gameObject);
            children.ForEach(child => Object.Destroy(child));
            return item;
        }

    }
}
