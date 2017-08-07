using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HierarchyObject {

    //Hierarchy上のGameObjectのパスを取得する
    public static string GetObjectPath(Transform transform)
    {
        if (transform.parent == null) return "";
        return transform.parent.parent != null
            ? GetObjectPath(transform.parent) + "/" + transform.name
            : transform.name;
    }
    
    //自分と全ての子のTransformを取得する
    public static IEnumerable<Transform> GetTransforms(Transform transform)
    {
        var transforms = new List<Transform> {transform};
        transforms.AddRange(transform.Cast<Transform>());
        return transforms;
    }
}