using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
          
            SceneManager.LoadScene("DrawingScene");
        }
    }
}
