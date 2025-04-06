using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public string winnerName;
    public bool isRight=false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Diamond"))
        {
            RopeManager.instance.EndGame(winnerName);
        }
    }
}
