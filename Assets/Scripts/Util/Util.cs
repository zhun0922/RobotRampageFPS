using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;
using System.Linq;
using static Unity.VisualScripting.Icons;
using static UnityEditor.Progress;
using System.IO;
using System.Text;

public static class Util
{
    #region
    /*�Լ� �̸� ���¹�
    Ex)
    OnInitialize() Ŭ���� �ʱ�ȭ
    OnClick() ��ư Ŭ��
    1.��κ� ���� ���� Ex) GetRevenue() < ReveneGet()
    2.�ʵ�� �ҹ��� ����, ������Ƽ, �޼���, Ŭ���� ���(��κ�)�� �빮�� ����,
    3.�������̽��� �� �տ� I���̱�. Ex) IButton
    4.�ʿ� ���� �ܾ� ��ŵ Ex) ShopManager.LoadShopData() -> ShopManager.LoadData(), ShopManager���� shop�� �����Ͷ�°��� ���� ����. �ʿ���� �ܾ� ��ŵ
    5.���Ӹ� ��� ����. ��, ���� ǥ�ؾ�� �������ٰ� ������ ��ŭ�̸� ����. Ex) Ads�� Advertisements...���� �� �׷��ϱ� Ads�� ���, Korean�� Kor ���� �� ������ ����.
    6.Manager��� �������� �ܾ�� ��ü���� �ܾ� ����. 
    7.Ư������ ��� X Add_Revneue ����� ������ ���� ����Ѵٰ� ��.(���������ε� �����ϴ°� ����)
    8.3�ܾ� �ȳѴ°� ����Ʈ�� �ѵ� ��¥ �ƽø� 5�ܾ�..
    9.¦���� �̸����� get�� ������ set�� ���� ���̶� ���󰡴� 
    Coordinator ������
    Builder ���� �����. 
    Writer ���� ���°͸� �����ѷ� ?
    Reader ���� �� ���� ���°�� ���� �б� Ex) Rom
    Handler �ٷ��?-> �ڵ����� �ڵ鰰�� ����
    Container 
    Protocol �Ծ�
    Target 
    Converter 
    Controller
    View 
    Factory
    Entity ��ü ��ü
    Bucket
    
    ..���۸� ���
     */
    #endregion

    //Ŭ���� ������
    /*
    1.����� �ʿ� ���� Ŭ������ Ex) Manager Class���� ������ sealed ���̱�.
     */


    #region �ּ�����
    //"<color=#0000ff>" +  + "</color>"
    //.name.Substring(gameObject.name.IndexOf("_") + 1)
    //Image.sprite = Resources.Load("Link", typeof(Sprite)) as Sprite;
    //int.Parse
    //GameObject a = Instantiate(CopyObject, new Vector2(0, 0), Quaternion.identity, Mom.transform);
    // foreach (KeyValuePair<,> _ in _)
    //System.Enum.GetValues(Type).Length
    /*
 for(int i =0; i< Dic.Count; i++)
{
    if(Dic.Keys.ToList()[i] == name)
    {
        Dic[name] = bCheck;
    }
    else if(Dic.Values.ToList()[i] == true)
    {
        Dic[name] = bCheck;
    }
} 
     
    Coordinator ������
    Builder 
    Writer
    Reader
    Handler �ٷ��?-> �ڵ����� �ڵ鰰�� ����
    Container 
    Protocol �Ծ�
    Target 
    Converter 
    Controller
    View 
    Factory
    Entity ��ü ��ü
    Bucket
     */

    #endregion


    public static void Log<T>(string text, T num)//���� �α�.
    {
        Debug.Log(text + " is " + num);
    }
    public static int SumArray(int[] array)//�迭�� ���հ�
    {
        int n = 0;
        for (int i = 0; i < array.Length; i++)
            n += array[i];
        return n;
    }
    public static float SumArray(float[] array)//�迭�� ���հ�
    {
        float n = 0;
        for (int i = 0; i < array.Length; i++)
            n += array[i];
        return n;
    }
    public static string FormatComma(long number)
    {
        return string.Format("{0:#,##0}", number);
    }
    public static string FormatComma(int number)
    {
        return string.Format("{0:#,##0}", number);
    }
    public static string FormatComma(double value, int decimalPlaces)
    {
        return string.Format("{0:F" + decimalPlaces + "}", value);
    }

