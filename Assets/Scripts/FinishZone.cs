using UnityEngine;

public class FinishZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player_1" || other.tag == "Player_2")
        {
            GameObject.FindGameObjectWithTag("ScriptObj").GetComponent<Menu_Script>()._canKeyDown = false;
            GameObject.FindGameObjectWithTag("ScriptObj").GetComponent<Menu_Script>().Win();
            Debug.Log("Finish");
        }
    }
}
