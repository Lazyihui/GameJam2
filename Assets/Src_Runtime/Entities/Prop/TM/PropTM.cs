using System;
using UnityEngine;
using GJ.A;
namespace GJ {

    [Serializable]
    public struct PropTM {
        public TypeID typeID;
        public string typeName;
        public float testField1;

        // 预制体绑定
        public GameObject entityPrefab;
        public ControllerSO[] controllerSOs;
    }
}