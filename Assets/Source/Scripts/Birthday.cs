using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using Fungus;

public class Birthday : MonoBehaviour
{
    [SerializeField] private InputField _inputField;
    [SerializeField] private List<Sprite> _imagesZodiacs = new List<Sprite>();

    [SerializeField] private Image _zodiac;

    [SerializeField] private Flowchart _flowchart;

    private const string Aquarius = "Водолей";
    private const string Pisces = "Рыбы";
    private const string Aries = "Овен";
    private const string Taurus = "Телец";
    private const string Gemini = "Близнецы";
    private const string Cancer = "Рак";
    private const string Leo = "Лев";
    private const string Virgo = "Дева";
    private const string Libra = "Весы";
    private const string Scorpio = "Скорпион";
    private const string Sagittarius = "Стрелец";
    private const string Capricorn = "Козерог";

    private List<string> _zodiacs = new List<string>();

    private int _rawDate;
    private string _day;
    private string _month;

    private int _magicNumber = 250;

    public void SplitData()
    {
        _month = "";
        _day = "";

        int[] dataArray = GetCurrentData().ToString().ToCharArray().Select(x => x - '0').ToArray();

        int separatorPosition = dataArray.Length - 2;

        for (int i = separatorPosition; i < dataArray.Length; i++)
            _month += dataArray[i].ToString();

        for (int i = 0; i < separatorPosition; i++)
            _day += dataArray[i].ToString();

        _zodiac.sprite = _imagesZodiacs[FindZodiac(_day, _month)];
    }

    private int ReadIntNumber()
    {
        int number;

        if (int.TryParse(_inputField.text, out number))
        {
            _rawDate = number;
            gameObject.SetActive(false);
        }

        return _rawDate;
    }

    private int GetCurrentData() =>
        ReadIntNumber() - _magicNumber;

    private int FindZodiac(string day, string month)
    {
        int currentDay = int.Parse(day);
        int currentMonth = int.Parse(month);

        int numberImage = -1;

        if ((currentDay >= 21 && currentMonth == 1) || (currentDay <= 20 && currentMonth == 2))
            numberImage = 0;

        if ((currentDay >= 21 && currentMonth == 2) || (currentDay <= 20 && currentMonth == 3))
            numberImage = 1;

        if ((currentDay >= 21 && currentMonth == 3) || (currentDay <= 19 && currentMonth == 4))
            numberImage = 2;

        if ((currentDay >= 20 && currentMonth == 4) || (currentDay <= 20 && currentMonth == 5))
            numberImage = 3;

        if ((currentDay >= 21 && currentMonth == 5) || (currentDay <= 21 && currentMonth == 6))
            numberImage = 4;

        if ((currentDay >= 22 && currentMonth == 6) || (currentDay <= 22 && currentMonth == 7))
            numberImage = 5;

        if ((currentDay >= 23 && currentMonth == 7) || (currentDay <= 22 && currentMonth == 8))
            numberImage = 6;

        if ((currentDay >= 23 && currentMonth == 8) || (currentDay <= 22 && currentMonth == 9))
            numberImage = 7;

        if ((currentDay >= 23 && currentMonth == 9) || (currentDay <= 23 && currentMonth == 10))
            numberImage = 8;

        if ((currentDay >= 24 && currentMonth == 10) || (currentDay <= 21 && currentMonth == 11))
            numberImage = 9;

        if ((currentDay >= 22 && currentMonth == 11) || (currentDay <= 21 && currentMonth == 12))
            numberImage = 10;

        if ((currentDay >= 22 && currentMonth == 12) || (currentDay <= 20 && currentMonth == 1))
            numberImage = 11;

        _flowchart.SetIntegerVariable("Day", currentDay);
        _flowchart.SetIntegerVariable("Month", currentMonth);
        _flowchart.SetStringVariable("MonthS", FillZodiacName()[numberImage]);

        return numberImage;
    }

    private List<string> FillZodiacName()
    {
        _zodiacs.Add(Aquarius);
        _zodiacs.Add(Pisces);
        _zodiacs.Add(Aries);
        _zodiacs.Add(Taurus);
        _zodiacs.Add(Gemini);
        _zodiacs.Add(Cancer);
        _zodiacs.Add(Leo);
        _zodiacs.Add(Virgo);
        _zodiacs.Add(Libra);
        _zodiacs.Add(Scorpio);
        _zodiacs.Add(Sagittarius);
        _zodiacs.Add(Capricorn);

        return _zodiacs;
    }
}