    public static string FormatComma(float value, int decimalPlaces)
    {
        return string.Format("{0:F" + decimalPlaces + "}", value);
    }
    public static void InitArray<T>(int[] array, int resetnumber)
    {
        for (int i = 0; i < array.Length; i++)
            array[i] = resetnumber;
    }
    public static float Round(float num, int n)//n��° ���ڱ��� �ø�.
    {
        return (float)Math.Round(num, n);
    }
    public static float Round(double num, int n)//n��° ���ڱ��� �ø�.
    {
        return (float)Math.Round(num, n);
    }
    public static bool Probability(double chance)
    {
        if (chance <= 0 || chance >= 1)
        {
            throw new ArgumentException("Chance should be between 0 and 1.");
        }
        return (UnityEngine.Random.value <= chance);
    }
    public static bool Probability(float chance)
    {
        if (chance <= 0 || chance >= 1)
        {
            throw new ArgumentException("Chance should be between 0 and 1.");
        }
        return (UnityEngine.Random.value <= chance);
    }
    public static int ParamsProb(params float[] pers)//Ȯ���� ���ʴ��(���� 1�̵Ǵ°��� ����) �־��� �� �ش��ϴ� Ȯ���� �ɸ��� 01234�� ���ʷ� ����.
    {
        int maxLenth = 0;

        if (pers.Length == 1)//�迭���̰� 1�̸� ������ �� ���� ���;������� 0�� �����Ѵ�.
            return 0;

        //1.���� �Ҽ����� �� ������ ã�Ƴ���.
        int lenth = 0;
        decimal total = 0;
        for (int i = 0; i < pers.Length; i++)
        {
            lenth = pers[i].ToString().Substring(pers[i].ToString().IndexOf('.') + 1).Length;

            total += (decimal)pers[i];
            if (maxLenth < lenth)
                maxLenth = lenth;
        }

        int correction = (int)(total * (decimal)Math.Pow(10, maxLenth)); //-> �����ִ� �� 

        int randomNumber = UnityEngine.Random.Range(1, correction + 1);
        int tempNum = 0;
        int num = 0;
        for (int i = 0; i < pers.Length; i++)
        {
            num = (int)(correction * (decimal)pers[i]);
            if (num + tempNum >= randomNumber)
            {
                //Debug.Log(num + tempNum + ">=" + randomNumber);
                return i;
            }
            tempNum += num;
        }
        Debug.Log(total + "-" + maxLenth + "-" + randomNumber + "-" + tempNum + "-" + num);
        Debug.Log("ERROR : ���������� ���� ����." + correction);
        return 0;
    }
    public static int GetRandomIndex(params double[] probabilities)
    {
        double totalProbability = 0;

        for (int i = 0; i < probabilities.Length; i++)
        {
            if (probabilities[i] < 0 || probabilities[i] > 1)
            {
                throw new ArgumentOutOfRangeException($"Probability at index {i} is out of range (0~1)");
            }

            totalProbability += probabilities[i];
        }

        if (totalProbability < 0 || totalProbability > 1)
        {
            throw new ArgumentException("Sum of probabilities is out of range (0~1)");
        }

        double randomValue = new Random().NextDouble();

        double probabilitySum = 0;

        for (int i = 0; i < probabilities.Length; i++)
        {
            probabilitySum += probabilities[i];

            if (randomValue < probabilitySum)
            {
                return i;
            }
        }
        return probabilities.Length - 1;
    }

