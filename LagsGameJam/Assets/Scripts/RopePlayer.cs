using UnityEngine;

public class RopePlayer : MonoBehaviour
{
    void Update()
    {
        if (RopeManager.instance.gameStarted && Input.GetKeyDown(KeyCode.D))
        {
            RopeManager.instance.Pull(false); // tira hacia la derecha
        }
    }
}
