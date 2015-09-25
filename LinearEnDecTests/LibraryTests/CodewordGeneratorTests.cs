using NUnit.Framework;
using System;
using LinearEncoderDecoderLibrary;
using System.Threading;

namespace LinearEnDecTests
{
	[TestFixture ()]
	public class CodewordGeneratorTests
	{
		/// <summary>
		/// Tests the CreateAllBinaryMsgWords  method.
		/// </summary>
		[Test ()]
		public void TestCreateAllBinaryMsgWords ()
		{
			CodewordGenerator cg = new CodewordGenerator (5);
			int[,] msgWords = cg.CreateAllBinaryMsgWords ();
			for (int i = 0; i < 32; i++) {
				Console.Write ("\n{0} {1} {2} {3} {4}\n", msgWords [i, 0], msgWords [i, 1], msgWords [i, 2], msgWords[i,3], msgWords[i,4]);
			}
		}

		/// <summary>
		/// Tests the CreateAllCodewordsBasedOnKAndP method.
		/// </summary>
		[Test ()]
		public void TestCreateAllCodewordsBasedOnKAndP()
		{
			if (PropertyClass.PArray == null) {
				MockSetupClass msc = new MockSetupClass ();
				msc.FillMatrix ();
			}
			CodewordGenerator cg = new CodewordGenerator (PropertyClass.PArray.GetLength(0));
			//Thread.Sleep (5000);
			int[,] allCodewordsBasedOnKAndP = cg.CreateAllCodewordsBasedOnKAndP (PropertyClass.PArray.GetLength(0)+
				PropertyClass.PArray.GetLength(1));
			for (int i = 0; i < 8; i++) {
				Console.Write ("\n{0} {1} {2} {3} {4} {5} {6}\n", allCodewordsBasedOnKAndP [i,0], allCodewordsBasedOnKAndP [i, 1], allCodewordsBasedOnKAndP [i, 2], allCodewordsBasedOnKAndP [i,3], allCodewordsBasedOnKAndP[i,4], allCodewordsBasedOnKAndP[i,5], allCodewordsBasedOnKAndP [i,6]) ;				
			}
		}
	
	}
}