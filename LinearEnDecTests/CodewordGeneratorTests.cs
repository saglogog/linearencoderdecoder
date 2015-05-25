using NUnit.Framework;
using System;
using LinearEncoderDecoderLibrary;

namespace LinearEnDecTests
{
	[TestFixture ()]
	public class CodewordGeneratorTests
	{
		[Test ()]
		public void TestCase ()
		{
			CodewordGenerator cg = new CodewordGenerator (5);
			int[,] msgWords = cg.CreateAllBinaryMsgWords ();
			for (int i = 0; i < 32; i++) {
				Console.Write ("\n{0} {1} {2} {3} {4}\n", msgWords [i, 0], msgWords [i, 1], msgWords [i, 2], msgWords[i,3], msgWords[i,4]);
			}
		}
	}
}

