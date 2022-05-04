using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public RectTransform leader;// ������ �������
    public RectTransform content;// �������

    public bool isUpdateItems { get; set; }// ���������� ���������
    
    /// <summary>
    /// �������� �������� ����� ��������� ���� ������ ����������
    /// </summary>
    private void Update()
    {
        if (isUpdateItems && content.gameObject.activeInHierarchy)
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
        string[] listLeaders = { GameManager.localUsername + "-" + GameManager.characterName + "-" + GameManager.timeInTheGame };
        if (!GameManager.isLocalAccount)
        {
            listLeaders = Client.SendingMessage(GameManager.clientId, String.Format("ShowListLeaders_{0}", 5)).Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
        }
        int modelsCount = listLeaders.Length;
        if (modelsCount != 0)
        {
            StartCoroutine(GetItems(modelsCount, results => OnReceivedModels(results), listLeaders));
        }
    }

    private void OnReceivedModels(ItemModel[] models)
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        foreach (var model in models)
        {
            var instance = GameObject.Instantiate(leader.gameObject) as GameObject;
            instance.transform.SetParent(content, false);
            InitializeItemView(instance, model);
        }
    }

    /// <summary>
    /// ���������� ����������� ��������� ������� ������ �������� ������
    /// </summary>
    /// <param name="viewGameObject">����� ����������� ��������� ������� ���������</param>
    /// <param name="model">����� ��������� ���������</param>
    private void InitializeItemView(GameObject viewGameObject, ItemModel model)
    {
        ItemView view = new ItemView(viewGameObject.transform);
        view.name.text = model.username + "(" + model.name + ")";
        view.timeInTheGame.text = model.timeInTheGame;
    }

    /// <summary>
    /// ���������� ������ ���������
    /// </summary>
    /// <param name="count">����� ����������</param>
    /// <param name="callback">����� ��������� ���������</param>
    /// <param name="leader">�������� ������</param>
    /// <returns>����������</returns>
    IEnumerator GetItems(int count, System.Action<ItemModel[]> callback, string[] leader)
    {
        var results = new ItemModel[count];
        for (int i = 0; i < count; i++)
        {
            string[] character = leader[i].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            results[i] = new ItemModel();
            results[i].username = character[0];
            results[i].name = character[1];
            results[i].timeInTheGame = character[2];
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
        public Text timeInTheGame;

        public ItemView(Transform rootView)
        {
            name = rootView.Find("Name").GetComponent<Text>();
            timeInTheGame = rootView.Find("Time").GetComponent<Text>();
        }
    }

    /// <summary>
    /// �������� ���������
    /// </summary>
    public class ItemModel
    {
        public string username;
        public string name;
        public string timeInTheGame;
    }
}
