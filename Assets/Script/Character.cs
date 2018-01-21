using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    int currentX;
    int currentY;
    public backgroundSetting BS;

	void Start () {
        BS = GameObject.Find("EventSystem").GetComponent<backgroundSetting>();

        BS.Characters.Add(this.gameObject);
        BS.UpdateCharacter();
      
        currentX = 10;
        currentY = 10;
        this.gameObject.transform.position = new Vector3((float)(currentX * 0.5 - 5), 1f, (float)(currentX * 0.5 - 5));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move(int x,int y)
    {
        //draw a path to
        DrawLine(currentX, currentY, x, y);

        // this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, new Vector3(x,1,y), 0.2f);  // each unitGround

    }
    Vector3 ChangeV2toV3(Vector2 v2 )
    {
        return new Vector3(2*v2.x, 1f, 2*v2.y); //2* is the world coordinate since these at parent
    }

    Vector2 ChangeCoordinateTofloat(int x, int y)
    {
        return new Vector2((float)(x * 0.5 - 5), (float)(y * -0.5)+5);
    }
    void DrawLine(int myX, int myY, int toX, int toY  )
    {
        Vector3 start = ChangeV2toV3(ChangeCoordinateTofloat(myX, myY)); Vector3 end = ChangeV2toV3(ChangeCoordinateTofloat(toX, toY));
        //Debug.Log("start: " + start+", end: "+end+" at ("+toX+", "+toY+")");
        Debug.DrawLine(start, end, Color.green, 2.0f);

        int diffX = toX - myX;int diffY = toY - myY;
    }
}
