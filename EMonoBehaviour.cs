using UnityEngine;

namespace Euclase {

    [RequireComponent(typeof(Transform))]
    public class EMonoBehaviour : MonoBehaviour {

        public Transform Transform {
            get {
                if(!_transform)
                    _transform = GetComponent<Transform>();
                return _transform;
            }
        }

        private Transform _transform;

    }
}
