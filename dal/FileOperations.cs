using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace dal
{
	public static class FileOperations
	{
		public static string[] ReadFromFile(string input)
		{
			// lees tekst vanuit input
			string[] wordList;
			wordList = File.ReadAllLines(@$"..\..\..\..\dal\data\{input}");

			//string[] testStrings = { "foobar", "fo", "obar", "f", "oo", "b", "ar" };

			return wordList;

		}
	}
}
