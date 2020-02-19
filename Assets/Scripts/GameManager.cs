
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float timer = 2f;
    public GameObject completeLevelUI;


    public void EndGame ()
    {
        
        if (gameHasEnded == false){
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", timer);
            
        }
        
        
    }

    void Restart (){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel (){
        completeLevelUI.SetActive(true);
    }
}
