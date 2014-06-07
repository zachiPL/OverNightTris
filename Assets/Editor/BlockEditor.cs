using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(BlockBehaviour))]
public class BlockEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Rotate!"))
        {
            (target as BlockBehaviour).Rotate();
        }
        if (GUILayout.Button("Normalize!"))
        {
            (target as BlockBehaviour).Normalize();
        }
        if (GUILayout.Button("FixInner!"))
        {
            BlockBehaviour _t = target as BlockBehaviour;
            _t.inner = new GameObject[_t.transform.childCount];
            for (int i = 0; i < _t.transform.childCount; i++)
            {
                _t.inner[i] = _t.transform.GetChild(i).gameObject;
            }
        }
    }
}
