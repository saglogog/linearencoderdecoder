using NUnit.Framework;
using System;
using LinearEnDecTests;
using LinearEncoderDecoderLibrary;
using System.Collections.Generic;

namespace LinearEnDecTests
{
	[TestFixture ()]
	public class SyndromeCreatorTests
	{
		[Test ()]
		public void TestCreateErrorVectors ()
		{
			int n = 6;
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

		[Test ()]
		public void TestCreateSyndrome()
		{
			if (PropertyClass.PArray == null) {
				MockSetupClass msc = new MockSetupClass ();
				msc.FillMatrix ();
			}
			int[,] PMatrix = PropertyClass.PArray;
			MatrixCreator mc = new MatrixCreator ();
			int[,] HMatrix = mc.HCreator ();
			SyndromeCreator sc = new SyndromeCreator ();
			Dictionary<int[], int[]> errorVectorAndSyndromeArray = sc.CreateSyndrome (7, HMatrix);
			int c = errorVectorAndSyndromeArray.Count;
			int[][] errorSyndromes = new int[c][];
			int[][] errorVectors = new int[c][];
			errorVectorAndSyndromeArray.Keys.CopyTo (errorSyndromes, 0);
			errorVectorAndSyndromeArray.Values.CopyTo (errorVectors,0);

			for (int i = 0; i < c; i++) {
				for (int j = 0; j < errorSyndromes [1] [1].ToString ().Length;) {
					Console.Write(errorVectors[i][j]);
				}
				Console.Write ("\n");
			}
		}
	}
}