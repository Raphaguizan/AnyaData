using UnityEngine;
using TMPro;
using System;
using System.Globalization;

public class DateUIInput : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField input_year;
    [SerializeField]
    private TMP_InputField input_month;
    [SerializeField]
    private TMP_InputField input_day;
    [SerializeField]
    private TMP_InputField input_hour;
    [SerializeField]
    private TMP_InputField input_minute;
    [SerializeField]
    private TMP_InputField input_second;



    private string dateFormat = "yyyy-MM-dd HH:mm:ss";

    public void SetDate(string date)
    {
        DateTime auxDateTime = DateTime.ParseExact(date, dateFormat, CultureInfo.InvariantCulture);
        input_year.text = auxDateTime.Year.ToString("0000");
        input_month.text = auxDateTime.Month.ToString("00");
        input_day.text = auxDateTime.Day.ToString("00");
        input_hour.text = auxDateTime.Hour.ToString("00");
        input_minute.text = auxDateTime.Minute.ToString("00");
        input_second.text = auxDateTime.Second.ToString("00");
    }

    public string GetDate()
    {
        int yearVerify = int.Parse(input_year.text);
        int monthVerify = int.Parse(input_month.text);
        int dayVerify = int.Parse(input_day.text);
        int hourVerify = int.Parse(input_hour.text);
        int minuteVerify = int.Parse(input_minute.text);
        int secondVerify = int.Parse(input_second.text);

        // year
        if (yearVerify < 0) yearVerify = 0;

        // month
        if(monthVerify < 0) monthVerify = 0;
        else if (monthVerify > 12) monthVerify = 12;

        // day
        if (dayVerify < 0) dayVerify = 0;
        else if (dayVerify > 31) dayVerify = 31;

        // hour
        if (hourVerify < 0) hourVerify = 0;
        else if (hourVerify > 59) hourVerify = 59;

        //minute
        if (minuteVerify < 0) minuteVerify = 0;
        else if (minuteVerify > 59) minuteVerify = 59;

        // second
        if (secondVerify < 0) secondVerify = 0;
        else if (secondVerify > 59) secondVerify = 59;


        return $"{yearVerify.ToString("0000")}-{monthVerify.ToString("00")}-{dayVerify.ToString("00")} {hourVerify.ToString("00")}:{minuteVerify.ToString("00")}:{secondVerify.ToString("00")}";
    }
}
