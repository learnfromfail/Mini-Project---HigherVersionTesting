﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGround : MonoBehaviour {
    public backgroundSetting BS;
    public int coordinateX;
    public int coordinateY;
    public int groundType = 0; //0 is grassground //1 is mudd //2 obstacle
    public List<UnitGround> neighbourUnit;
    public int noOfNeigh = 0;
    public bool IsChecked = false;
    // Use this for initialization

    Color orig;

    void Start () {
        BS = GameObject.Find("EventSystem").GetComponent<backgroundSetting>();
        neighbourUnit = new List<UnitGround>();

        orig = this.gameObject.GetComponent<Renderer>().material.color;
        //  Debug.Log("myX,Y " + coordinateX + ", " + coordinateY);
    }
    
    void Update () {
		
	}
    void OnMouseDown()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        BS.Characters[BS.round].GetComponent<Character>().Move(coordinateX, coordinateY);
        setNeighb();
    }
    void OnMouseUp()
    {
        this.gameObject.GetComponent<Renderer>().material.color = orig;
    }
    public void setGroundType(int type)
    {
        switch (type)
        {
            case 1:
                groundType = 1;
                this.gameObject.GetComponent<Renderer>().material.color = Color.black;
                orig = this.gameObject.GetComponent<Renderer>().material.color;
                //= Resources.Load("/Materials/New Material", typeoff(Material)) as Material;
                break;
            case 2:
                groundType = 2;
                this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
                orig = this.gameObject.GetComponent<Renderer>().material.color;
                break;
            default:
                groundType = 0;
        break;
        }
    }

   public void setNeighb()
    {
        // neighbourUnit.Add()
        // for (int i = 0; i <= 20; i++)
        //    for (int ii = 0; i <= 20; ii++)
        //     {
        neighbourUnit = new List<UnitGround>();
        if (coordinateX - 1 >= 0)
            neighbourUnit.Add(BS.AllUnits[coordinateX-1, coordinateY].GetComponent<UnitGround>());
        if (coordinateX + 1 <= 20)
            neighbourUnit.Add(BS.AllUnits[coordinateX+1, coordinateY].GetComponent<UnitGround>());
        if (coordinateY - 1 >= 0)
            neighbourUnit.Add(BS.AllUnits[coordinateX, coordinateY-1].GetComponent<UnitGround>());
        if (coordinateY + 1 <= 20)
            neighbourUnit.Add(BS.AllUnits[coordinateX, coordinateY+1].GetComponent<UnitGround>());
        noOfNeigh = neighbourUnit.Count;
        //    }
    }
}
