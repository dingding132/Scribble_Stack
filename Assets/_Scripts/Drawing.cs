using UnityEngine;
using System.Collections;

public class Drawing : MonoBehaviour
{
    int i;
    int i2;
    Color c;
    float f;

    int sw;
    int sh;

    float mx;
    float my;

    int px;
    int py;

    //drop a texture into the inpector 
    //in the texture import settings you must set the type to "advanced"
    //and then set "read/write" to true!!!!!!!

    public Texture2D original;

    Texture2D myimage;

    public int brush;
    public int erase;
    int oldp;

    public Color drawcolor;



    void Start()
    {

        if (original == null) { original = new Texture2D(400, 300); }

        // change these next three variables to whatever you want!!!
        drawcolor = Color.red;
        brush = 6;
        erase = 20;

        //copy our original into our new paintable image 
        myimage = new Texture2D(original.width, original.height);

        i = original.width;
        while (i > 0)
        {
            i--;
            i2 = original.height;
            while (i2 > 0)
            {
                i2--;
                c = original.GetPixel(i, i2);
                myimage.SetPixel(i, i2, c);
            }
        }

        myimage.Apply();
        myimage.filterMode = FilterMode.Point;//<remove this if you want it more fuzzy

    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), myimage);
    }

    void Update()
    {


        sw = Screen.width;
        sh = Screen.height;

        mx = Input.mousePosition.x / sw;
        my = Input.mousePosition.y / sh;

        px = Mathf.RoundToInt(myimage.width * mx);
        py = Mathf.RoundToInt(myimage.height * my) - 1;


        if (px + py != oldp)
        {// <-- only draw when mouse moves for proficiency
            oldp = px + py;

            if (Input.GetMouseButton(0))
            {//------mouse right button  draws--------

                px += -Mathf.RoundToInt(brush * .5f);
                py += -Mathf.RoundToInt(brush * .5f);

                i = 0;
                while (i < brush)
                {
                    i++;//<--next two loops for brush size
                    i2 = 0;
                    while (i2 < brush)
                    {
                        i2++;
                        if (px + i > -1 && px + i < myimage.width)
                        {//<---dont try to draw off image width
                            if (py + i2 > -1 && py + i2 < myimage.height)
                            {//<---dont try to draw off image height

                                myimage.SetPixel(px + i, py + i2, drawcolor);


                            }
                        }
                    }
                }
                myimage.Apply();

            }


            if (Input.GetMouseButton(1))
            {//-----mouse left erases----

                px += -Mathf.RoundToInt(erase * .5f);
                py += -Mathf.RoundToInt(erase * .5f);

                i = 0;
                while (i < erase)
                {
                    i++;
                    i2 = 0;
                    while (i2 < erase)
                    {
                        i2++;
                        if (px + i > -1 && px + i < myimage.width)
                        {
                            if (py + i2 > -1 && py + i2 < myimage.height)
                            {

                                c = original.GetPixel(px + i, py + i2);//<--grab pixel from original for erasing
                                myimage.SetPixel(px + i, py + i2, c);


                            }
                        }
                    }
                }
                myimage.Apply();
            }

        }
    }
}

