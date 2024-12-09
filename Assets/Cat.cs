using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cat : MonoBehaviour
{
    bool isD;
    public float hp=10;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isD = true;
        }
        else
            isD = false;
        if(hp<=0)
        {
            GameManager.instance.PlaySound("Bubble");
            Camera.main.transform.DOShakePosition(1, 0.1f, 10, 90);
            Destroy(gameObject);
        }
        transform.position += (target.position - transform.position).normalized*Time.deltaTime*0.5f;
        
    }
    private void OnMouseOver()
    {
        if(isD)
        {
            
            transform.DOScale(new Vector3(3,3,3),1);
            transform.DOShakeRotation(1f, 5f, 20, 90);
            hp -=0.01f;
        }
        
        
    }
}
