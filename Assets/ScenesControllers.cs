using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesControllers : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadScenes(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }
}
