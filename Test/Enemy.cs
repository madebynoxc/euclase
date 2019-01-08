using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Euclase.Test {
    public class Enemy : EBase {

        public bool IsActive;
        public bool CanBeSpotted;

        private void Update() {
            CanBeSpotted = UnityEngine.Random.Range(0, 2) == 0;
        }

    }
}
