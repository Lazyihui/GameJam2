using System;
using UnityEngine;
using Sirenix.OdinInspector;

namespace GJ.A {

    [CreateAssetMenu(fileName = "So_Node_", menuName = "GJ/Node")]
    public class NodeSO : ScriptableObject {

        public NodeTM tm;

    }
}