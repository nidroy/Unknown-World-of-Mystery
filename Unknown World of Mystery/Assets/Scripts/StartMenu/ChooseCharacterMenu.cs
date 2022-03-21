using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChooseCharacterMenu : MonoBehaviour
{
    public RectTransform character;// префаб персонажа
    public RectTransform content;// контент

    public StartMenu startMenu;// начальное меню
    public AudioManager audioManager;// менеджер звуков
    public AudioSource sound;// звук нажатия на кнопку

    public bool isUpdateItems { get; set; }// обновление элементов

    /// <summary>
    /// обновить элементы после активации меню выбора персонажей
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
    /// обновить элементы
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
    /// присвоение графическим элементам префаба персонажа элементы персонажа
    /// </summary>
    /// <param name="viewGameObject">класс графических элементов префаба персонажа</param>
    /// <param name="model">класс элементов персонажа</param>
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
    /// добавление персонажу элементов
    /// </summary>
    /// <param name="count">число персонажей</param>
    /// <param name="callback">класс элементов персонажа</param>
    /// <param name="characters">элементы персонажа</param>
    /// <returns>инумератор</returns>
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
    /// графические элементы префаба персонажа
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
    /// элементы персонажа
    /// </summary>
    public class ItemModel
    {
        public string name;
        public int level;
        public string timeInTheGame;
        public int location;
    }
}
