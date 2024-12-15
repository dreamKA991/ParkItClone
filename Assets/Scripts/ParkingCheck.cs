using UnityEngine;
using UnityEngine.UI;

public class ParkingCheck : MonoBehaviour
{
    
    private int wheelsInZone = 0;
    [SerializeField] private Text textToShowWheels;
    private int howMuchWheelsNeedToPark = 4;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wheel")
        {
            wheelsInZone++;
            textToShowWheels.text = wheelsInZone+"";

            if (wheelsInZone == howMuchWheelsNeedToPark) GlobalEventManager.onCharacterParkedCorrectly.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wheel")
        {
            wheelsInZone--;
            textToShowWheels.text = wheelsInZone + "";
        }
    }
}

