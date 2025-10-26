using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GJ.A {

    [Serializable]
    public struct NodeData {
        public ValueType leftValueType;
        public MathType expressionType;
        public ValueType rightValueType;

    }
}