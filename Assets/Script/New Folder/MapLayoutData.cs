using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapLayoutData", menuName = "Game/MapLayoutData")]
public class MapLayoutData : ScriptableObject
{
    [Serializable]
    public class ObjectPlacement
    {
        public GameObject prefab;
        public Vector3 position;
        public Vector3 eulerRotation;
        public Vector3 scale = Vector3.one;
    }

    public List<ObjectPlacement> placements = new();
}
