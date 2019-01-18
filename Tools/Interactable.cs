using UnityEngine.EventSystems;

namespace Euclase.Tools {

    //
    //Extend this to have interactable object
    //Requires Physics Raycaster to be attached to the Camera
    //
    public abstract class Interactable : EBase, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler {

        public abstract void OnPointerDown(PointerEventData eventData);
        public abstract void OnPointerEnter(PointerEventData eventData);
        public abstract void OnPointerExit(PointerEventData eventData); 

    }
}
