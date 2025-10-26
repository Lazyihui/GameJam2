using System;
using UnityEngine;

namespace GJ.A {

    // 表达式类型枚举
    public enum MathType {
        None,//没有
        Number,     // 数字常量
        Variable,   // 变量
        Add,        // 加法
        Subtract,   // 减法
        Multiply,   // 乘法
        Divide      // 除法
    }
}