using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour
{
    float lerpDuration = .4f;
    //GameObject player;
   
    public void RotatePlayerBodyByDgree(float Dgree , float rotationSpeed)
    {
        Quaternion target = Quaternion.Euler(0, 0, Dgree);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * rotationSpeed);
       
    }

    // reset the body rotation
    public void ResetPlayerRotation(float speed)
    {
        RotatePlayerBodyByDgree(0, speed);
      
    }

    // reset any object rotaion 
    public Quaternion SetRotation()
    {
        return Quaternion.Euler(0, 0, 0);

    }


    // rotate the platform 180 degree by time (lerpDuration)
    public IEnumerator RotateTheWorld(float ClockWise)
    {
        float timeElapsed = 0;
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = transform.rotation * Quaternion.Euler(0, 0, 180 * ClockWise);
        while (timeElapsed < lerpDuration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = targetRotation;
      
    }
  
   
}
