using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
   
    [SerializeField]

    private float delayLoading = 10f;

    private float timeElapsed;

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if(timeElapsed > delayLoading)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
