using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item_collector : MonoBehaviour
{
    [SerializeField] private AudioSource CollectEffect;
    private int Cherries = 0;

    [SerializeField] private Text cherriesText;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            CollectEffect.Play();
            Cherries++;
            Debug.Log("Cherry" + Cherries);
            cherriesText.text = "Cherry: " + Cherries;   
        }
    }
}
