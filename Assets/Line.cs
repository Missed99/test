using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Line : MonoBehaviour
{
    Color defaulColor;
    bool isP;
    bool isC;
    public bool isLight;
    public Material material;
    public int x, y;
    // Start is called before the first frame update
    void Start()
    {
        Color defaulColor= GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            isP = true;
        else
            isP = false;

        if (Input.GetMouseButton(1))
            isC = true;
        else
            isC = false;
    }
    private void OnMouseEnter()
    {
        if (isP)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.85f,0.6f , 0.5f );//new Color(0.4f, 0.4f, 0.1f);
            //GameManager.instance.PlaySound("Bubble");
            GetComponent<SpriteRenderer>().material = material;
            GetComponent<CircleCollider2D>().isTrigger = false;
            isLight = true;
            transform.DOShakeRotation(1f, 1f, 10, 90);
        }
            
        if (isC)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
            GameManager.instance.PlaySound("Clear");
            GetComponent<CircleCollider2D>().isTrigger = true;
        }
            
    }
}
