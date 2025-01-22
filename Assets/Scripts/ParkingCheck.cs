using UnityEngine;

public class ParkingCheck : MonoBehaviour
{
    
    private int wheelsInZone = 0;
    private int howMuchWheelsNeedToPark = 4;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wheel")
        {
            wheelsInZone++;

            if (wheelsInZone == howMuchWheelsNeedToPark) GlobalEventManager.onCharacterParkedCorrectly.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wheel")
        {
            wheelsInZone--;
        }
    }
}

