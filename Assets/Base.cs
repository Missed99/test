using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public int hp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hp<=0)
        {
            Camera.main.transform.DOShakePosition(2, 1f, 10, 90,true);
            Destroy(gameObject);
        }
            
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cat")
        {
            hp--;
            Destroy(other.gameObject);
        }

    }
}
