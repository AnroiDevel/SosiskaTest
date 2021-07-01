using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private static bool _isFirstPlay = true;
    [SerializeField] GameObject _panelUi;

    private void Start()
    {
        if (!_isFirstPlay)
        {
            _panelUi.SetActive(false);
            _player.SetActive(true);
        }
    }

    public void ReloadGame()
    {
        _isFirstPlay = false;
        SceneManager.LoadScene(0);
    }
}
