using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{

    public GameObject wallPrefab;
    public Vector2 roomSize;
    public Vector2 wallSize;
    private int seed;

    private List<Transform> wallInstances;

    // Start is called before the first frame update
    void Start()
    {
        createWalls();
    }

    // Update is called once per frame
    void Update()
    {
        if (anyChanges()){
            createWalls();
        }
    }

void createWalls(){
    if (wallInstances != null && wallInstances.Count > 0){
        return;
    }

    wallInstances = new List<Transform>();

    // Generate walls on the x-axis
    int wallCountX = Mathf.Max(1, (int)(roomSize.x / wallSize.x));
    float scaleX = (roomSize.x / wallCountX) / wallSize.x;

    for (int i = 0; i < wallCountX; i++){
        var t = transform.position + new Vector3(-roomSize.x / 2 + wallSize.x * scaleX / 2 + i * scaleX * wallSize.x, 0, +roomSize.y / 2);
        var r = transform.rotation;
        var s = new Vector3(scaleX, 1, 1);

        var instance = Instantiate(wallPrefab, t, r);
        instance.transform.localScale = s;

        wallInstances.Add(instance.transform);
    }

    // Generate walls on the z-axis
    int wallCountZ = Mathf.Max(1, (int)(roomSize.y / wallSize.x));
    float scaleZ = (roomSize.y / wallCountZ) / wallSize.x;

    for (int i = 0; i < wallCountZ; i++){
        var t = transform.position + new Vector3(+roomSize.x / 2, 0, -roomSize.y / 2 + wallSize.x * scaleZ / 2 + i * scaleZ * wallSize.x);
        var r = Quaternion.Euler(0, 90, 0);
        var s = new Vector3(scaleZ, 1, 1);

        var instance = Instantiate(wallPrefab, t, r);
        instance.transform.localScale = s;

        wallInstances.Add(instance.transform);
    }
}

    bool anyChanges(){
        if (wallInstances == null)
            return true;

        if (wallInstances.Count != transform.childCount / 2)
            return true;

        return false;
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, new Vector3(roomSize.x, 1f, roomSize.y));
    }
}
