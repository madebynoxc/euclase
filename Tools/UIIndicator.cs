using UnityEngine;

namespace Euclase.Tools {

    //
    //Extend this to have UI element follow an object in world
    //
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class UIIndicator : EBase {

        public Transform Target;

        public Camera TargetCamera {
            get {
                if(!_tgCamera)
                    _tgCamera = Camera.main;
                return _tgCamera;
            } set {
                _tgCamera = value;
            }
        }

        public bool IsVisible {
            get { return _isVisible; }
            set {
                _group.alpha = value ? 1 : 0;
                _isVisible = value;
            }
        }

        private Camera _tgCamera;
        private CanvasGroup _group;

        private bool _isVisible;

        private void Awake() {
            _group = GetComponent<CanvasGroup>();
        }

        private void LateUpdate() {
            if(!Target || !_isVisible)
                return;

            _group.alpha = (Transform.position.z > 0 && Target.gameObject.activeInHierarchy)? 1 : 0;
            Transform.position = TargetCamera.WorldToScreenPoint(Target.position);
            if(Transform.position.z > 100)
                Transform.position = new Vector3(Transform.position.x, Transform.position.y, 100);
        }
    }
}
