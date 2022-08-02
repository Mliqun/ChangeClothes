using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMesh : MonoBehaviour
{
    public Texture2D texture2D;
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;
    public Texture texture;
    void Start()
    {
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        VertexHelper vh = new VertexHelper();
        for (int x = 0; x < texture2D.width; x++)
        {
            for (int z = 0; z < texture2D.height;z++)
            {
                float y = texture2D.GetPixel(x, z).grayscale * 20;
                vh.AddVert(new Vector3(x, y, z), Color.red,new Vector4((float)x/ (texture2D.width-1f), (float)z / (texture2D.width - 1f)));
            }
        }
        for (int x= 0; x < texture2D.width-1; x++)
        {
            for (int z = 0; z < texture2D.height - 1; z++)
            {
                vh.AddTriangle((texture2D.height * x) + z, (texture2D.height * x) + z + 1, (texture2D.height * (x + 1) + z + 1));
                vh.AddTriangle((texture2D.height * x) + z, (texture2D.height * (x+1)) + z + 1, (texture2D.height * (x + 1) + z ));
            }
        }
        Mesh mesh = new Mesh();
        vh.FillMesh(mesh);
        meshFilter.mesh = mesh;
        mesh.RecalculateBounds();
        Material material = new Material(Shader.Find("Standard"));
        material.mainTexture = texture;
        meshRenderer.material = material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
