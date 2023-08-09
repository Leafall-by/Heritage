using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class QuestSaver : ISaver
{
    private QuestController controller;
    private QuestHub questHub;

    public QuestSaver(QuestController questController, QuestHub questHub)
    {
        controller = questController;
        this.questHub = questHub;
    }


    public void Save()
    {
        QuestData data = new QuestData();

        foreach (var quest in controller.GetQuests())
        {
            data.questsId.Add(quest.id, quest.currentDay);
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Quests.dat");
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath
                        + "/Quests.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
                File.Open(Application.persistentDataPath
                          + "/Quests.dat", FileMode.Open);
            QuestData data = (QuestData)bf.Deserialize(file);
            file.Close();

            foreach (var questId in data.questsId)
            {
                controller.AddQuestWithDifferentDuration(questHub.GetQuestById(questId.Key), questId.Value);
            }

        }
        else
            Debug.LogError("There is no save data!");
    }
}
