using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{
    public AudioClip[] BubbleAudio;
    public AudioClip[] ClearAudios;
    public static GameManager instance;
    public GameObject land;
    public GameObject line;
    public GameObject Gold;
    public List<GameObject> Golds;
    public Line[,] Lines;
    public Land[,] Lands;
    public Text text;
    public int goldNum;
    // Start is called before the first frame update
    void Start()
    {
        instance=this;

        Lands = new Land[30, 70];
        Lines = new Line[30, 70];
        float x=-17, y=7.5f;
        for (int i = 0; i < 26; i++)
        {
            for (int j = 0; j < 60; j++)
            {
                Lands[i,j] =Instantiate(land, new Vector2(x, y), Quaternion.identity).GetComponent<Land>();
                
                if(Random.Range(0,10)==0)
                {
                    var g=Instantiate(Gold, new Vector2(x, y), Quaternion.identity);
                    Lands[i, j].isGold = true;
                    Lands[i, j].goldObj = g;
                    Golds.Add(g);
                }
                    

                x += 0.6f;
            }
            y -= 0.6f;
            x = -17;
        }

        float x1 = -16.7f, y1 = 7.2f;
        for (int i = 0; i < 26; i++)
        {
            for (int j = 0; j < 60; j++)
            {
                Lines[i, j] = Instantiate(line, new Vector2(x1, y1), Quaternion.identity).GetComponent<Line>();
                Lines[i, j].x = i;
                Lines[i, j].y = j;
                x1 += 0.6f;
            }
            y1 -= 0.6f;
            x1 = -16.7f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound(string s)
    {
        if(s=="Bubble")
        {
            GetComponent<AudioSource>().PlayOneShot(BubbleAudio[Random.Range(0, 6)]);
        }
        if (s == "Clear")
        {
            GetComponent<AudioSource>().PlayOneShot(ClearAudios[Random.Range(0, 1)]);
        }
    }
    public void NextDay()
    {
        for (int i = 10; i < 20; i++)
        {
            for (int j = 20; j < 40; j++)
            {
                if (Lands[i,j].isGold)
                {
                    text.text = goldNum++.ToString();
                    Lands[i, j].goldObj.transform.DOMove(new Vector2(-10, 10),1f);
                    Destroy(Lands[i, j].goldObj,1f);
                    Lands[i, j].isGold = false;
                }
            }
        }
        foreach (var item in Golds)
        {
            //Golds.Remove(item);
            Destroy(item);
        }
        

        float x = -17, y = 7.5f;
        for (int i = 0; i < 26; i++)
        {
            for (int j = 0; j < 60; j++)
            {
                
                if (Random.Range(0, 10) == 0)
                {
                    var g = Instantiate(Gold, new Vector2(x, y), Quaternion.identity);
                    Lands[i, j].isGold = true;
                    Lands[i, j].goldObj = g;
                    Golds.Add(g);
                }


                x += 0.6f;
            }
            y -= 0.6f;
            x = -17;
        }
    }
}
