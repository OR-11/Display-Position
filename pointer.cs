using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class pointer : MonoBehaviour
{
    public float move = 1.3f;
    public float width = 0.3f;
    public float size;
    public Color color = new Color(0, 0, 0, 1);
    Vector3 Pos;
    public Vector3 p;
    public string position;
    Vector3 start;
    bool Numpoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);//SceneView.currentDrawingSceneView.camera.ScreenToWorldPoint(Event.current.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        Pos = transform.position + p;
        //drowline(transform.position, new Vector3(0, 0, 0), Color.red, 0);
        position = "X:" + transform.position.x.ToString() + " Y:" + transform.position.y.ToString();
        start = new Vector3(Pos.x - ((position.Length * size) + ((position.Length - 1) * width)), Pos.y);
        for (int c = 0; c < position.Length; c++)
        {
            if (position.Substring(c, 1) == ".") continue;

            if (position.Length - 1 >= c + 1) Numpoint = position.Substring(c + 1, 1) == ".";
            if (position.Substring(c, 1) == "X") X(start, Numpoint);
            if (position.Substring(c, 1) == "Y") Y(start, Numpoint);
            if (position.Substring(c, 1) == "1") Num1(start, Numpoint);
            if (position.Substring(c, 1) == "2") Num2(start, Numpoint);
            if (position.Substring(c, 1) == "3") Num3(start, Numpoint);
            if (position.Substring(c, 1) == "4") Num4(start, Numpoint);
            if (position.Substring(c, 1) == "5") Num5(start, Numpoint);
            if (position.Substring(c, 1) == "6") Num6(start, Numpoint);
            if (position.Substring(c, 1) == "7") Num7(start, Numpoint);
            if (position.Substring(c, 1) == "8") Num8(start, Numpoint);
            if (position.Substring(c, 1) == "9") Num9(start, Numpoint);
            if (position.Substring(c, 1) == "0") Num0(start, Numpoint);
            if (position.Substring(c, 1) == "-") minus(start, Numpoint);

            start.x += ((move * size) + (width * size));
        }
    }

    //  ------
    // |   2  |
    // |1     |3
    // |      |
    //  ------
    // |   4  |
    // |5     |6
    // |   7  |
    //  ------  |12

    //8   9
    //-   -
    // - -
    //  -
    // - -
    //-   -
    //10  11

    void minus(Vector3 pos, bool p)
    {
        n4(pos);
        if (p) n12(pos);
    }

    void X(Vector3 pos, bool p)
    {
        n8(pos);
        n9(pos);
        n10(pos);
        n11(pos);
        if (p) n12(pos);
    }

    void Y(Vector3 pos, bool p)
    {
        n8(pos);
        n9(pos);
        n10(pos);
        if (p) n12(pos);
    }

    void Num0(Vector3 pos, bool p)
    {
        n1(pos);
        n2(pos);
        n3(pos);
        n5(pos);
        n6(pos);
        n7(pos);
        if (p) n12(pos);
    }

    void Num1(Vector3 pos, bool p)
    {
        n3(pos);
        n6(pos);
        if (p) n12(pos);
    }

    void Num2(Vector3 pos, bool p)
    {
        n2(pos);
        n3(pos);
        n4(pos);
        n5(pos);
        n7(pos);
        if (p) n12(pos);
    }

    void Num3(Vector3 pos, bool p)
    {
        n2(pos);
        n3(pos);
        n4(pos);
        n6(pos);
        n7(pos);
        if (p) n12(pos);
    }

    void Num4(Vector3 pos, bool p)
    {
        n1(pos);
        n3(pos);
        n4(pos);
        n6(pos);
        if (p) n12(pos);
    }

    void Num5(Vector3 pos, bool p)
    {
        n2(pos);
        n1(pos);
        n4(pos);
        n6(pos);
        n7(pos);
        if (p) n12(pos);
    }

    void Num6(Vector3 pos, bool p)
    {
        n2(pos);
        n1(pos);
        n4(pos);
        n6(pos);
        n7(pos);
        n5(pos);
        if (p) n12(pos);
    }

    void Num7(Vector3 pos, bool p)
    {
        n2(pos);
        n3(pos);
        n6(pos);
        if (p) n12(pos);
    }

    void Num8(Vector3 pos, bool p)
    {
        n1(pos);
        n2(pos);
        n3(pos);
        n4(pos);
        n5(pos);
        n6(pos);
        n7(pos);
        if (p) n12(pos);
    }

    void Num9(Vector3 pos, bool p)
    {
        n1(pos);
        n2(pos);
        n3(pos);
        n4(pos);
        n6(pos);
        n7(pos);
        if (p) n12(pos);
    }


    void n2(Vector3 pos)
    {
        drowline(new Vector3((size / 2) + pos.x, size + pos.y, 0), new Vector3((-size / 2) + pos.x, size + pos.y, 0), color, 0);
    }

    void n1(Vector3 pos)
    {
        drowline(new Vector3((-size / 2) + pos.x, size + pos.y, 0), new Vector3((-size / 2) + pos.x, 0 + pos.y, 0), color, 0);
    }

    void n3(Vector3 pos)
    {
        drowline(new Vector3((size / 2) + pos.x, size + pos.y), new Vector3((size / 2) + pos.x, 0 + pos.y), color, 0, false);
    }

    void n4(Vector3 pos)
    {
        drowline(new Vector3((size / 2) + pos.x, 0 + pos.y), new Vector3((-size / 2) + pos.x, 0 + pos.y), color, 0, false);
    }

    void n5(Vector3 pos)
    {
        drowline(new Vector3((-size / 2) + pos.x, 0 + pos.y), new Vector3((-size / 2) + pos.x, -size + pos.y), color, 0, false);
    }

    void n6(Vector3 pos)
    {
        drowline(new Vector3((size / 2) + pos.x, -size + pos.y), new Vector3((size / 2) + pos.x, 0 + pos.y), color, 0, false);
    }

    void n7(Vector3 pos)
    {
        drowline(new Vector3((size / 2) + pos.x, -size + pos.y), new Vector3((-size / 2) + pos.x, -size + pos.y), color, 0, false);
    }

    void n8(Vector3 pos)
    {
        drowline(new Vector3(0 + pos.x, 0 + pos.y, 0), new Vector3((-size / 2) + pos.x, size + pos.y), color, 0, false);
    }

    void n9(Vector3 pos)
    {
        drowline(new Vector3(0 + pos.x, 0 + pos.y, 0), new Vector3((size / 2) + pos.x, size + pos.y), color, 0, false);
    }

    void n10(Vector3 pos)
    {
        drowline(new Vector3(0 + pos.x, 0 + pos.y, 0), new Vector3((-size / 2) + pos.x, -size + pos.y), color, 0, false);
    }

    void n11(Vector3 pos)
    {
        drowline(new Vector3(0 + pos.x, 0 + pos.y, 0), new Vector3((size / 2) + pos.x, -size + pos.y), color, 0, false);
    }

    void n12(Vector3 pos)
    {
        drowline(new Vector3((size / 2) + (width / 2) + pos.x, -size + pos.y), new Vector3((size / 2) + (width / 2) + pos.x, (-size / 3) + pos.y), color, 0, false);
    }


    void drowline(Vector3 start, Vector3 end, Color color, float time = 2, bool hide = true)
    {
        Debug.DrawLine(start, end, color, time, !hide);
    }
}
