using System.Collections.Generic;
using UnityEngine;

public class MapControl : MonoBehaviour
{
    [SerializeField] private MapLayoutData layoutData;

    private readonly List<GameObject> spawnedObjects = new();

    private void Start()
    {
        if (layoutData != null)
            ApplyLayout();
    }

    public void ApplyLayout()
    {
        foreach (var obj in spawnedObjects)
            if (obj != null) Destroy(obj);
        spawnedObjects.Clear();

        foreach (var p in layoutData.placements)
        {
            if (p.prefab == null) continue;
            var go = Instantiate(p.prefab, p.position, Quaternion.Euler(p.eulerRotation), transform);
            go.transform.localScale = p.scale;
            spawnedObjects.Add(go);
        }
    }

    // 런타임 중 레이아웃 교체
    public void ApplyLayout(MapLayoutData data)
    {
        layoutData = data;
        ApplyLayout();
    }
}
