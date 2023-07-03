using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets
{
    public class ResetGameButton : MonoBehaviour
    {

        public void ResetGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Reset");
        }
    }
}