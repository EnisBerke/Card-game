using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    GameObject CardSample;
    public static System.Random rand = new System.Random();
    public int random = 0;
    List<int> frontList = new List<int> { 0, 1, 2, 3, 0, 1, 2, 3 };
    public int[] facesUp = { -1, -2 };

    void Start()
    {
        //Kartlarýn oluþturulmasý
        int cardCount = frontList.Count;
        float yWise = 2.3f;
        float xWise = -2.2f;
        for (int i = 0; i < 7; i++)
        {
            random = rand.Next(0, (frontList.Count));
            var temporary = Instantiate(CardSample, new Vector3(xWise, yWise, 0), Quaternion.identity);
            temporary.GetComponent<MainObject>().frontIndex = frontList[random];
            frontList.Remove(frontList[random]);
            xWise = xWise + 4;
            if (i == (cardCount / 2 - 2))
            {
                yWise = -2.3f;
                xWise = -6.2f;
            }
            CardSample.GetComponent<MainObject>().frontIndex = frontList[0];
        }

    }
    private void Awake()
    {
        CardSample = GameObject.Find("CardSample");
    }

    //Ýki kart açýk mý check
    public bool isTwoFaceUp()
    {
        bool check = false;
        if (facesUp[0] >= 0 && facesUp[1] >= 0)
        {
            check = true;
        }
        return check;
    }

    //Açýk kartlar eþ mi check
    public bool isTwoMatch()
    {
        bool check = false;
        if (facesUp[0] == facesUp[1])
        {
            facesUp[0] = -1;
            facesUp[1] = -2;
            check = true;
        }
        return check;
    }

    //Kart aç
    public void openFace(int face)
    {
        if (facesUp[0] == -1)
        {
            facesUp[0] = face;
        }
        else if (facesUp[1] == -2)
        {
            facesUp[1] = face;

        }

    }

    //Kart kapa
    public void closeFace(int face)
    {
        if (facesUp[0] == face)
        {
            facesUp[0] = -1;
        }
        if (facesUp[1] == face)
        {
            facesUp[1] = -2;
        }
    }

}