using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    void Update()            
    {
        if (transform.position.y < -100)       
        {
            if (PlayerProperties.playerLifes > 0)
            {
                Debug.Log("Spadol");
                PlayerProperties.playerLifes--;
                transform.position = new Vector3(0, 0, 0);
            } 
            else
            {
                GameProperties.isEnd = true;
            }         
        }   
    }
}
