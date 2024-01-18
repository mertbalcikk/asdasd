using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    
    [SerializeField] private AudioSource finishEffect;
    private Animator anim;
    [SerializeField] private  float passpeed = 2f;


    // Start is called before the first frame update
    void Start()
    {
        anim.SetTrigger("finish");

    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            finishEffect.Play();
            Invoke("CompleteLevel", passpeed);
        }
    }
    private void CompleteLevel()
        {   
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
}