    public static string Pertext(float num)
    {
        return Math.Round((num) * 100, 2) + "%";
    }
    public static string Pertext(double num)
    {
        return Math.Round((num) * 100, 2) + "%";
    }
    public static string Pertext(int num)
    {
        return num.ToString();
    }
    public static T RandomArray<T>(T[] per)
    {
        int n = UnityEngine.Random.Range(0, per.Length);
        return per[n];
    }
    public static T RandomParamsArray<T>(params T[] per)
    {
        int n = UnityEngine.Random.Range(0, per.Length);
        return per[n];
    }
    public static T RandomList<T>(List<T> per)
    {
        int n = UnityEngine.Random.Range(0, per.Count);
        return per[n];
    }

    public static string TimeFormat(double timeValue)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeValue);
        int hours = timeSpan.Hours;
        int minutes = timeSpan.Minutes;
        int seconds = timeSpan.Seconds;

        if (timeValue < 60) // 60�� �̸�
        {
            return seconds.ToString("00");
        }
        else if (timeValue < 3600) // 1�ð� �̸�
        {
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else // 1�ð� �̻�
        {
            return string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        }
    }

    #region Max~Min
    public static int Max(int num, int max)
    {
        if (num > max)
            return max;
        return num;
    }
    public static float Max(float num, float max)
    {
        if (num > max)
            return max;
        return num;
    }
    public static long Max(long num, long max)
    {
        if (num > max)
            return max;
        return num;
    }
    public static int Min(int num, int min)
    {
        if (num < min)
            return min;
        return num;
    }
    public static float Min(float num, float min)
    {
        if (num < min)
            return min;
        return num;
    }


    public static long Min(long num, long min)
    {
        if (num < min)
            return min;
        return num;
    }
    public static int MinMax(int num, int min, int max)
    {
        if (num < min)
            return min;
        if (num > max)
            return max;
        return num;
    }
    public static float MinMax(float num, float min, float max)
    {
        if (num < min)
            return min;
        if (num > max)
            return max;
        return num;
    }
    public static long MinMax(long num, long min, long max)
    {
        if (num < min)
            return min;
        if (num > max)
            return max;
        return num;
    }
    public static bool SequenceEqual<T>(List<T> list1, List<T> list2)
    {
        return Enumerable.SequenceEqual(
                   list1.OrderBy(a => a), list2.OrderBy(a => a));
    }

    public static long ExtraExcelConvert(string text)
    //�������� �ڸ��� ���� ���� �ε�� ���
    {
        if (text.Contains('.'))
        {
            Debug.Log("Input number is not decimal. Input :" + text);
            return -1;
        }

        if (text.Contains("E"))
            return (long)(Double.Parse(text.Substring(0, text.IndexOf("+") - 1)) * Math.Pow(10, Int64.Parse(text.Substring(text.IndexOf("+") + 1))));
        return Int64.Parse(text);
    }
    public static List<T> Shuffle<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int rnd = random.Next(0, i);
            T temp = list[i];
            list[i] = list[rnd];
            list[rnd] = temp;
        }
        return list;
    }
    public static T[] Shuffle<T>(T[] list)
    {
        for (int i = list.Length - 1; i > 0; i--)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int rnd = random.Next(0, i);
            T temp = list[i];
            list[i] = list[rnd];
            list[rnd] = temp;
        }
        return list;
    }

    public static string PrintArray<T>(T[] arrays)
    {
        StringBuilder stringReader = new StringBuilder();
        foreach (var item in arrays)
        {
            stringReader.Append(item.ToString() + ", ");
        }
        return stringReader.ToString();
    }

    public static int MostFrequent(int[] arr)
    {
        // Sort the array
        Array.Sort(arr);

        // find the max frequency using
        // linear traversal
        int max_count = 1, res = arr[0];
        int curr_count = 1;

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - 1])
                curr_count++;
            else
                curr_count = 1;

            // If last element is most frequent
            if (curr_count > max_count)
            {
                max_count = curr_count;
                res = arr[i - 1];
            }
        }

        return res;
    }
    #endregion

}