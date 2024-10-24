using Assets.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject EndMenu;
    public TMP_Text Header;
    private void OnEnable()
    {
        Actions.OnEndGame += OpenEndMenu;
    }

    private void OnDestroy()
    {
        Actions.OnEndGame -= OpenEndMenu;
    }

    public void OpenEndMenu(string header)
    {
        Header.text = header;
        EndMenu.SetActive(true);
    }

    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
