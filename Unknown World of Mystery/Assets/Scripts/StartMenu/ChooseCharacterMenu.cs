using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChooseCharacterMenu : MonoBehaviour
{
    public RectTransform character;
    public RectTransform content;

    public void UpdateItems(int modelsCount, string[] characters)
    {
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

    void InitializeItemView(GameObject viewGameObject, ItemModel model)
    {
        ItemView view = new ItemView(viewGameObject.transform);
        view.name.text = model.name;
    }

    IEnumerator GetItems(int count, System.Action<ItemModel[]> callback, string[] characters)
    {
        var results = new ItemModel[count];
        for (int i = 0; i < count; i++)
        {
            string[] character = characters[i].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            results[i] = new ItemModel();
            results[i].name = character[0];
        }

        callback(results);
        yield return 0;
    }

    public class ItemView
    {
        public Text name;

        public ItemView(Transform rootView)
        {
            name = rootView.Find("Name").GetComponent<Text>();
        }
    }

    public class ItemModel
    {
        public string name;
    }
}
