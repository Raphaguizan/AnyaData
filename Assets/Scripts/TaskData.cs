using System;

[Serializable]
public class TaskData
{
    public string date_time;
    public string task;
    public string eat;
    public string suckle;

    public TaskData(string date_time, string task, string eat, string suckle)
    {
        this.date_time = date_time;
        this.task = task;
        this.eat = eat;
        this.suckle = suckle;
    }
    public TaskData(DateTime dateTime, string task, string eat, string suckle)
    {
        this.date_time = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        this.task = task;
        this.eat = eat;
        this.suckle = suckle;
    }
    public TaskData(string task, string eat, string suckle)
    {
        this.date_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        this.task = task;
        this.eat = eat;
        this.suckle = suckle;
    }
    public TaskData(string task, string eat)
    {
        this.date_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        this.task = task;
        this.eat = eat;
        this.suckle = "";
    }
    public TaskData(string task)
    {
        this.date_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        this.task = task;
        this.eat = "";
        this.suckle = "";
    }
    public override string ToString()
    {
        return $"data_hora: {date_time}\ntarefa:    {task}\ncomeu:     {eat}\nmamou:     {suckle}";
    }
    public string ToStringNoDate()
    {
        return $"tarefa: {task}\ncomeu:  {eat}\nmamou:  {suckle}";
    }
}