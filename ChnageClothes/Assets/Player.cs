using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CreateMap trr;
    public RectTransform map;//地图
    public RectTransform mapPlayer;//地图上的玩家

    float perX;
    float perY;
    float w;
    float h;
    // Start is called before the first frame update
    void Start()
    {
        w = (float)((trr.num / 2) * 2 + 1);
        h = (float)((trr.num / 2) * 2 + 1);
        perX = map.rect.width / w;
        perY = map.rect.width / h;
    }

    // Update is called once per frame
    void Update()
    {
        map.localScale += map.localScale * Input.GetAxis("Mouse ScrollWheel");//小地图缩小放大

        mapPlayer.localScale = new Vector3(1 / map.localScale.x, 1 / map.localScale.y, 1 / map.localScale.z);//人物在地图上缩小放大

        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * 5);//移动
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * 45);//旋转

        mapPlayer.anchoredPosition = new Vector2(transform.position.x * perX, transform.position.z * perY);
        mapPlayer.localEulerAngles = Vector3.forward * -transform.localEulerAngles.y;

        float x = (mapPlayer.anchoredPosition.x + (w / 2)) / w;
        float y = (mapPlayer.anchoredPosition.y + (h / 2)) / h;
        map.pivot = new Vector2(x, y);
    }
}
