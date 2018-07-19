using System;
using UnityEngine;

namespace Euclase.ESingle {
    public static class SingleExtensions {
        public static Single Clamp(this Single source, Single from, Single to) {
            return Mathf.Clamp(source, from, to);
        }

        public static Single ClampAngle(this Single angle, Single from, Single to) {
            angle = angle.GetPositiveAngle();
            if(angle > 180f)
                return Mathf.Max(angle, 360 + from);
            return Mathf.Min(angle, to);
        }

        public static Single GetAbsoluteAngle(this Single ang) {
            if(ang > 180)
                ang = 360 - ang;
            return ang;
        }

        public static Single GetPositiveAngle(this Single angle) {
            if(angle < 0f)
                angle = 360 + angle;
            return angle;
        }
    }
}
