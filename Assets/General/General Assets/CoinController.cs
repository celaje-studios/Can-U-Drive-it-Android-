using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinController : MonoBehaviour
{
    [Header("Public References")]
    public Kart_SantoriniController levelController;

    [Header("Parameters")]
    public float rotationSpeed = 5f;
    public float value;

    void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime*rotationSpeed);
    }

     private void OnTriggerEnter(Collider col)
    {
        Debug.Log("coin colition");
        if(col.transform.tag == "kart"){
            Debug.Log("Colect Coin " + value);
            levelController.addMoney(value);
            rotationSpeed = 500;
            transform.DOLocalMoveY(6f, .5f).OnComplete(()=>{
                Destroy(this.gameObject);
            });
            
        }
    }
}
