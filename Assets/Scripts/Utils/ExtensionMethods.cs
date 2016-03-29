using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class ExtensionMethods {

    // Transform methods
    public static void CopyPosition(this Transform trans, Transform other) {
        trans.position = other.position;
    }

    public static void CopyYScale(this Transform trans, Transform other) {
        trans.localScale = new Vector3(trans.localScale.x, other.localScale.y, trans.localScale.z);
    }

    public static bool ContainTag(this Transform t, string tag) {
        Regex tagRE = new Regex(".*" + tag + ".*");
        return tagRE.Match(t.tag).Success;
    }

    // Collider2D methods
    public static bool ContainTag(this Collider2D coll, string tag) {
        Regex tagRE = new Regex(".*" + tag + ".*");
        return tagRE.Match(coll.tag).Success;
    }

    // Dictionary<string, object>
    public static void Log(this Dictionary<string, object> dic) {
        Debug.Log("Printing dic");
        foreach(object o in dic) {
            Debug.Log(o.ToString());
        }
    }

    // SpriteRender
    public static void SetAlpha(this SpriteRenderer sr, float newAlpha) {
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, newAlpha);
    }

    public static bool ContainTag(this SpriteRenderer sr, string tag) {
        Regex tagRE = new Regex(".*" + tag + ".*");
        return tagRE.Match(sr.tag).Success;
    }

    // GameObject
    public static void SetParent(this GameObject go, GameObject parent) {
        go.transform.parent = parent.transform;
        go.transform.localPosition = Vector3.zero;
    }

    public static void SetParent(this GameObject go, Transform parent) {
        go.transform.parent = parent;
        go.transform.localPosition = Vector3.zero;
    }

    public static GameObject AddChild(this GameObject go, string name) {
        GameObject child = new GameObject(name);
        child.transform.parent = go.transform;
        child.transform.localPosition = Vector3.zero;
        return child;
    }

    public static bool ContainTag(this GameObject go, string tag) {
        Regex tagRE = new Regex(".*" + tag + ".*");
        return tagRE.Match(go.tag).Success;
    }

    public static GameObject AddChild(this GameObject go, string name, string folderName, string spriteName) {
        GameObject child = go.AddChild(name);
        //SpriteRenderer sr = child.AddComponent<SpriteRenderer>();
        //sr.sprite = Sprites.Get(folderName, spriteName);
        return child;
    }

    public static GameObject AddPrefabChild(this MonoBehaviour2 mb, GameObject prefab) {
        GameObject child = GameObject.Instantiate(prefab) as GameObject;
        child.transform.parent = mb.transform;
        child.transform.localPosition = Vector3.zero;
        return child;
    }
}
