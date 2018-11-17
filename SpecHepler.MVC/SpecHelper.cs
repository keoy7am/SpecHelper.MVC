using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SpecHepler.MVC
{
    public static class SpecHelper
    {
        /// <summary>
        /// 取的亂數種子
        /// </summary>
        /// <returns></returns>
        private static int GetRandomSeedInt()
        {
            return Guid.NewGuid().GetHashCode();
        }
        private static string GetRandomSeedStr()
        {
            return Guid.NewGuid().ToString();
        }
        #region /******************* 自動產生佔位文字 *******************\
        public static string RandomText(this HtmlHelper helper, int minWords, int maxWords,
    int minSentences, int maxSentences,
    int numParagraphs, bool appendDot = true)
        {

            var words = new[]{"lorem", "ipsum", "dolor", "sit", "amet", "consectetuer",
        "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
        "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat"};

            var rand = new Random(GetRandomSeedInt());
            int numSentences = rand.Next(maxSentences - minSentences)
                + minSentences + 1;
            int numWords = rand.Next(maxWords - minWords) + minWords + 1;

            StringBuilder result = new StringBuilder();

            for (int p = 0; p < numParagraphs; p++)
            {
                for (int s = 0; s < numSentences; s++)
                {
                    for (int w = 0; w < numWords; w++)
                    {
                        if (w > 0) { result.Append(" "); }
                        result.Append(words[rand.Next(words.Length)]);
                    }
                    if (appendDot)
                    {
                        result.Append(". ");
                    }
                }
            }

            return result.ToString();
        }
        #endregion
        #region /******************* 自動產生佔位圖片 *******************\
        /*
         * 自動產生佔位圖片
         * ref: https://placem.at/
         * 依照需使用的功能實作
         */
        #region 擴充方法
        /// <summary>
        /// 隨機產生指定大小佔位圖片
        /// </summary>
        /// <param name="width">寬度</param>
        /// <param name="height">高度</param>
        /// <param name="seed">亂數種子</param>
        /// <returns></returns>
        public static string RandomImage(this HtmlHelper helper, int width, int height, string seed = "")
        {
            if (seed == "")
            {
                seed = GetRandomSeedStr();
            }
            return $"https://placem.at/things?w={width}&h={height}&random={seed}";
        }
        /// <summary>
        /// 隨機產生指定大小佔位圖片
        /// </summary>
        /// <param name="width">寬度</param>
        /// <param name="height">高度</param>
        /// <param name="seed">亂數種子</param>
        /// <returns></returns>
        public static string RandomImageWithText(this HtmlHelper helper, int width, int height, string text, string seed = "")
        {
            if (seed == "")
            {
                seed = GetRandomSeedStr();
            }
            text = $"{width}x{height}_{text}";
            return $"https://placem.at/things?w={width}&h={height}&txt={text}&random={seed}";
        }
        #endregion

        #region 一般方法
        /// <summary>
        /// 隨機產生指定大小佔位圖片
        /// </summary>
        /// <param name="width">寬度</param>
        /// <param name="height">高度</param>
        /// <param name="seed">亂數種子</param>
        /// <returns></returns>
        public static string RandomImage(int width, int height, string seed = "")
        {
            if (seed == "")
            {
                seed = GetRandomSeedStr();
            }
            return $"https://placem.at/things?w={width}&h={height}&random={seed}";
        }
        /// <summary>
        /// 隨機產生指定大小佔位圖片
        /// </summary>
        /// <param name="width">寬度</param>
        /// <param name="height">高度</param>
        /// <param name="seed">亂數種子</param>
        /// <returns></returns>
        public static string RandomImageWithText(int width, int height, string text, string seed = "")
        {
            if (seed == "")
            {
                seed = GetRandomSeedStr();
            }
            text = $"{width}x{height}_{text}";
            return $"https://placem.at/things?w={width}&h={height}&txt={text}&random={seed}";
        }
        #endregion
        #endregion
    }
}
