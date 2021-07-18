using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject _panelQuest;
    [SerializeField] private GameObject _status1;
    [SerializeField] private GameObject _status2;

    private void Update()
    {
        if(Quest._quest2 == true)
        {
            _status1.SetActive(true);
        }
        if(Quest._quest2 == true)
        {
            _status2.SetActive(true);
        }
    }

    public void CloseQuestPanel()
    {
        _panelQuest.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void QuestPanel()
    {
        _panelQuest.SetActive(true);
    }
}
