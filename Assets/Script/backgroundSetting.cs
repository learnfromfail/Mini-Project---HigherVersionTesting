using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundSetting : MonoBehaviour
{
    GameObject UnitG;
    GameObject BackGround;
    public List<GameObject> AllUnit;
    public GameObject[,] AllUnits;
    public int width;
    public int height;
    int Xscale; int Yscale; int Zscale;
    // Use this for initialization


    public List<GameObject> Characters;
    public int noOfCharacters;
    public int round = 0;

    void Start()
    {
        AllUnit = new List<GameObject>();
        AllUnits = new GameObject[width + 1, height + 1];

        BackGround = GameObject.Find("Background");
        Xscale = (int)BackGround.transform.localScale.x;
        Yscale = (int)BackGround.transform.localScale.y;
        Zscale = (int)BackGround.transform.localScale.z;
        UnitG = GameObject.Find("UnitGround");
        UnitG.transform.position = new Vector3((BackGround.transform.position.x) * Xscale, (BackGround.transform.position.y) * Yscale, (BackGround.transform.position.z + 5) * Zscale);
        // StartCoroutine("WaitForTime");
        SetupGround();
       
     
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateCharacter()
    {
        noOfCharacters = Characters.Count;
    }

    IEnumerator WaitForTime()
    {
        SetupGround();
        yield return new WaitForSeconds(1);
    }
    void SetupGround()
    {
        for (int i = 0; i <= width; i++)
            for (int ii = height; ii >= 0; ii--)
            {
                GameObject newUG = Instantiate(UnitG, new Vector3((BackGround.transform.position.x - 10 + i) * Xscale / 2, (BackGround.transform.position.y) * Yscale,
                     (BackGround.transform.position.z + 10 - ii) * Zscale / 2), Quaternion.identity, BackGround.transform);
                newUG.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                newUG.GetComponent<UnitGround>().coordinateX = i; newUG.GetComponent<UnitGround>().coordinateY = ii;
                if (i >= (width / 3) && (ii >= (height / 3) && ii <= (height / 2)))
                    newUG.GetComponent<UnitGround>().setGroundType(2);
                if ((i >= (width / 3) && i <= (width / 2)) && (ii >= (height / 9) && (ii <= height / 4)))
                    newUG.GetComponent<UnitGround>().setGroundType(1);
                newUG.name = "X" + i + ",Y" + ii;
                AllUnit.Add(newUG);
                AllUnits[i, ii] = newUG;
            }
         setNeighbourGround();
    }
    void setNeighbourGround() // this function fails to work
    {
        //Debug.Log("Leng: " + AllUnits.GetLength(0)+","+ AllUnits.GetLength(1));
        //((AllUnits[0, 0].GetComponent<UnitGround>()).neighbourUnit).Add(AllUnits[0, 1].GetComponent<UnitGround>());
        //((AllUnits[0, 0].GetComponent<UnitGround>()).neighbourUnit).Add(AllUnits[0, 2].GetComponent<UnitGround>());

        AllUnits[0,0].GetComponent<UnitGround>().setNeighb();
        foreach (GameObject Unit in AllUnit)
        {
            // UnitGround myUnit = Unit.GetComponent<UnitGround>();//////////
           // myUnit.setNeighb();
            /*
            for (int i = myUnit.coordinateX - 1; i <= myUnit.coordinateX + 1; i++)
            {

                if (i <= 20 && i >= 0)
                {
                    if (i != myUnit.coordinateX)
                    {
                        //myUnit.neighbourUnit.Add(AllUnits[i, myUnit.coordinateY].GetComponent<UnitGround>());
                      //  myUnit.setNeighb();
                       // myUnit.noOfNeigh++;
                    }
                    if (i == myUnit.coordinateX)
                    {
                        for (int ii = myUnit.coordinateY - 1; ii <= myUnit.coordinateY + 1; ii++)
                        {
                            if ((ii <= 20 && ii >= 0) && ii != myUnit.coordinateY)
                            {
                                //Debug.Log(AllUnits[i, myUnit.coordinateY].name);
                                //Unit.GetComponent<UnitGround>().neighbourUnit.Add(AllUnits[i, ii].GetComponent<UnitGround>());
                               // myUnit.setNeighb();
                               // myUnit.noOfNeigh++;
                            }
                        }
                    }
                }
            }
            */
        }
        
    }
    GameObject getCertainUnit(int Cx, int Cy)
    {
        foreach (GameObject Unit in AllUnit)
        {
            if (Unit.name == ("X" + Cx + ",Y" + Cy))
                return Unit;
        }
        return new GameObject();
    }
    void setNeighb()
    {
        for (int i = 0; i <= width; i++)
            for (int ii = 0; i <= height; ii++)
            {
                AllUnits[i, ii].GetComponent<UnitGround>().setNeighb();
            }
    }
}
