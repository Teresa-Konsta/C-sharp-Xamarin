using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4Question2
{
    public class Sentence
    {
		static Random random = new Random();
		StringBuilder stringBuilder;
		string[] words;

		public Sentence(string[] wordsInput)
		{
			stringBuilder = new StringBuilder();
			this.words = wordsInput;
		}

		public void GenerateSentence(int numberOfWords)
		{
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < numberOfWords; i++)
			{
				sb.Append(words[random.Next(words.Length)]).Append(" ");
			}
			string sentence = sb.ToString().Trim();
			
			stringBuilder.Append(sentence);
		}

		public string SentenceContent
		{
			get
			{
				return stringBuilder.ToString();
			}
		}
	}
}
