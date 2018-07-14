using UnityEngine;

namespace Euclase {

    [RequireComponent(typeof(Transform))]
    public class EBase : MonoBehaviour {

        public Transform Transform {
            get {
                if(!_transform)
                    _transform = GetComponent<Transform>();
                return _transform;
            }
        }

        private Transform _transform;

    }

    [RequireComponent(typeof(Rigidbody))]
    public class PhysicsEBase : EBase {

        public Rigidbody Rigidbody {
            get {
                if(!_rb)
                    _rb = GetComponent<Rigidbody>();
                return _rb;
            }
        }

        private Rigidbody _rb;

    }

    [RequireComponent(typeof(Rigidbody2D))]
    public class Physics2DEBase : EBase {

        public Rigidbody2D Rigidbody2D {
            get {
                if(!_rb)
                    _rb = GetComponent<Rigidbody2D>();
                return _rb;
            }
        }

        private Rigidbody2D _rb;

    }
}
