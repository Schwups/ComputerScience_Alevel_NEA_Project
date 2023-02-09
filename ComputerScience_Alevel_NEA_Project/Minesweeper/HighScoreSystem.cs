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
        public static void UpdateHighScores(HighScore[] highScores)
        {
            if (highScores == null)
            {
                throw new ArgumentNullException("highScores parameter was null");
            }
            HighScoresArray highScoresArray = new HighScoresArray()
            {
                highScores = highScores
            };
            FileStream fileStream = File.OpenWrite(jsonPath);
            using (StreamWriter sw = new StreamWriter(fileStream))
            {
                sw.Write(JsonConvert.SerializeObject(highScoresArray));
            }
        }
        public static HighScore[] GetHighScores()
        {
            var highScoresArray = JsonConvert.DeserializeObject<HighScoresArray>(File.ReadAllText(jsonPath));
            return highScoresArray.highScores;
        }
        private struct HighScoresArray
        {
            public HighScore[] highScores;
        }
    }
    public struct HighScore
    {
        public string userName;
        public int time;
        public DateTime date;
    }
}
