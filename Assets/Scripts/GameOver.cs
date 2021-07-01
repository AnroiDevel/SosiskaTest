using UnityEngine;


public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject _panelUi;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _start;
    [SerializeField] GameObject _reload;
    [SerializeField] GameObject _failText;

    private void OnCollisionEnter(Collision collision)
    {
        _start.SetActive(false);
        _reload.SetActive(true);
        _panelUi.SetActive(true);
        _player.SetActive(false);
        _failText.SetActive(true);
    }

}
