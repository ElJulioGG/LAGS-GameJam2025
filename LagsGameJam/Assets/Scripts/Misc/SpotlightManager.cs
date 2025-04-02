using System.Collections;
using UnityEngine;

public class SpotlightManager : MonoBehaviour
{
    public GameObject[] spotlightArr;
    public float[] spotlightDelays; // Set individual delays in Inspector

    void Start()
    {
        StartCoroutine(ActivateSpotlights());
    }

    IEnumerator ActivateSpotlights()
    {
        for (int i = 0; i < spotlightArr.Length; i++)
        {
            yield return new WaitForSeconds(spotlightDelays[i]); // Wait for specific delay
            if (spotlightArr[i] != null)
            {
                spotlightArr[i].SetActive(true); // Enable spotlight
            }
        }
    }
}
