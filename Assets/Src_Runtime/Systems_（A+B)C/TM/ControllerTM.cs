using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
namespace GJ.A {

    [Serializable]
    public struct ControllerTM {
        public List<NodeConnection> connections;
    }


    //     / 对于二元操作符节点：
    // - childIndex = 0 → 左操作数
    // - childIndex = 1 → 右操作数

    [Serializable]
    public struct NodeConnection {
        public NodeSO parentNode;    // 父节点
        public NodeSO childNode;     // 子节点
        public int childIndex;       // 子节点索引（用于多个子节点的情况）
    }
}