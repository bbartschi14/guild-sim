using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public Quest(string name, string description, GuildRank rank, List<QuestTask> tasks, QuestStatus status, int reward, int downPayment,
                 int expectedLength, int timeLimit, int travelTime)
    {
        this.Name = name;
        this.Description = description;
        this.Rank = rank;
        this.Tasks = tasks;
        this.Status = status;
        this.Reward = reward;
        this.DownPayment = downPayment;
        this.ExpectedLength = expectedLength;
        this.TimeLimit = timeLimit;
        this.TravelTime = travelTime;
        this.AssignedAdvs = new List<Adventurer>();
        this.ClientID = 0;
    }

    public string Name { get; }
    public string Description { get; }
    public GuildRank Rank { get; }
    public int Reward { get; }
    public int DownPayment { get; }

    public int ExpectedLength { get; }

    public int TimeLimit { get; }

    public int TravelTime { get; }

    public List<QuestTask> Tasks { get; }
    public QuestStatus Status { get; set;  }
    public List<Adventurer> AssignedAdvs { get; set;  }

    public int ClientID { get; set; }

    public void AssignAdventurers(List<Adventurer> advs)
    {
        foreach (Adventurer adv in advs)
        {
            adv.SetAssigned(true);
        }
        AssignedAdvs = advs;
    }
    private void UnassignAdventurers()
    {
        foreach (Adventurer adv in AssignedAdvs)
        {
            adv.SetAssigned(false);
        }
        AssignedAdvs.Clear();
    }

    public int Simulate()
    {
        foreach (QuestTask task in Tasks)
        {
            if (!task.CompleteTask(AssignedAdvs))
            {
                Status = QuestStatus.Failed;
                return -1;
            }
        }
        UnassignAdventurers();
        Status = QuestStatus.Complete;
        return Reward;
    }
}

public enum QuestStatus
{
    Offered,
    Posted,
    InProgess,
    Complete,
    Failed
}
