using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreSystem
{
    class HighScoreUtilities
    {
        const string HighScoreFileName = "HighScores";
        static readonly string jsonPath = Directory.GetCurrentDirectory() + $@"\{HighScoreFileName}.json";
        public static void UpdateHighScores(HighScoresArray highScores)
        {
            if (highScores.beginnerHighScores == null || highScores.intermediateHighScores == null || highScores.expertHighScores == null)
            {
                throw new ArgumentNullException("Null highScores parameter");
            }
            FileStream fileStream = File.OpenWrite(jsonPath);
            using (StreamWriter sw = new StreamWriter(fileStream))
            {
                sw.Write(JsonConvert.SerializeObject(highScores));
            }
        }
        public static HighScoresArray GetHighScores()
        {
            try
            {
                var highScoresArray = JsonConvert.DeserializeObject<HighScoresArray>(File.ReadAllText(jsonPath));
                return highScoresArray;
            }
            catch (FileNotFoundException ex)
            {
                throw ex;
            }
        }
        public static HighScore[] SortScoresByTime(HighScore[] array)
        {
            return MergeSortAlgorithm(array, 0, array.Length - 1);
            HighScore[] MergeSortAlgorithm(HighScore[] arr, int left, int right)
            {
                if (left >= right)
                {
                    return arr;
                }
                int middle = (left + right) / 2;
                MergeSortAlgorithm(arr, left, middle);
                MergeSortAlgorithm(arr, middle + 1, right);
                Merge(arr, left, middle, right);
                return arr;
            }
            HighScore[] Merge(HighScore[] arr, int left, int middle, int right)
            {
                int leftArrayLength = middle - left + 1;
                int rightArrayLength = right - middle;
                HighScore[] leftArray = new HighScore[leftArrayLength];
                HighScore[] righArray = new HighScore[rightArrayLength];

                for (int i = 0; i < leftArrayLength; i++)
                {
                    leftArray[i] = arr[i + left];
                }
                for (int i = 0; i < rightArrayLength; i++)
                {
                    righArray[i] = arr[i + middle + 1];
                }

                int leftCounter = 0;
                int rightCounter = 0;
                int counter = left;
                while (leftCounter < leftArrayLength && rightCounter < rightArrayLength)
                {
                    if (leftArray[leftCounter].time < righArray[rightCounter].time)
                    {
                        arr[counter] = leftArray[leftCounter];
                        counter++;
                        leftCounter++;
                    }
                    else
                    {
                        arr[counter] = righArray[rightCounter];
                        counter++;
                        rightCounter++;
                    }
                }

                while (leftCounter < leftArrayLength)
                {
                    arr[counter] = leftArray[leftCounter];
                    counter++;
                    leftCounter++;
                }
                while (rightCounter < rightArrayLength)
                {
                    arr[counter] = righArray[rightCounter];
                    counter++;
                    rightCounter++;
                }
                return arr;
            }
        }
    }
    public struct HighScoresArray
    {
        public List<HighScore> beginnerHighScores;
        public List<HighScore> intermediateHighScores;
        public List<HighScore> expertHighScores;
    }
    public struct HighScore
    {
        public string userName;
        public int time;
        public DateTime date;
    }
}
