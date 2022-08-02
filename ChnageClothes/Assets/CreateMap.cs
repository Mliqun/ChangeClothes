using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class CreateMap : MonoBehaviour
{
    public Image image;
    public static Texture map;
    public int num = 100;
    public Texture textureCao;
    public Texture textureTu;
    public Texture textureShui;
    public Texture2D mapCao;
    public Texture2D mapTu;
    public Button go;
    public GameObject yb;
    // Start is called before the first frame update
    Dictionary<Vector3, GameObject> maplist = new Dictionary<Vector3, GameObject>();
    void Start()
    {
        go.onClick.AddListener(() =>
        {
            yb.SetActive(true);
        });
        int w = num / 2;
        int h = num / 2;
        //����cube
        for (int x = -w; x <= w; x++)
        {
            for (int z = -h; z <= h; z++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(x, 0, z);
                cube.transform.localScale = new Vector3(1, 5, 1);
                cube.transform.parent = transform;
                maplist.Add(new Vector3(x, 0, z), cube);
            }
        }
        //���������̧��
        for (int i = 0; i < Random.Range(num * num / 7, num * num); i++)
        {
            //���̧��һ��
            Vector3 ran = new Vector3(Random.Range(-w, w), 0, Random.Range(-h, h));
            if (maplist.ContainsKey(ran))
            {
                maplist[ran].transform.position += Vector3.up * 0.5f;
            }
            //̧��ǰһ��
            Vector3 key = ran + new Vector3(0, 0, 1);
            if (maplist.ContainsKey(key))
            {
                maplist[key].transform.position += Vector3.up * 0.5f;
            }
            //̧��ǰ��һ��
            key = ran + new Vector3(1, 0, 1);
            if (maplist.ContainsKey(key))
            {
                maplist[key].transform.position += Vector3.up * 0.5f;
            }
            //̧��ǰ��һ��
            key = ran + new Vector3(-1, 0, 1);
            if (maplist.ContainsKey(key))
            {
                maplist[key].transform.position += Vector3.up * 0.5f;
            }
            //̧����һ��
            key = ran + new Vector3(1, 0, 0);
            if (maplist.ContainsKey(key))
            {
                maplist[key].transform.position += Vector3.up * 0.5f;
            }
            //̧����һ��
            key = ran + new Vector3(-1, 0, 0);
            if (maplist.ContainsKey(key))
            {
                maplist[key].transform.position += Vector3.up * 0.5f;
            }
            //̧�ߺ�һ��
            key = ran + new Vector3(0, 0, -1);
            if (maplist.ContainsKey(key))
            {
                maplist[key].transform.position += Vector3.up * 0.5f;
            }
            //̧�ߺ���һ��
            key = ran + new Vector3(1, 0, -1);
            if (maplist.ContainsKey(key))
            {
                maplist[key].transform.position += Vector3.up * 0.5f;
            }
            //̧�ߺ���һ��
            key = ran + new Vector3(-1, 0, -1);
            if (maplist.ContainsKey(key))
            {
                maplist[key].transform.position += Vector3.up * 0.5f;
            }
        }
        //��
        Material cao = new Material(Shader.Find("Standard"));
        cao.mainTexture = textureCao;
        //��
        Material tu = new Material(Shader.Find("Standard"));
        tu.mainTexture = textureTu;
        //ˮ
        Material shui = new Material(Shader.Find("MK4/Water"));
        shui.mainTexture = textureShui;
        //ѭ������cube��ɫ


        foreach (var item in maplist)
        {
            if (item.Value.transform.position.y > 1)
            {
                item.Value.GetComponent<MeshRenderer>().material = cao;
            }
            else if (item.Value.transform.position.y == 0)
            {
                //item.Value.GetComponent<MeshRenderer>().material = shui;
            }
            else
            {
                item.Value.GetComponent<MeshRenderer>().material = tu;
            }
        }
        //����
        StaticBatchingUtility.Combine(gameObject);
        ////����ͼƬ
        //Texture2D texture2D = new Texture2D(w * 2 + 1, h * 2 + 1, TextureFormat.ARGB32, false);
        ////ѭ�������������ص���ɫ
        //foreach (var item in maplist)
        //{
        //    Vector3 pos = item.Value.transform.position;
        //    texture2D.SetPixel((int)pos.x, (int)pos.z, new Color(pos.y, pos.y, pos.y));
        //}
        ////Ӧ�������޸�
        //texture2D.Apply(false);
        ////����ͼƬ
        //File.WriteAllBytes(Application.dataPath + "/map.png", texture2D.EncodeToPNG());



        //����ͼƬ
        Texture2D tex = new Texture2D((w * 2 + 1)*10 , (h * 2 + 1)*10, TextureFormat.ARGB32, false);
        //ѭ�������������ص���ɫ
        foreach (var item in maplist)
        {
            Vector3 pos = item.Value.transform.position + new Vector3((w * 2 + 1) / 2, 0, (w * 2 + 1) / 2);
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (pos.y > 1)
                    {
                        tex.SetPixel((int)pos.x * 10 + x, (int)pos.z * 10 + y, mapCao.GetPixel(x, y));
                    }
                    else if (pos.y == 0)
                    {
                        //tex.SetPixel((int)pos.x * 10 + x, (int)pos.z * 10 + y, Color.blue);
                    }
                    else
                    {
                        tex.SetPixel((int)pos.x * 10 + x, (int)pos.z * 10 + y, mapTu.GetPixel(x, y));
                    }
                }
            }
        }
        tex.Apply(false);
        File.WriteAllBytes(Application.dataPath + "/map.png", tex.EncodeToPNG());
        map = tex;
        image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
