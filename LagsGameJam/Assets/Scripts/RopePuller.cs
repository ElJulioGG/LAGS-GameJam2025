using UnityEngine;

public class RopePuller : MonoBehaviour
{
    public bool isLeftSide;
    public bool isBot;

    void Update()
    {
        if (!RopeManager.instance.gameStarted)
            return;

        if (isBot)
        {
            RopeManager.instance.Pull(isLeftSide);
        }
        else
        {
        //  if (isLeftSide && RopeManager.instance.playerIsLeft && Input.GetKeyDown(KeyCode.A))
        //      RopeManager.instance.Pull(true);
        //  else if (!isLeftSide && !RopeManager.instance.playerIsLeft && Input.GetKeyDown(KeyCode.D))
        //      RopeManager.instance.Pull(false);
        }
    }
}
