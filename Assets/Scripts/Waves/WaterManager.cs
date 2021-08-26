using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class WaterManager : MonoBehaviour
{
    private MeshFilter meshFilter;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
    }

    // Update is called once per frame
    private void Update()
    {
        var vertices = meshFilter.mesh.vertices;
        for (var i = 0; i < vertices.Length; i++)
            vertices[i].y = WaveManager.instance.GetWaveHeight(transform.position.x + vertices[i].x);

        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.RecalculateNormals();
    }
}