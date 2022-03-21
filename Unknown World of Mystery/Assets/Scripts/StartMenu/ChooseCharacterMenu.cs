using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChooseCharacterMenu : MonoBehaviour
{
    public RectTransform character;// ������ ���������
    public RectTransform content;// �������

    public StartMenu startMenu;// ��������� ����
    public AudioManager audioManager;// �������� ������
    public AudioSource sound;// ���� ������� �� ������

    public bool isUpdateItems { get; set; }// ���������� ���������

    /// <summary>
    /// �������� �������� ����� ��������� ���� ������ ����������
    /// </summary>
    private void Update()
    {
        if(isUpdateItems && content.gameObject.activeInHierarchy)
        {
            isUpdateItems = false;
            UpdateItems();
        }
    }

    /// <summary>
    /// �������� ��������
    /// </summary>
    public void UpdateItems()
    {
        string[] characters = { "Character1-0-0-1", "Character2-1-0-1" };
        if (!GameManager.isLocalAccount)
        {
            characters = Client.SendingMessage(GameManager.username, String.Format("ChooseCharacter_{0}", GameManager.username)).Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
        }
        int modelsCount = characters.Length;
        StartCoroutine(GetItems(modelsCount, results => OnReceivedModels(results), characters));
    }

    void OnReceivedModels(ItemModel[] models)
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        foreach (var model in models)
        {
            var instance = GameObject.Instantiate(character.gameObject) as GameObject;
            instance.transform.SetParent(content, false);
            InitializeItemView(instance, model);
        }
    }

    /// <summary>
    /// ���������� ����������� ��������� ������� ��������� �������� ���������
    /// </summary>
    /// <param name="viewGameObject">����� ����������� ��������� ������� ���������</param>
    /// <param name="model">����� ��������� ���������</param>
    void InitializeItemView(GameObject viewGameObject, ItemModel model)
    {
        ItemView view = new ItemView(viewGameObject.transform);
        view.name.text = model.name;
        view.button.onClick.AddListener(
            () =>
            {
                audioManager.PlaySounds(sound);
                GameManager.characterName = model.name;
                GameManager.characterLevel = model.level;
                GameManager.timeInTheGame = model.timeInTheGame;
                GameManager.location = model.location;
                startMenu.StartGame();
            }
        );
    }

    /// <summary>
    /// ���������� ��������� ���������
    /// </summary>
    /// <param name="count">����� ����������</param>
    /// <param name="callback">����� ��������� ���������</param>
    /// <param name="characters">�������� ���������</param>
    /// <returns>����������</returns>
    IEnumerator GetItems(int count, System.Action<ItemModel[]> callback, string[] characters)
    {
        var results = new ItemModel[count];
        for (int i = 0; i < count; i++)
        {
            string[] character = characters[i].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            results[i] = new ItemModel();
            results[i].name = character[0];
            results[i].level = int.Parse(character[1]);
            results[i].timeInTheGame = character[2];
            results[i].location = int.Parse(character[3]);
        }

        callback(results);
        yield return 0;
    }

    /// <summary>
    /// ����������� �������� ������� ���������
    /// </summary>
    public class ItemView
    {
        public Text name;
        public Button button;

        public ItemView(Transform rootView)
        {
            name = rootView.Find("Name").GetComponent<Text>();
            button = rootView.Find("Button").GetComponent<Button>();
        }
    }

    /// <summary>
    /// �������� ���������
    /// </summary>
    public class ItemModel
    {
        public string name;
        public int level;
        public string timeInTheGame;
        public int location;
    }
}
