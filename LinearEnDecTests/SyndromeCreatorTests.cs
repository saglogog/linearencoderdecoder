using NUnit.Framework;
using System;
using LinearEnDecTests;
using LinearEncoderDecoderLibrary;

namespace LinearEnDecTests
{
	[TestFixture ()]
	public class SyndromeCreatorTests
	{
		[TestCase ()]
		public void TestCreateErrorVectors ()
		{
			int n =6;
			SyndromeCreator sc = new SyndromeCreator ();
			int[,] errorVectors = sc.CreateErrorVectors (n);

			for (int i = 0; i < n + 1; i++) {
				for (int j = 0; j < n; j++) {
					Console.Write(errorVectors[i,j]+" ");
					if (j == n - 1)
						Console.Write ("\n");
				}
			}
		}
	}
}

