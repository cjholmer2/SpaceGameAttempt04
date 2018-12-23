using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arena : MonoBehaviour
{
    public GameObject arenaCanvas;
    public GameObject indicator;
    private bool inCollider = false;
    private bool arenaOpen = false;
    public int targetScene;

    void Start()
    {
        arenaCanvas.SetActive(false);
        indicator.SetActive(false);
    }
    void Update()
    {
        if(inCollider == true && arenaOpen == false)
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetButton("Fire1"))
            {
                OpenArena();
            }
        }
    }

    public void OpenArena()
    {
        indicator.SetActive(false);
        arenaCanvas.SetActive(true);
        arenaOpen = true;
    }

    public void EnterArena()
    {
        SceneManager.LoadScene(targetScene);
    }

    public void ExitArena()
    {
        indicator.SetActive(true);
        arenaCanvas.SetActive(false);
        arenaOpen = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            inCollider = true;
            indicator.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            indicator.SetActive(false);
            inCollider = false;
            arenaCanvas.SetActive(false);
            arenaOpen = false;
        }
    } 
}
