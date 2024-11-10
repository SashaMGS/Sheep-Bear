using UnityEngine;

public class Button3DScript : MonoBehaviour
{
    public GameObject _wallDo;
    public bool _needOnePress = true;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player_1" || other.tag == "Player_2" || other.tag == "MovingItem")
        {
            gameObject.GetComponent<Animator>().SetBool("Pressed", true);
            _wallDo.GetComponent<Animator>().SetBool("Open", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if ((other.tag == "Player_1" || other.tag == "Player_2" || other.tag == "MovingItem") && !_needOnePress)
        {
            gameObject.GetComponent<Animator>().SetBool("Pressed", false);
            _wallDo.GetComponent<Animator>().SetBool("Open", false);
        }
    }
}
