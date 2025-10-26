using System;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace GJ.A {

    [Serializable]
    public class NodeTM {

        public bool isNode;
        [ShowIf("isNode")] public NodeData nodeData;
        public bool isRoot;
        [ShowIf("isRoot")] public RootData rootData;


        // 新增：存储子节点引用
        [ShowIf("@(isNode && nodeData.leftValueType == ValueType.Expression) || isRoot")]
        [Header("子节点列表")]
        public List<NodeSO> children;
    }
}