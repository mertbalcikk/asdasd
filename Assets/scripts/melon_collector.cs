using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class melon_collector : MonoBehaviour
{
    [SerializeField] private AudioSource CollectEffect;
    private int Melon = 0;

    [SerializeField] private Text Melontext;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Melons"))
        {
            Destroy(collision.gameObject);
            CollectEffect.Play();
            Melon++;
            Debug.Log("Melons" + Melon);
            Melontext.text = "Melons: " + Melon;
        }
    }
}